using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("№ п/п")]
        public int PPNumber { get; set; }
        /// <summary>
        /// Реестровый порядковый номер объекта
        /// </summary>
        [DisplayName("Реестровый порядковый номер")]
        public string RegisterSerialNumber { get; set; }
        /// <summary>
        /// Наименование объекта
        /// </summary>
        [DisplayName("Наименование")]
        public string Name { get; set; }
        /// <summary>
        /// Кадастровый номер объекта
        /// </summary>
        [DisplayName("Кадастровый номер")]
        public string CadastralNumber { get; set; }
        /// <summary>
        /// Площадь объекта
        /// </summary>
        [DisplayName("Площадь объекта")]
        public double Square { get; set; }
        /// <summary>
        /// Балансовая стоимость объекта
        /// </summary>
        [DisplayName("Балансовая стоимость")]
        public double BalanceCost { get; set; }
        /// <summary>
        /// Статус объекта
        /// </summary>
        [DisplayName("Статус")]
        public string Status { get; set; }


        public virtual Address Address { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
    }
}