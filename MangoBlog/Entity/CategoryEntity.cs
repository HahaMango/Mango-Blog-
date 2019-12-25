using System.ComponentModel.DataAnnotations.Schema;

namespace MangoBlog.Entity
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string CategoryName { get; set; }
    }
}
