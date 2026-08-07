using StatisticalSurveyQuestionnaire.Application.Common.Enums;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Services;
public class CodeGenerator : ICodeGenerator
{
    public string Generate(CodePrefix prefix)
    {
        var prefixText = prefix switch
        {
            CodePrefix.Questionnaire => "QNR",
            CodePrefix.Household => "HHD",
        };

        return $"{prefix}-{DateTime.UtcNow:yyyyMMddHHmmss}";
    }
}
