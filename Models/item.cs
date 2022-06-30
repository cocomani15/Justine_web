using System.ComponentModel.DataAnnotations;
using System;

namespace justine_webapp.Models
{
    public class item
    {
        public int Id  { get; set; }
        [Required]
        [StringLength(50)]
         public string Name { get; set; }
        
    }
}