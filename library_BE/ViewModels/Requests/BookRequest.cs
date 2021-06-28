using library_BE.Enums;
using System;
using System.Collections.Generic;

namespace library_BE.ViewModels.Requests
{
    public class BookRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublishCompanyId { get; set; }

        public string PublishCompanyName { get; set; }

        public List<Guid> AuthorId { get; set; }
        public string AuthorNames { get; set; }
        public List<Guid> CategoryId { get; set; }
        public string CategoryNames { get; set; }

        public int PublishYear { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

       
}
}
