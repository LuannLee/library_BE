using System;

namespace library_BE.ViewModels.Requests
{
    public class Category_BookRequest
    {
        public Guid CategoryId { get; set; }

        public Guid BookId { get; set; }
     
    }
}
