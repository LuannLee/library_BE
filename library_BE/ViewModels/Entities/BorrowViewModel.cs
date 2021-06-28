using library_BE.Enums;
using System;

namespace library_BE.ViewModels.Entities
{
    public class BorrowViewModel
    {
        public Guid Id { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

        public Guid ReaderId { get; set; }
    }
}
