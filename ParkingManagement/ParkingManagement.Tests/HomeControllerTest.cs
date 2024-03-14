using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagement.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void LogIn_ValidModel_UserValid_RedirectsToDashboard()
        {
            var controller = new HomeController();
            var model = new LogInModel { Email = "check@gmail.com", Password = "mehakgupta" };

            var result = controller.LogIn(model) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Dashboard", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void LogIn_ValidModel_UserNotValid_ReturnsViewWithError()
        {
            var controller = new HomeController();
            var model = new LogInModel { Email = "invalid@example.com", Password = "invalidpassword" };

            var result = controller.LogIn(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("ErrorMessage"));
            Assert.AreEqual("Invalid Email or Password.", result.ViewData["ErrorMessage"]);
        }

        [TestMethod]
        public void LogIn_InvalidModel_ReturnsView()
        {
            var controller = new HomeController();

            var result = controller.LogIn(new LogInModel()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LogOut_RedirectsToLogIn()
        {
            var controller = new HomeController();
            var result = controller.LogOut() as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("LogIn", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
    }
}
