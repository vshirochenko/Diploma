using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.DAL.Repositories;
using Diploma.Models;

namespace Diploma.DAL.UOW
{
    public interface IMunicipalityUOW
    {
        IMunicipalityRepository<Facility> Facilites { get; }
        IMunicipalityRepository<Owner> Owners { get; }
        IMunicipalityRepository<Address> Addresses { get; }

        // Save pending changes to database
        void SaveChanges();
    }
}
