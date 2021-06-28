using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace library_BE.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

        [JsonIgnore]
        public List<Author_Book> Author_Books { get; set; }
    }
}
