using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diploma.DAL.Repositories;
using Diploma.Models;

namespace Diploma.DAL.UOW
{
    public class MunicipalityUOW : IMunicipalityUOW, IDisposable
    {
        private MunicipalityContext DbContext { get; set; }

        #region Репозитории

        private IMunicipalityRepository<Facility> _facilities;
        private IMunicipalityRepository<Owner> _owners;
        private IMunicipalityRepository<Address> _addresses;

        public MunicipalityUOW()
        {
            CreateDbContext();
        }

        public IMunicipalityRepository<Facility> Facilites
        {
            get { return _facilities ?? (_facilities = new MunicipalityRepository<Facility>(DbContext)); }
        }

        public IMunicipalityRepository<Owner> Owners
        {
            get { return _owners ?? (_owners = new MunicipalityRepository<Owner>(DbContext)); }
        }


        public IMunicipalityRepository<Address> Addresses
        {
            get
            {
                return _addresses ?? (_addresses = new MunicipalityRepository<Address>(DbContext));
            }
        }

        #endregion

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        // TODO! Прочитать про параметры
        private void CreateDbContext()
        {
            DbContext = new MunicipalityContext();

            DbContext.Configuration.LazyLoadingEnabled = false;

            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }


        #region Освобождение памяти

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}