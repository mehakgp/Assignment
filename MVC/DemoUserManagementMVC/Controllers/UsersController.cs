using DemoUserManagementMVC.ModelView;
using DemoUserManangementMVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagementMVC.Attributes;
namespace DemoUserManagementMVC.Controllers
{
    public class UsersController : Controller
    {


        [HttpGet]
        [CustomAuthorizeAttributeForUserList]
        public ActionResult UserList(int page = 1, int pageSize = 10, string sortExpression = "UserID", string sortDirection = "ASC")
        {
            PagedUserListModel model=new Business().GetUsers(page, pageSize, sortExpression, sortDirection);

            return View(model);
        }



       
        [CustomAuthorizeAttributeForUserList]
        public ActionResult DeleteUser(int id)
        {
            bool success = new Business().DeleteUser(id);
            if (success)
            {
                return RedirectToAction("UserList");
            }
            else
            {
                TempData["DeleteUserError"] = "An error occurred while deleting the user.";
                return RedirectToAction("UserList");
            }
        }

    }

}
