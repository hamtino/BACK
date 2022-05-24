using BACK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateStudentController : ControllerBase
    {
        [HttpPost]
        public string Post(Student students)
        {

            return "Se agrego " + students.name + " correctamente";
        }
    }
}
