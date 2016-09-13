using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BullySquasher.Models
{
    public class ParentDevice
    {
        public int Id { get; set; }
       
        public string ParentId { get; set; }

        [Required]
        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public DeviceType DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}