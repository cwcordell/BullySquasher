using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BullySquasher.Models;

namespace BullySquasher.DTOs
{
    public class ChildSaveDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Parent")]
        public string ParentId { get; set; }
    }
}