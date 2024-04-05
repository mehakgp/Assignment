using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        // GET: api/<StudentAdmissionController>
        [HttpGet]
        public IEnumerable<StudentAdmissionDetailsModel> Get()
        {
            return new List<StudentAdmissionDetailsModel>
            {
                new StudentAdmissionDetailsModel
                {
                    StudentId = 1,
                    StudentName = "check1",
                    StudentClass = "X",
                    DateofJoining = DateTime.Now,
                },
                 new StudentAdmissionDetailsModel
                {
                    StudentId = 2,
                    StudentName = "check2",
                    StudentClass = "X",
                    DateofJoining = DateTime.Now,
                },
            };

        }
    }
}