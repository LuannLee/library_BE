using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace library_BE.Models
{
    [Table("Pays")]
    public class Pay
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime PayDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }


        public Guid? ReaderId { get; set; }
        public  Reader Reader { get; set; }

        public Guid? BorrowId { get; set; }
        public Borrow Borrow { get; set; }

    }
}
