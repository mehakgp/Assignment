using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Web.Mvc;

namespace ParkingManagement.Tests
{
    [TestClass]
    public class EditControllerTest
    {
        [TestMethod]
        public void EditParkingSpace_EditsParkingSpace_Successfully()
        {
            var controller = new EditController();
            var editParkingSpace = new AddParkingSpaceModel
            {
                SelectedZoneId = 1014,
                NumberOfSpaces = 10,
            };

            var result = controller.EditParkingSpace(editParkingSpace) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("SuccessMessage"));
            Assert.AreEqual("Parking Space edited successfully", result.ViewData["SuccessMessage"]);
        }

        [TestMethod]
        public void EditParkingSpace_FailsToEditParkingSpace()
        {

            var controller = new EditController();
            var newParkingSpace = new AddParkingSpaceModel
            {
                SelectedZoneId = 1,
                NumberOfSpaces = 0,
            };
            var result = controller.EditParkingSpace(newParkingSpace) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ContainsKey("ErrorMessage"));
            Assert.AreEqual("Failed to edit parking space. Please try again.", result.ViewData["ErrorMessage"]);
        }
    }
}
