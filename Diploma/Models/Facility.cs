using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// № п/п объекта
        /// </summary>
        public int PPNumber { get; set; }
        /// <summary>
        /// Реестровый порядковый номер объекта
        /// </summary>
        public string RegisterSerialNumber { get; set; }
        /// <summary>
        /// Наименование объекта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Кадастровый номер объекта
        /// </summary>
        public string CadastralNumber { get; set; }
        /// <summary>
        /// Площадь объекта
        /// </summary>
        public double Square { get; set; }
        /// <summary>
        /// Балансовая стоимость объекта
        /// </summary>
        public double BalanceCost { get; set; }
        /// <summary>
        /// Статус объекта
        /// </summary>
        public string Status { get; set; }


        public virtual Address Address { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
    }
}