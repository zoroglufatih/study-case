using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudyCase.UI.Models;
using StudyCase.UI.Services.Abstracts;
using System.Diagnostics;
using System.Text.Json;

namespace StudyCase.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpRequestService _httpRequestService;
        private string _url;
        public HomeController(ILogger<HomeController> logger, IHttpRequestService httpRequestService)
        {
            _logger = logger;
            _httpRequestService = httpRequestService;
            _url = "https://localhost:7077/api/Assign/TaskAssignment";
        }

        public async Task<IActionResult> Index()
        {
            ApiResponseDto response = new();
            response = await _httpRequestService.GetAsync(_url);
            //List<AssignmentViewModel> model = JsonSerializer.Deser<List<AssignmentViewModel>>(response.ResponseValue);
            List<AssignmentViewModel> model = JsonConvert.DeserializeObject<List<AssignmentViewModel>>(response.ResponseValue);


            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}