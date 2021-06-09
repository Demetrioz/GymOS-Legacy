using Microsoft.AspNetCore.Identity;
using System;

namespace GymOS.DataModel.Models.Identity
{
    public class GymOSUser : IdentityUser
    {
        private string Address { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string ZipCode { get; set; }
        private DateTimeOffset Birthdate { get; set; }
    }
}
