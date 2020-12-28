using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.BLL.Models;
using HR.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebUI.Controllers
{
    public class TestController : Controller
    {
        IGenericService<TestDTO, Guid> repo;
        public TestController(IGenericService<TestDTO, Guid> repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var model = repo.GetAll();
            return View(model);
        }
    }
}