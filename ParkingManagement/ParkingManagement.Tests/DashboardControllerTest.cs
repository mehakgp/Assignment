using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Web.Mvc;


namespace ParkingManagement.Tests
{
    [TestClass]
    public class DashboardControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithViewModel()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            var result = controller.Index(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ParkingSpaceListViewModel));
        }

        [TestMethod]
        public void BookParkingSpace_RedirectsToIndexWithSuccessMessage()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            var result = controller.BookParkingSpace(1, "MP 09 AB 1234", null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["SuccessMessage"]);
        }

        [TestMethod]
        public void ReleaseParkingSpace_RedirectsToIndexWithSuccessMessage()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            var result = controller.ReleaseParkingSpace(1, "MP 09 AB 1234", null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["SuccessMessage"]);
        }

        [TestMethod]
        public void ReleaseAllParkingSpace_RedirectsToIndexWithSuccessMessage()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            var result = controller.ReleaseAllParkingSpace(null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(controller.TempData["SuccessMessage"]);
        }
    }

}
