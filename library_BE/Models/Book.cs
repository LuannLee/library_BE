using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace library_BE.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public int PublishYear { get; set; }
        
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

        [JsonIgnore]
        public List<Author_Book> Author_Books { get; set; }

        public Guid PublishCompanyId { get; set; }
        public PublishCompany PublishCompany { get; set; }

        [JsonIgnore]
        public List<Category_Book> Category_Books { get; set; }

        [JsonIgnore]
        public List<BorrowDetail> BorrowDetails { get; set; }

    }
}
