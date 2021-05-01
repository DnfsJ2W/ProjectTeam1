using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace PMSAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string StreetAddress { get; set; }




        public virtual ICollection<tblOrder> Orders { get; set; }
        public virtual ICollection<tblProductOrderPayment> ProductOrderPayments { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //solve cascading problem
            modelBuilder
        .Entity<tblProductOrder>()
            .HasOptional(e => e.ProductOrderPayments)
            .WithMany()
            .WillCascadeOnDelete(false);

            //change table name
            //modelBuilder.Entity<ApplicationUser>()
            //        .ToTable("tblRegistration", "dbo").Property(p => p.Id).HasColumnName("UserId");       //change table name
            //modelBuilder.Entity<ApplicationUser>()
            //        .ToTable("tblRegistration", "dbo").Property(p => p.Id).HasColumnName("UserId"); 

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<tblCategory> Categories { get; set; }
        public DbSet<tblOrder> Orders { get; set; }
        public DbSet<tblPayment> Payments { get; set; }
        public DbSet<tblProduct> Products { get; set; }
        public DbSet<tblProductOrder> ProductOrder { get; set; }
        public DbSet<tblProductOrderPayment> ProductOrderPayments { get; set; }
        public DbSet<tblTracking> Trackings { get; set; }
        public DbSet<tblUser> Registration { get; set; }


    }
}