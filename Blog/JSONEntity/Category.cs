using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public Category(int id,string displayname)
        {
            this.Id = id;
            this.DisplayName = displayname;
        }

        public Category()
        {

        }    
    }
}
