using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class Address
    {
        [Key, ForeignKey("Facility")]
        public int FacilityId { get; set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        [DisplayName("Населенный пункт")]
        public string Locality { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        [DisplayName("Улица")]
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        [DisplayName("Номер дома")]
        public int? HouseNumber { get; set; }


        public virtual Facility Facility { get; set; }
    }
}