using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Blog.Helper
{
    public class DefaultCategory
    {
        private readonly IConfiguration Configuration;
        private readonly List<string> categorys;

        public DefaultCategory(IConfiguration configuration)
        {
            this.Configuration = configuration;

            int i = 0;
            List<string> temp = new List<string>();

            while (true)
            {
                string categoryName = Configuration[$"Category:{i}"];
                if (categoryName != null)
                {
                    temp.Add(categoryName);
                    i++;
                }
                else
                {
                    break;
                }
            }
            this.categorys = temp;
        }

        public List<string> Categorys()
        {
            if (categorys == null)
                return new List<string>();  
            return categorys;
        }
    }
}
