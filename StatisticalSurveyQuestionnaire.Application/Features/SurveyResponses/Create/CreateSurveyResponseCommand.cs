using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.SurveyResponses.Create;
//TODO:NOT_STARTED — a response record exists, but answering hasn't begun.
//TODO:COMPLETED — all required answering is finished.
//TODO:CANCELED — the response was intentionally canceled.
//TODO:REJECTED — the response was rejected for a business reason.
public sealed record CreateSurveyResponseCommand
(
    int HouseholdId,
    int QuestionnaireVersionId,
    int SurveyPeriodId
) : IRequest<Result<CreateSurveyResponseResponse>>;
public sealed class CreateSurveyResponseCommandHandler
    : IRequestHandler<
        CreateSurveyResponseCommand,
        Result<CreateSurveyResponseResponse>>
{
    private readonly IApplicationDbContext _context;
    public CreateSurveyResponseCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<CreateSurveyResponseResponse>> Handle(CreateSurveyResponseCommand request, CancellationToken cancellationToken)
    {
        //var houseHoldExists =
        //       await _context.Households
        //           .AnyAsync(
        //               x => x.Id == request.HouseholdId,
        //               cancellationToken);
        var houseHold =
            await _context.Households
            .AsNoTracking()
            .SingleOrDefaultAsync(
                x => x.Id == request.HouseholdId,
                cancellationToken);

        //if (!houseHoldExists)
        //{
        //    return Result<CreateSurveyResponseResponse>
        //        .Failure(
        //            "خانوار مورد نظر پیدا نشد.");
        //}

        if (houseHold == null)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "خانوار مورد نظر پیدا نشد.");
        }

        var version =
               await _context.QuestionnaireVersions
                   .AsNoTracking()
                   .Include(x => x.Status)
                   .FirstOrDefaultAsync(
                       x => x.Id == request.QuestionnaireVersionId,
                       cancellationToken);

        if (version == null)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "نسخه ی پرسشنامه ی مورد نظر پیدا نشد.");
        }

        if (version.Status.Code != QuestionnaireVersionStatusCodes.Published || !version.IsActive)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "فقط نسخه منتشر شده و فعال پرسشنامه قابل پاسخ‌ دهی است.");
        }

        var surveyPeriodExists =
               await _context.SurveyPeriods
                   .AnyAsync(
                       x => x.Id == request.SurveyPeriodId,
                       cancellationToken);

        if (!surveyPeriodExists)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "دوره آماری مورد نظر پیدا نشد.");
        }

        var responseStatus =
            await _context.SurveyResponseStatusTypes
            .AsNoTracking()
            .SingleOrDefaultAsync(
                   x => x.Code == SurveyResponseStatusCodes.In_Progress,
                cancellationToken);

        if (responseStatus is null)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "وضعیت در حال اجرای پاسخگویی پیدا نشد.");
        }

        var responseExists =
            await _context.SurveyResponses
                .AnyAsync(
                    x =>
                        x.HouseholdId == request.HouseholdId &&
                        x.QuestionnaireVersionId == request.QuestionnaireVersionId &&
                        x.SurveyPeriodId == request.SurveyPeriodId &&
                        x.Status.Code == SurveyResponseStatusCodes.In_Progress,
                    cancellationToken);

        if (responseExists)
        {
            return Result<CreateSurveyResponseResponse>
                .Failure(
                    "برای این خانوار، نسخه پرسشنامه و دوره آماری مورد نظر، پاسخ‌گویی در حال انجام وجود دارد.");
        }

        var response = new SurveyResponse
        {
            HouseholdId = request.HouseholdId,
           
            QuestionnaireVersionId = request.QuestionnaireVersionId,
            
            SurveyPeriodId = request.SurveyPeriodId,
            
            StatusId = responseStatus.Id,
            
            StartedDate = DateTime.UtcNow,
            
            CompletedDate = null
        };

        await _context.SurveyResponses
            .AddAsync(response, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreateSurveyResponseResponse>
           .Success(
               new CreateSurveyResponseResponse
               {
                   Id = response.Id,
                  
                   HouseholdId = response.HouseholdId,
                   
                   HouseholdCode = houseHold.Code,
                   
                   QuestionnaireVersionId = response.QuestionnaireVersionId,
                   
                   VersionNumber = version.VersionNumber,
                   
                   VersionStatusCode = version.Status.Code,

                   VersionStatusTitle = version.Status.Title,
                   
                   ResponseStatusId = response.SurveyPeriodId,
                   
                   ResponseStatusCode = responseStatus.Code,
                   
                   ResponseStatusTitle = responseStatus.Title,
                   
                   StartedDate = DateTime.UtcNow,   
                   
                   CompletedDate = response.CompletedDate
               });
    }
}
public sealed class CreateSurveyResponseCommandValidator
    : AbstractValidator<CreateSurveyResponseResponse>
{
    public CreateSurveyResponseCommandValidator()
    {
        RuleFor(x => x.HouseholdId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه خانوار باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.QuestionnaireVersionId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه نسخه پرسشنامه باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.ResponseStatusId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه دوره ی آماری باید بزرگ‌تر از صفر باشد.");
    }
}
public sealed class CreateSurveyResponseResponse
{
    public int Id { get; init; }

    public int HouseholdId { get; init; }
    
    public string HouseholdCode { get; init; } = null!;
    
    public int QuestionnaireVersionId { get; init; }
    
    public int VersionNumber { get; init; }
    
    public string VersionStatusCode { get; init; } = null!;

    public string VersionStatusTitle { get; init; } = null!;

    public int SurveyPeriodId { get; init; }

    public int ResponseStatusId { get; init; }
    
    public string ResponseStatusCode { get; init; } = null!;

    public string ResponseStatusTitle { get; init; } = null!;

    public DateTime? StartedDate { get; init; }
    
    public DateTime? CompletedDate { get; init; }
}
