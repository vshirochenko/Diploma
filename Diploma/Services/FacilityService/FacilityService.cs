using System;
using System.Collections.Generic;
using Diploma.DAL.Repositories;
using Diploma.DAL.UOW;
using Diploma.Models;
using Ninject;

namespace Diploma.Services.FacilityService
{
    public class FacilityService : IFacilityService
    {
        private IMunicipalityUOW _municipalityUow;

        public IMunicipalityRepository<Facility> FacilityRepository { get; set; }

        [Inject]
        public FacilityService(IMunicipalityUOW uow)
        {
            this._municipalityUow = uow;
            FacilityRepository = uow.Facilites;
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return FacilityRepository.SelectAll();
        }

        public Facility GetFacility(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFacility(Facility facility)
        {
            throw new NotImplementedException();
        }

        public void SaveFacility()
        {
            throw new NotImplementedException();
        }
    }
}