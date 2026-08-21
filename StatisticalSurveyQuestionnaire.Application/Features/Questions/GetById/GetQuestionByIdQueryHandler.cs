using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetById;

public sealed class GetQuestionByIdQueryHandler
    : IRequestHandler<
        GetQuestionByIdQuery,
        Result<GetQuestionByIdResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionByIdQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetQuestionByIdResponse>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question =
            await _context.Questions
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new GetQuestionByIdResponse
                {
                    Id = x.Id,
                  
                    QuestionnaireVersionId = x.QuestionnaireVersionId,
                    
                    Text = x.Text,
                    
                    QuestionTypeId = x.QuestionTypeId,
                    
                    QuestionTypeTitle = x.QuestionType.Title,
                    
                    Order = x.Order
                })
                .SingleOrDefaultAsync(cancellationToken);

        if (question is null)
        {
            return Result<GetQuestionByIdResponse>
                .Failure(
                    "سوال مورد نظر پیدا نشد.");
        }

        return Result<GetQuestionByIdResponse>.Success(question);
    }
}
