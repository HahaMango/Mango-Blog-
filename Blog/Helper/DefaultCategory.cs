using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using Blog.JSONEntity;

namespace Blog.Helper
{
    public class DefaultCategory
    {
        private readonly IConfiguration Configuration;
        private readonly List<Category> categorys;

        public DefaultCategory(IConfiguration configuration)
        {
            this.Configuration = configuration;

            int i = 0;
            List<Category> temp = new List<Category>();

            while (true)
            {
                string categoryName = Configuration[$"Category:{i}"];
                if (categoryName != null)
                {                    
                    temp.Add(new Category(i,categoryName));
                    i++;
                }
                else
                {
                    break;
                }
            }
            this.categorys = temp;
        }

        public List<Category> Categorys()
        {
            if (categorys == null)
                return null;
            return categorys;
        }
    }
}
