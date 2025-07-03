using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class IceCream
    {
        
        public int IceCreamId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Flavor is required.")]
        [StringLength(100, ErrorMessage = "Flavor cannot exceed 100 characters.")]
        public string? Flavor { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 9999999.99, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        //[Url(ErrorMessage = "Photo URL must be a valid URL.")]
     
        public string? PhotoUrl { get; set; }
    }

}

