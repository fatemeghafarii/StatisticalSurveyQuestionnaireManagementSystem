using StatisticalSurveyQuestionnaire.Application.Common.Enums;

namespace StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
public interface ICodeGenerator
{
    string Generate(CodePrefix prefix);
}
