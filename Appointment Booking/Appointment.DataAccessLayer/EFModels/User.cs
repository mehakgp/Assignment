using System;
using System.Collections.Generic;

namespace Appointment.DataAccessLayer.EFModels;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Doctor? Doctor { get; set; }
}
