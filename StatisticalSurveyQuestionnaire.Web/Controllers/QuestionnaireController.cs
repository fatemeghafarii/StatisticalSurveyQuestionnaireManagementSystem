using Microsoft.AspNetCore.Mvc;

namespace StatisticalSurveyQuestionnaire.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
