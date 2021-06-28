using library_BE.Enums;
using System;

namespace library_BE.ViewModels.Entities
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
