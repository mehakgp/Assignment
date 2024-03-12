using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.ModelView
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; } 

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
    }

    public class ParkingZoneModel
    {
        public int ParkingZoneId { get; set; }
        public string ParkingZoneTitle { get; set; }
    }


    public class ParkingSpaceModel
    {
        public int ParkingSpaceId { get; set; }
        public string ParkingSpaceTitle { get; set; }
        public int ParkingZoneId {  get; set; }
        public bool IsOccupied { get; set; }

        public string VehicleRegistrationNumber { get; set; }
    }

    public class ParkingSpaceListViewModel
    {
        public List<ParkingSpaceModel> ParkingSpaces { get; set; }
        public List<ParkingZoneModel> ParkingZones { get; set; }
        public int[] SelectedZoneIds { get; set; }
    }

    public class VehicleParkingModel
    {
        public int VehicleParkingId { get; set; }
        public int ParkingZoneId { get; set; }
        public int ParkingSpaceId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public string VehicleRegistrationNumber { get; set; }
    }

    public class ParkingZoneReportModel
    {
        public int ParkingZoneId { get; set; }
        public string ParkingZoneTitle { get; set; }
        public int ParkingSpaceId { get; set; }
        public string ParkingSpaceTitle { get; set; }
        public int NumberOfBookings { get; set; }
        public bool IsVehicleParked { get; set; }
    }

    public class SessionModel
    {
        public int UserId { get; set; }
        public string Type { get; set; }
    }

    public class AddParkingZoneModel
    {
        [Required(ErrorMessage = "Parking Zone Title is required")]
        public string ParkingZoneTitle { get; set; }

        [Required(ErrorMessage = "Number of spaces is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of spaces must be at least 1")]
        public int NumberOfSpaces { get; set; }
    }

    public class AddParkingSpaceModel
    {
        [Required(ErrorMessage = "Please select a parking zone")]
        public int SelectedZoneId { get; set; }

        [Required(ErrorMessage = "Please enter the number of spaces")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of spaces must be at least 1")]
        public int NumberOfSpaces { get; set; }

    }
}
