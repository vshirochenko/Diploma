using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diploma.DAL.Repositories;
using Diploma.DAL.UOW;
using Diploma.Models;
using Ninject;

namespace Diploma.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IMunicipalityUOW _municipalityUow;

        public IMunicipalityRepository<Address> AddressRepository { get; set; }

        [Inject]
        public AddressService(IMunicipalityUOW uow)
        {
            this._municipalityUow = uow;
            AddressRepository = uow.Addresses;
        }

        public Address GetAddress(int? facilityId)
        {
            return AddressRepository.SelectByID(facilityId);
        }

        public void CreateAddress(Facility facility)
        {
            Address address = new Address()
            {
                FacilityId = facility.Id,
                Facility = facility,
                HouseNumber = null,
                Locality = "",
                Street = ""
            };
            AddressRepository.Insert(address);
        }

        public void UpdateAddress(Address address)
        {
            AddressRepository.Update(address);
        }

        public void DeleteAddress(Address address)
        {
            AddressRepository.Delete(address);
        }

        public void SaveAddress()
        {
            _municipalityUow.SaveChanges();
        }
    }
}