using System.Collections.Generic;
using Diploma.Models;

namespace Diploma.Services.FacilityService
{
    public interface IFacilityService
    {
        // Получаем список всех объектов имущества
        IEnumerable<Facility> GetFacilities();
        // Получаем конкретный объект по id
        Facility GetFacility(int? id);
        // Добавляем новый объект имущества
        void CreateFacility(Facility facility);
        // Применяем изменения к уже существующему объекту
        void UpdateFacility(Facility facility);
        // Сохраняем изменения
        void SaveFacility();
    }
}
