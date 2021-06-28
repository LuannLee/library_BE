using library_BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.ViewModels.Requests
{
    public class ReaderRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }
    }
}
