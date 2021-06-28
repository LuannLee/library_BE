namespace library_BE.ViewModels.Requests
{
    public class CountBorrowRequest
    {
        public int CountBorrow { get; set; }
        public int CountBorrowActive { get; set; }
        public int CountBorrowInActive { get; set; }
        public int CountBorrowProcess { get; set; }
    }
}
