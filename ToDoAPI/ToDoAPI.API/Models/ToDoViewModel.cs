using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//added for validation

namespace ToDoAPI.API.Models
{
    public class ToDoViewModel
    {
        [Key]
        public int TodoId { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public bool Done { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual CategoryViewModel Category { get; set; }

    }

    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "** Max 50 characters")]
        public string CategoryName { get; set; }

        [StringLength(100, ErrorMessage = "** Max 100 characters")]
        public string CategoryDescription { get; set; }

    }
}
}