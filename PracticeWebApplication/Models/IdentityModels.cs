
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PracticeWebApplication.Models
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

        public byte[] UserPhoto { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyConnection", throwIfV1Schema: false)
        {
        }

        public System.Data.Entity.DbSet<TeacherData> TeacherData { get; set; }
        public System.Data.Entity.DbSet<Course> Course { get; set; }
        public System.Data.Entity.DbSet<StudentData> StudentData { get; set; }
        public System.Data.Entity.DbSet<Subject> Subject { get; set; }


        public static ApplicationDbContext Create()
        {
             
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PracticeWebApplication.Models.MappingClass> MappingClasses { get; set; }
    }   
}