using library_BE.Enums;
using System;
using System.Collections.Generic;

namespace library_BE.ViewModels.Requests
{
    public class PayRequest
    {
        public Guid Id { get; set; }

        public DateTime PayDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string BorrowName { get; set; }

        public Status Status { get; set; }

        public Guid? ReaderId { get; set; }

        public string ReaderName { get; set; }

        public Guid? BorrowId { get; set; }
    }
}
