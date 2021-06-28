using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_BE.Models
{
    [Table("Author_Books")]
    public class Author_Book
    {
        public Guid AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

    }
}
