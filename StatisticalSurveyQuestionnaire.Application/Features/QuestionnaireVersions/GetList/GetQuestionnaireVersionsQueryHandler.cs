using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;

public sealed class GetQuestionnaireVersionsQueryHandler
    : IRequestHandler<
        GetQuestionnaireVersionsQuery,
        Result<GetQuestionnaireVersionsResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionnaireVersionsQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<GetQuestionnaireVersionsResponse>> Handle(GetQuestionnaireVersionsQuery request, CancellationToken cancellationToken)
    {
        var questionnaireExists =
            await _context.Questionnaires
                .AnyAsync(
                    x => x.Id == request.QuestionnaireId,
                    cancellationToken);

        if (!questionnaireExists)
        {
            return Result<GetQuestionnaireVersionsResponse>
                .Failure(
                    "پرسشنامه مورد نظر پیدا نشد.");
        }

        var query = _context.QuestionnaireVersions
            .AsNoTracking()
            .Where(x => x.QuestionnaireId == request.QuestionnaireId);

        var items = await query
            .OrderByDescending(x => x.VersionNumber)
            //.Skip((request.PageNumber - 1) * request.PageSize)
            //.Take(request.PageSize)
            .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .Select(x => new QuestionnaireVersionListItem
            {
                Id = x.Id,
                QuestionnaireId = x.QuestionnaireId,
                VersionNumber = x.VersionNumber,
                Title = x.Title,
                EffectiveDate = x.EffectiveDate,
                StatusId = x.StatusId,
                StatusCode = x.Status.Code,
                IsActive = x.IsActive,
            })
            .ToListAsync(cancellationToken); ;

        var totalCount = await query.CountAsync(cancellationToken);

        return Result<GetQuestionnaireVersionsResponse>
            .Success(new GetQuestionnaireVersionsResponse
            {
                Data = new PaginatedList<QuestionnaireVersionListItem>
                {
                    Items = items,
                    PageNumber = request.Pagination.PageNumber,
                    PageSize = request.Pagination.PageSize,
                    TotalCount = totalCount
                }
            });

        //return Result<GetQuestionnaireVersionsResponse>
        //    .Success(new GetQuestionnaireVersionsResponse
        //    {
        //        Items = items,
        //        PageNumber = request.PageNumber,
        //        PageSize = request.PageSize,
        //        TotalCount = totalCount
        //    });

        //before pagination
        //return Result<List<GetQuestionnaireVersionsResponse>>
        //    .Success(await _context.QuestionnaireVersions
        //    .AsNoTracking()
        //    .Where(x => x.QuestionnaireId == request.QuestionnaireId)
        //    .OrderByDescending(x => x.VersionNumber)
        //    .Select(x => new GetQuestionnaireVersionsResponse
        //    {
        //        Id = x.Id,
        //        QuestionnaireId = x.QuestionnaireId,
        //        VersionNumber = x.VersionNumber,
        //        Title = x.Title,
        //        EffectiveDate = x.EffectiveDate,
        //        StatusId = x.StatusId,
        //        StatusCode = x.Status.Code,
        //        IsActive = x.IsActive
        //    })
        //    .ToListAsync(cancellationToken));
    }
}
