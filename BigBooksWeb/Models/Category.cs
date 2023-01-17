using System.ComponentModel.DataAnnotations;

namespace BigBooksWeb.Models
{
    public class Category
    {
        [Key , Required]
        public int ID { get; set; }
        public string Name { get; set; }    
        public string DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
