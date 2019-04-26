using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Helper
{
    public class SearchArgument
    {
        public string Title { get; set; }
        public DateTime? BeingTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Author { get; set; }
        public string[] Categories { get; set; }

        public bool IsNull()
        {
            return (Title == null)
                && (BeingTime == null)
                && (EndTime == null)
                && (Author == null)
                && (Categories == null);
        }
    }
}
