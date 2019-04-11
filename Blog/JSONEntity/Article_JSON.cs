using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class Article_JSON
    {
        public PageInfo_JSON PageInfo { get; set; }
        public PageContent_JSON PageContent { get; set; }
    }
}
