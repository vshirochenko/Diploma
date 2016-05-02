using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }


        public virtual ICollection<Facility> Facilities { get; set; }
    }
}