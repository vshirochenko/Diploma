using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Diploma.Models;
using Diploma.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Diploma.DAL
{
    public class MunicipalityContext : IdentityDbContext<AppUser>
    {
        public MunicipalityContext() : base("MunicipalityContext") { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}