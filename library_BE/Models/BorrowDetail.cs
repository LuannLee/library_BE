using library_BE.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_BE.Models
{
    [Table("BorrowDetails")]
    public class BorrowDetail
    {
        public Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        
        public Guid BorrowId { get; set; }
        [ForeignKey("BorrowId")]
        public virtual Borrow Borrow { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

    }
}
