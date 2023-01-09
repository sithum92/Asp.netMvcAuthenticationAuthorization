using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Asp.netMvcAuthenticationAuthorization.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {  //Add Custom Fields For Registration
        [Required]
        [Display(Name = "Staff No")]
        public string StaffNo { get; set; }


        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "NIC")]
        public string NIC { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Join Date")]
        public string JoinDate { get; set; }

        [Required]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Asp.netMvcAuthenticationAuthorization.Models.RoleViewModel> RoleViewModels { get; set; }
    }

    //1.1 first step
    //Custom Code By Sithum 
    //for Create a role with asp.net identity
    public class ApplicationRole : IdentityRole
    { 
         public ApplicationRole() : base() { }
        public ApplicationRole(string roleName):base(roleName) { }
    }

}