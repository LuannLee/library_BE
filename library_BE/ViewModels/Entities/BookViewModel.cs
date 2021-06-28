using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.ViewModels.Entities
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid PublishCompanyId { get; set; }

        public int PublishYear { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
