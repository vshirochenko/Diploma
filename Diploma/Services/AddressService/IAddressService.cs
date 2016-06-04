using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.Models;

namespace Diploma.Services.AddressService
{
    public interface IAddressService
    {
        // Получаем адрес
        Address GetAddress(int? facilityId);

        // Создаем новый адрес
        // Причем заполняем значениями по ум.
        void CreateAddress(Facility facility);

        // Редактируем адрес
        void UpdateAddress(Address address);

        // Удаляем адрес
        void DeleteAddress(Address address);

        // Сохраняем изменения
        void SaveAddress();
    }
}
