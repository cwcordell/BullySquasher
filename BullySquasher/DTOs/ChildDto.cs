﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BullySquasher.Models;

namespace BullySquasher.DTOs
{
    public class ChildDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Parent")]
        public string ParentId { get; set; }

        public IList<ChildDevice> ChildDevices { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}