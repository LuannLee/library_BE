using library_BE.Enums;
using System;

namespace library_BE.ViewModels.Requests
{
    public class AuthorRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
