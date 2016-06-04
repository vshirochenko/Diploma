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
        private readonly IMunicipalityUOW _municipalityUow;

        public IMunicipalityRepository<Facility> FacilityRepository { get; set; }
        [Inject]
        public AddressService.AddressService AddressService { get; set; }

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

        public Facility GetFacility(int? id)
        {
            return FacilityRepository.SelectByID(id);
        }

        public void CreateFacility(Facility facility)
        {
            FacilityRepository.Insert(facility);
            AddressService.CreateAddress(facility);
        }

        public void UpdateFacility(Facility facility)
        {
            FacilityRepository.Update(facility);
        }

        public void DeleteFacility(Facility facility)
        {
            // Сначала мы находим адрес, затем его удаляем
            Address address = AddressService.GetAddress(facility.Id);
            AddressService.DeleteAddress(address);
            AddressService.SaveAddress();
            // После этого удаляем сам объект
            FacilityRepository.Delete(facility);


        }

        public void SaveFacility()
        {
            _municipalityUow.SaveChanges();
        }
    }
}