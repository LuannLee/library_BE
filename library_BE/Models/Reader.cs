using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace library_BE.Models
{
    [Table("Readers")]
    public class Reader
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

        [JsonIgnore]
        public List<Borrow> Brrows { get; set; }


    }
}
