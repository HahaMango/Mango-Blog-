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
        private readonly List<Category_JSON> categorys;

        public DefaultCategory(IConfiguration configuration)
        {
            this.Configuration = configuration;

            int i = 0;
            List<Category_JSON> temp = new List<Category_JSON>();

            while (true)
            {
                string categoryName = Configuration[$"Category:{i}"];
                if (categoryName != null)
                {                    
                    temp.Add(new Category_JSON(i,categoryName));
                    i++;
                }
                else
                {
                    break;
                }
            }
            this.categorys = temp;
        }

        public List<Category_JSON> Categorys()
        {
            if (categorys == null)
                return null;
            return categorys;
        }
    }
}
