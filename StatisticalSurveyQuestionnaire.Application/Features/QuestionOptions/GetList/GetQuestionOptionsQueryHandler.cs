using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.GetList;

public sealed class GetQuestionOptionsQueryHandler
    : IRequestHandler<
            GetQuestionOptionsQuery,
            Result<GetQuestionOptionsResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionOptionsQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetQuestionOptionsResponse>> Handle(GetQuestionOptionsQuery request, CancellationToken cancellationToken)
    {
        var questionExists =
            await _context.Questions
               .AnyAsync(
                   x => x.Id == request.QuestionId,
                   cancellationToken);

        if (!questionExists)
        {
            return Result<GetQuestionOptionsResponse>
                .Failure(
                    "سوال مورد نظر پیدا نشد.");
        }

        var items =
            await _context.QuestionOptions
            .AsNoTracking()
            .Where(x => x.QuestionId == request.QuestionId)
            .OrderBy(x => x.Order)
            .Select(x => new QuestionOptionItem
            {
                Id = x.Id,
                
                Text = x.Text,
                
                Order = x.Order
            })
            .ToListAsync(cancellationToken);

        return Result<GetQuestionOptionsResponse>
            .Success(new GetQuestionOptionsResponse
            {
                QuestionId = request.QuestionId,
                
                Items = items
            });
    }
}
