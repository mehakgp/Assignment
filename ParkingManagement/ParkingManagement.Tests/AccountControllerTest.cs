using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Web.Mvc;

namespace ParkingManagement.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void SignUp_Get_ReturnsView()
        {
            // Arrange
            var controller = new AccountController();

            // Act
            var result = controller.SignUp() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SignUp_Post_ValidModel_RedirectsToLogInWithSuccessMessage()
        {
            // Arrange
            var controller = new AccountController();
            var userModel = new UserModel {
                Name ="sample",
                Email= "test@example.com",
                Password= "testing",
                Type = "BookingCounterAgent"

            };

            // Act
            var result = controller.SignUp(userModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("LogIn", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
            Assert.IsNotNull(controller.TempData["SuccessMessage"]);
        }

        [TestMethod]
        public void SignUp_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var controller = new AccountController();
         
            // Act
            var result = controller.SignUp(new UserModel()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(UserModel));
        }

        [TestMethod]
        public void CheckEmailExists_ReturnsJsonResult()
        {
            // Arrange
            var controller = new AccountController();
            var email = "test@example.com"; 

            // Act
            var result = controller.CheckEmailExists(email) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((bool)result.Data.GetType().GetProperty("exists").GetValue(result.Data));
        }
    }

}
