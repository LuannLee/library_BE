using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.ViewModels.Entities
{
    public class BorrowDetailViewModel
    {

        public Guid Id { get; set; }
        public Guid BookId { get; set; }

        public Guid BorrowId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
