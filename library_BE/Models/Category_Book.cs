using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Models
{
    [Table("Category_Books")]
    public class Category_Book
    {
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    } 
}
