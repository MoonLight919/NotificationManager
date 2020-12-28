using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.BLL.Models;
using HR.BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IGenericService<EmployeeDTO, int> service;
        public EmployeeController(IGenericService<EmployeeDTO, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            return service.GetAll();
        }
    }
}