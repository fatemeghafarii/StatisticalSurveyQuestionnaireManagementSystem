using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Create;

public sealed class CreateQuestionnaireVersionCommandHandler
    : IRequestHandler<
        CreateQuestionnaireVersionCommand,
        Result<CreateQuestionnaireVersionResponse>>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionnaireVersionCommandHandler(IApplicationDbContext context) => _context = context;
    
    public async Task<Result<CreateQuestionnaireVersionResponse>> Handle(CreateQuestionnaireVersionCommand request, CancellationToken cancellationToken)
    {
        var questionnaireExists =
               await _context.Questionnaires
                   .AnyAsync(
                       x => x.Id == request.QuestionnaireId,
                       cancellationToken);


        if (!questionnaireExists) 
        {
            return Result<CreateQuestionnaireVersionResponse>
                .Failure(
                    "پرسشنامه مورد نظر پیدا نشد.");
        }

        var lastVersionNumber =
            await _context.QuestionnaireVersions
                .Where(x =>
                    x.QuestionnaireId == request.QuestionnaireId)
                .MaxAsync(
                    x => (int?)x.VersionNumber,
                    cancellationToken)
                ?? 0;

        var draftStatus = await _context.QuestionnaireVersionStatusTypes
            .SingleOrDefaultAsync(
                   x => x.Code == QuestionnaireVersionStatusCodes.Draft,
                   //x => x.Code == "DRAFT",
                cancellationToken);

        if (draftStatus is null)
        {
            return Result<CreateQuestionnaireVersionResponse>.Failure("وضعیت پیش‌نویس پرسشنامه پیدا نشد.");
        }

        var version = new QuestionnaireVersion
        {
            QuestionnaireId = request.QuestionnaireId,

            VersionNumber = lastVersionNumber + 1,

            Title = request.Title,

            EffectiveDate = request.EffectiveDate,
            
            StatusId = draftStatus.Id,

            IsActive = false
        };

        await _context.QuestionnaireVersions
            .AddAsync(version,cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreateQuestionnaireVersionResponse>
           .Success(
               new CreateQuestionnaireVersionResponse
               {
                   Id = version.Id,
                   QuestionnaireId = version.QuestionnaireId,
                   VersionNumber = version.VersionNumber,
                   Title = version.Title,
                   EffectiveDate = version.EffectiveDate,
                   StatusId = draftStatus.Id,
                   StatusCode = draftStatus.Code,
                   IsActive = version.IsActive
               });
    }
}
