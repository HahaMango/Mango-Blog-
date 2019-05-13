using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class CategoryJSON
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string DisplayName { get; set; }

    }
}
