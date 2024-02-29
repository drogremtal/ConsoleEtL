using DAO;
using ETLClient;
using EtlUpload;
using ETLWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace ETLWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _contex;
        private IUploadService _uploadService;
        private readonly IRepositoryBase _repositoryBase;

        public HomeController(ILogger<HomeController> logger, DefaultContext dbContext, IUploadService uploadService,
            IRepositoryBase repositoryBase)
        {
            _contex = dbContext;
            _logger = logger;
            _uploadService = uploadService;
            _repositoryBase = repositoryBase;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> ExtractData()
        {
            Uri uri = new Uri("http://universities.hipolabs.com/search");
            Dictionary<string, string> parameters = new Dictionary<string, string>() { { "country", "Russian Federation" } };
            var data = await _uploadService.GetDataFromAPI<Universitet>(uri, parameters);
            await foreach (var item in data)
            {
                _repositoryBase.Add(item);
            }

            await _repositoryBase.SaveChangesAsync();

            return new OkObjectResult(data);
        }


        //public async Task<IActionResult> Test()
        //{
        //    var test =


        //    return new OkResult();
        //}
    }
}
