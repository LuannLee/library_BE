using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.ViewModels.Requests
{
    public class BorrowDetailViewModel
    {
        public Guid BookId { get; set; }

        public int Quantity { get; set; }

        public Status Status { get; set; }
    }
}
