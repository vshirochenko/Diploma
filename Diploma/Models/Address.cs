using System;
using System.Collections.Generic;
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
        public string Locality { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public int HouseNumber { get; set; }


        public virtual Facility Facility { get; set; }
    }
}