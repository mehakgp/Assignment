using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        // GET: api/<StudentAttendanceController>
        [HttpGet]
        public IEnumerable<StudentAttendanceDetailsModel> Get()
        {
            return new List<StudentAttendanceDetailsModel>
            {
                new StudentAttendanceDetailsModel
                {
                    StudentId = 1,
                    StudentName="check1",
                    AttendencePercentage=80
                },
                new StudentAttendanceDetailsModel
                {
                    StudentId = 2,
                    StudentName="check2",
                    AttendencePercentage=77
                },
            };
        }
    }
}
