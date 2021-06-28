using library_BE.Enums;
using System;
using System.Collections.Generic;

namespace library_BE.ViewModels.Requests
{
    public class BorrowRequest
    {
        public Guid Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime PayDate { get; set; }
        public string BorrowName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public StatusBorrow Status { get; set; }

        public Guid ReaderId { get; set; }
        public string ReaderName { get; set; }
        
        public List<BorrowDetailViewModel> BorrowDetail { get; set; }

        public List<Guid> BookId { get; set; }
        public string BookName { get; set; }
    }
}
