using ParkingManagement.ModelView;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ParkingManagement.UtilityLayer.Utility;

namespace ParkingManagement.DataAccessLayer
{
    public class DataAccess
    {
        public UserModel IsValidUser(string email, string password)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var user = context.Users.FirstOrDefault(u => u.Email == email);
                    if (user != null && user.Password == password)
                    {
                        return new UserModel
                        {
                            UserId = user.UserId,
                            Type = user.Type,
                        };

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;

            }
        }

        public bool IsEmailExists(string email)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    return context.Users.Any(u => u.Email == email);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }

        }

        public bool SaveUser(UserModel model)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    context.Users.Add(new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Type = model.Type,

                    });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public List<ParkingZoneModel> GetParkingZones()
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var parkingZones = context.ParkingZones
                        .Select(p => new ParkingZoneModel
                        {
                            ParkingZoneId = p.ParkingZoneId,
                            ParkingZoneTitle = p.ParkingZoneTitle
                        })
                        .ToList();

                    return parkingZones;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<ParkingZoneModel>();
            }
        }


        public List<ParkingSpaceModel> GetParkingSpacesForZones(int[] ParkingZoneIds)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var parkingSpaces = context.ParkingSpaces
                        .Where(p => ParkingZoneIds.Contains(p.ParkingZoneId))
                        .OrderBy(p => p.ParkingZoneId)
                        .ThenBy(p => p.ParkingSpaceId)
                        .Select(p => new ParkingSpaceModel
                        {
                            ParkingSpaceId = p.ParkingSpaceId,
                            ParkingSpaceTitle = p.ParkingSpaceTitle,
                            ParkingZoneId = p.ParkingZoneId,
                            IsOccupied = context.VehicleParkings
                                    .Where(vp => vp.ParkingSpaceId == p.ParkingSpaceId && vp.ReleaseDateTime == null)
                                    .Any(),
                            VehicleRegistrationNumber = context.VehicleParkings
                                    .Where(vp => vp.ParkingSpaceId == p.ParkingSpaceId && vp.ReleaseDateTime == null)
                                    .OrderByDescending(vp => vp.BookingDateTime)
                                    .Select(vp => vp.VehicleRegistrationNumber)
                                    .FirstOrDefault()
                        }).ToList();

                    return parkingSpaces;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<ParkingSpaceModel>();
            }
        }

        public bool BookParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    //check if parking space exists or not
                    var parkingSpace = context.ParkingSpaces.FirstOrDefault(ps => ps.ParkingSpaceId == parkingSpaceId);
                    if (parkingSpace == null)
                    {
                        return false;
                    }
                    //check if parking space is already occupied
                    if (context.VehicleParkings.Any(vp => vp.ParkingSpaceId == parkingSpaceId && vp.ReleaseDateTime == null))
                    {
                        return false;
                    }

                    int parkingZoneId = parkingSpace.ParkingZoneId;
                    context.VehicleParkings.Add(new VehicleParking
                    {
                        ParkingZoneId = parkingSpace.ParkingZoneId,
                        ParkingSpaceId = parkingSpaceId,
                        BookingDateTime = DateTime.Now,
                        VehicleRegistrationNumber = vehicleRegistrationNumber
                    });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public bool ReleaseParkingSpace(int parkingSpaceId, string vehicleRegistrationNumber)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var latestBooking = context.VehicleParkings
                        .Where(vp => vp.ParkingSpaceId == parkingSpaceId && vp.ReleaseDateTime == null)
                        .OrderByDescending(vp => vp.BookingDateTime)
                        .FirstOrDefault();

                    if (latestBooking == null || latestBooking.VehicleRegistrationNumber != vehicleRegistrationNumber)
                    {
                        return false;
                    }
                    latestBooking.ReleaseDateTime = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public List<ParkingZoneReportModel> GetParkingZoneReport(DateTime date)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var report = context.VehicleParkings
                        .Where(vp => vp.BookingDateTime.HasValue && DbFunctions.TruncateTime(vp.BookingDateTime.Value) == date.Date)
                        .GroupBy(vp => new { vp.ParkingZoneId, vp.ParkingSpaceId })
                        .Select(g => new ParkingZoneReportModel
                        {
                            ParkingZoneId = g.Key.ParkingZoneId,
                            ParkingSpaceId = g.Key.ParkingSpaceId,
                            NumberOfBookings = g.Count(),
                            IsVehicleParked = g.Any(vp => vp.ReleaseDateTime == null)
                        })
                        .ToList();

                    var result = report.Select(r => new ParkingZoneReportModel
                    {
                        ParkingZoneId = r.ParkingZoneId,
                        ParkingSpaceId = r.ParkingSpaceId,
                        ParkingZoneTitle = context.ParkingZones.FirstOrDefault(pz => pz.ParkingZoneId == r.ParkingZoneId)?.ParkingZoneTitle,
                        ParkingSpaceTitle = context.ParkingSpaces.FirstOrDefault(ps => ps.ParkingSpaceId == r.ParkingSpaceId)?.ParkingSpaceTitle,
                        NumberOfBookings = r.NumberOfBookings,
                        IsVehicleParked = r.IsVehicleParked
                    }).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return new List<ParkingZoneReportModel>();
            }
        }

        public bool AddParkingZone(AddParkingZoneModel newParkingZone)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var parkingZone = new ParkingZone
                    {
                        ParkingZoneTitle = newParkingZone.ParkingZoneTitle,
                    };
                    context.ParkingZones.Add(parkingZone);
                    context.SaveChanges();

                    if (parkingZone.ParkingZoneId > 0)
                    {
                        var parkingSpaceTitles = Enumerable.Range(1, newParkingZone.NumberOfSpaces).Select(i => $"{newParkingZone.ParkingZoneTitle}{i:D2}");

                        foreach (var title in parkingSpaceTitles)
                        {
                            var parkingSpace = new ParkingSpace
                            {
                                ParkingSpaceTitle = title,
                                ParkingZoneId = parkingZone.ParkingZoneId,
                            };
                            context.ParkingSpaces.Add(parkingSpace);
                        }
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public bool AddParkingSpace(AddParkingSpaceModel newParkingSpace)
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {
                    var lastParkingSpace = context.ParkingSpaces
                        .Where(p => p.ParkingZoneId == newParkingSpace.SelectedZoneId)
                        .OrderByDescending(p => p.ParkingSpaceId)
                        .FirstOrDefault();


                    if (lastParkingSpace != null)
                    {
                        var regex = new Regex(@"^([A-Za-z]+)(\d+)$");
                        var match = regex.Match(lastParkingSpace.ParkingSpaceTitle);
                        if (match.Success)
                        {
                            var zoneTitle = match.Groups[1].Value;
                            var lastSpaceNumber = int.Parse(match.Groups[2].Value) + 1;
                            for (int i = 0; i < newParkingSpace.NumberOfSpaces; i++)
                            {
                                var parkingSpace = new ParkingSpace
                                {

                                    ParkingSpaceTitle = $"{zoneTitle}{lastSpaceNumber:D2}",
                                    ParkingZoneId = newParkingSpace.SelectedZoneId
                                };
                                context.ParkingSpaces.Add(parkingSpace);
                                lastSpaceNumber++;

                            }
                            context.SaveChanges();
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }

        public bool IsParkingZoneTitleExists(string parkingZoneTitle)
        {
            using (var context = new ParkingManagementEntities())
            {
                return context.ParkingZones.Any(p => p.ParkingZoneTitle == parkingZoneTitle);               

            }
        }

        public bool ReleaseAllParkingSpace()
        {
            try
            {
                using (var context = new ParkingManagementEntities())
                {

                    var parkedVehicles = context.VehicleParkings.Where(vp => vp.ReleaseDateTime == null).ToList();
                    foreach (var vehicle in parkedVehicles)
                    {
                        vehicle.ReleaseDateTime = DateTime.Now;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return false;
            }
        }
    }

}
