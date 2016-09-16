using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullySquasher.Models
{
    public class ChildMessage
    {
        public int Id { get; set; }
        public ChildDevice ChildDevice { get; set; }
        [Required]
        public int ChildDeviceId { get; set; }
        public string Message { get; set; }
        public bool? IsBullyMessage { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}