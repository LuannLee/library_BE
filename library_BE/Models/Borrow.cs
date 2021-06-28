using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace library_BE.Models
{
    [Table("Borrows")]
    public class Borrow
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime PayDate { get; set; }

        public string BorrowName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public StatusBorrow Status { get; set; }

        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }

        [JsonIgnore]
        public List<BorrowDetail> BorrowDetails { get; set; }
    }
}
