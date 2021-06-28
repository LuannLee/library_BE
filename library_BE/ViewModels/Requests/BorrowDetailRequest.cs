using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.ViewModels.Requests
{
    public class BorrowDetailRequest
    {
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public Guid BorrowId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
