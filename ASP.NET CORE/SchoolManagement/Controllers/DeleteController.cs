using Microsoft.AspNetCore.Mvc;
using SchoolManagement.BusinessLayer;

namespace SchoolManagement.Controllers
{
    public class DeleteController : Controller
    {
        private IBusiness _business;
        public DeleteController(IBusiness business)
        {
            _business = business;
        }


    }
}
