﻿
namespace Multi_language.Models
{
    using Common.Consants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AppUser : IdentityUser
    {
        [StringLength(ValidationConstants.UserNames)]
        public string FirstName { get; set; }

        [StringLength(ValidationConstants.UserNames)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DateCreated { get; internal set; }
        public DateTime? DateModified { get; internal set; }

        public int? ActiveProject { get; set; }
        public string Secret { get; set; }

        public ApplicationTypes ApplicationType { get; set; }

        public bool Active { get; set; }

        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("ActiveProject", (this.ActiveProject??0).ToString()));
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("ActiveProject", (this.ActiveProject ?? 0).ToString()));

            return userIdentity;
        }
    }
}
