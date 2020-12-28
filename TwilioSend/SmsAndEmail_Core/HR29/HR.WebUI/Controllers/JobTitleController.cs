
using HR.BLL.Models;
using HR.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebUI.Controllers
{
    public class JobTitleController : Controller
    {
        IGenericService<JobTitleDTO, int> repo;
        public JobTitleController(IGenericService<JobTitleDTO, int> repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var model = repo.GetAll();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = repo.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(JobTitleDTO job)
        {
            if (ModelState.IsValid)
            {
                repo.Update(job);
                return RedirectToAction("Index");
            }
            return View(job);
        }



        //HrContext context;
        //public JobTitleController(HrContext context)
        //{
        //    this.context = context;
        //}
        //public IActionResult Index()
        //{
        //    var model = context.JobTitles;
        //    return View(model);
        //}
    }
}