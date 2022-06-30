using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Protocols;

namespace justine_webapp.Models
{
    public class Type
    {
        [Key]
        public int id {get; set;}
        [Required]
        [StringLength(100)]
        public string Name {get; set;}
        public item item { get; set; }
        public int itemID { get; set; }
    }
}