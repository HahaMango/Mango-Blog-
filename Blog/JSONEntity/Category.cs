using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class Category
    {
        public Category(int id,string displayname)
        {
            this.Id = id;
            this.DisplayName = displayname;
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
