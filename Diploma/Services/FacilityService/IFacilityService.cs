using System.Collections.Generic;
using Diploma.Models;

namespace Diploma.Services.FacilityService
{
    public interface IFacilityService
    {
        IEnumerable<Facility> GetFacilities();
        Facility GetFacility(int id);
        void CreateFacility(Facility facility);
        void SaveFacility();
    }
}
