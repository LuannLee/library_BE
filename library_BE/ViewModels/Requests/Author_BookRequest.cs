using System;

namespace library_BE.ViewModels.Requests
{
    public class Author_BookRequest
    {
        public Guid AuthorId { get; set; }
       
        public Guid BookId { get; set; }
    }

}
