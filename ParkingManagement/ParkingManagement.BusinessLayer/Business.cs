using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.DataAccessLayer;
using ParkingManagement.ModelView;
using static ParkingManagement.UtilityLayer.Utility;

namespace ParkingManagement.BusinessLayer
{
    public class Business
    {
        public bool IsValidUser(string email, string password)
        {
            UserModel user = new DataAccess().IsValidUser(email, password);
            if (user != null)
            {
                SessionModel userSessionInfo = new SessionModel
                {
                    UserId = user.UserId,
                    Type = user.Type

                };
                UserSessionInfo= userSessionInfo;
 
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsEmailExists(string email)
        {
            return new DataAccess().IsEmailExists(email);
        }

        public bool SaveUser(UserModel model)
        {
            return new DataAccess().SaveUser(model);
        }

        public List<ParkingZoneModel> GetParkingZones()
        {
            return new DataAccess().GetParkingZones();
        }

        public List<ParkingSpaceModel> GetParkingSpacesForZones(int[] ParkingZoneIds)
        {
            return new DataAccess().GetParkingSpacesForZones(ParkingZoneIds);
        }

        public bool BookParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber)
        {
            return new DataAccess().BookParkingSpace(parkingSpaceId, vehicleRegistrationNumber);
        }
        public bool ReleaseParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber)
        {
            return new DataAccess().ReleaseParkingSpace(parkingSpaceId, vehicleRegistrationNumber);
        }

        public bool ReleaseAllParkingSpace()
        {
            return new DataAccess().ReleaseAllParkingSpace();
        }

        public List<ParkingZoneReportModel> GetParkingZoneReport(DateTime date)
        {
            return new DataAccess().GetParkingZoneReport(date);
        }

        public bool AddParkingZone(AddParkingZoneModel newParkingZone)
        {
            return new DataAccess().AddParkingZone(newParkingZone);
        }

        public bool AddParkingSpace(AddParkingSpaceModel newParkingSpace)
        {
            return new DataAccess().AddParkingSpace(newParkingSpace);
        }

        public bool IsParkingZoneTitleExists(string parkingZoneTitle)
        {
            return new DataAccess().IsParkingZoneTitleExists(parkingZoneTitle);
        }

        public bool EditParkingSpace(AddParkingSpaceModel editParkingSpace)
        {
            return new DataAccess().EditParkingSpace(editParkingSpace);
        }

    }

}
