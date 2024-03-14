using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.ModelView;
using System.Collections.Generic;
using System.Web.Mvc;
using System;


namespace ParkingManagement.Tests
{
    [TestClass]
    public class ReportControllerTests
    {
        [TestMethod]
        public void ParkingZoneReport_ReturnsViewWithReport()
        {
            // Arrange
            var controller = new ReportController();
            var date = DateTime.Today;

            // Act
            var result = controller.ParkingZoneReport(date) as ViewResult;
            var model = result.Model as List<ParkingZoneReportModel>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
        }
    }
}
