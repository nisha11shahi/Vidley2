﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidley2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }

        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<CustomerMovieRental> CustomerMovieRentals { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<StaffAddress> StaffAddresses { get; set; }
        public DbSet<StaffPhoneNumber> StaffPhoneNumbers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}