using library_BE.Enums;
using System;

namespace library_BE.ViewModels.Entities
{
    public class PayViewModel
    {
        public Guid Id { get; set; }

        public DateTime PayDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }


        public Guid ReaderId { get; set; }
    }
}
