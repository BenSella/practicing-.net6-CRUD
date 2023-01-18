using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BigBooksWeb.Models
{
    public class Category
    {
        [Key] 
        public int ID { get; set; }
        [Required, StringLength(10)]
        public string Name { get; set; }
        [DisplayName("Project Name")]
        public string DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
