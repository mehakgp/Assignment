using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Web.Mvc;


namespace ParkingManagement.Tests
{
    [TestClass]
    public class InitializeControllerTest
    {
        [TestMethod]
        public void AddParkingZone_ReturnsView_WhenModelStateIsNotValid()
        {
            var controller = new InitializeController();
            var result = controller.AddParkingZone(new AddParkingZoneModel()) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void AddParkingZone_AddsParkingZone_Successfully()
        { 
            var controller = new InitializeController();          
            var newParkingZone = new AddParkingZoneModel
            {
                ParkingZoneTitle= "Z",
                NumberOfSpaces = 10,
            };

            // Act
            var result = controller.AddParkingZone(newParkingZone) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("SuccessMessage"));
            Assert.AreEqual("Parking Zone added successfully", result.ViewData["SuccessMessage"]);
        }

        [TestMethod]
        public void AddParkingZone_FailsToAddParkingZone()
        {
          
            var controller = new InitializeController();
            var newParkingZone = new AddParkingZoneModel
            {
                ParkingZoneTitle = "Z",
                NumberOfSpaces = 0,
            };
            var result = controller.AddParkingZone(newParkingZone) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("ErrorMessage"));
            Assert.AreEqual("Failed to add parking zone. Please try again.", result.ViewData["ErrorMessage"]);
        }

        [TestMethod]
        public void AddParkingSpace_AddsParkingSpace_Successfully()
        {
            var controller = new InitializeController();
            var addParkingSpace = new AddParkingSpaceModel
            {
                SelectedZoneId = 1,
                NumberOfSpaces = 10,
            };

            // Act
            var result = controller.AddParkingSpace(addParkingSpace) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("SuccessMessage"));
            Assert.AreEqual("Parking Space added successfully", result.ViewData["SuccessMessage"]);
        }

        [TestMethod]
        public void AddParkingSpace_FailsToAddParkingSpace()
        {

            var controller = new InitializeController();
            var newParkingSpace = new AddParkingSpaceModel
            {
                SelectedZoneId = 1,
                NumberOfSpaces = 0,
            };
            var result = controller.AddParkingSpace(newParkingSpace) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("ErrorMessage"));
            Assert.AreEqual("Failed to add parking space. Please try again.", result.ViewData["ErrorMessage"]);
        }
    }

}
