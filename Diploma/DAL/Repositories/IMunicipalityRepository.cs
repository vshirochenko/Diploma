using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DAL.Repositories
{
    public interface IMunicipalityRepository<T> where T : class
    {
        // Получаем все элементы из базы
        IQueryable<T> SelectAll();
        // Получаем конкретный элемент по признаку
        T SelectByID(object id);
        // Вставляем элемент
        void Insert(T entity);
        // Обновляем элемент
        void Update(T entity);
        // Удаляем элемент
        void Delete(T entity);
        // Удаляем элемент по id
        void Delete(int id);
        // Сохраняем изменения
        void Save();
    }
}
