using library_BE.Interfaces;
using library_BE.Models;
using library_BE.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Implements
{
    public class BorrowService : IBorrowService
    {
        private readonly AppDbContext _context;

        public BorrowService(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<object> CreateBorrow(BorrowRequest request)
        {
            var reader = _context.Readers.FirstOrDefault(x => x.Id == request.ReaderId && (int)x.Status == 1);
            if (null == reader)
                return null;

            var borrow = new Borrow();
            borrow.Id = Guid.NewGuid();
            borrow.BorrowDate = DateTime.Now;
            borrow.PayDate = request.PayDate;
            borrow.CreatedDate = DateTime.Now;
            borrow.Status = (request.PayDate < DateTime.Today ? Enums.StatusBorrow.OutOfDate : Enums.StatusBorrow.Active);
            borrow.ReaderId = request.ReaderId;

            var readerName = (_context.Readers.FirstOrDefault(x => x.Id == request.ReaderId)).Name;
            borrow.BorrowName = (readerName + " - " + borrow.BorrowDate).ToString();

           foreach (var item in request.BorrowDetail)
            {
                var borrowDetail = new BorrowDetail();
                borrowDetail.BookId = item.BookId;
                borrowDetail.BorrowId = borrow.Id;
                borrowDetail.Status = item.Status;
                borrowDetail.Quantity = item.Quantity;

                _context.BorrowDetails.Add(borrowDetail);

                var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
                if (book.Quantity < borrowDetail.Quantity)
                    return null;
                book.Quantity = book.Quantity - borrowDetail.Quantity;

                _context.Books.Update(book);
            }

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            return borrow;
        }

        public async Task<bool> DeleteBorrow(string Id)
        {
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == borrow)
                return false;

            var borrowDetail = _context.BorrowDetails.Where(x => x.BorrowId.ToString() == Id).ToList();
           

            if(borrowDetail.Count() != 0)
            {
                _context.BorrowDetails.RemoveRange(borrowDetail);
                foreach (var item in borrowDetail)
                {
                    var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
                    book.Quantity = book.Quantity + item.Quantity;
                }
            }

            var pay = _context.Pays.FirstOrDefault(x => x.BorrowId.ToString() == Id);
            _context.Pays.Remove(pay);
                
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetBorrow()
        {
            var borrow = await _context.Borrows.ToListAsync();
            var borrowViewModels = new List<BorrowRequest>();

            foreach (var item in borrow)
            {
                var borrowViewModel = new BorrowRequest();
                borrowViewModel.Id = item.Id;
                borrowViewModel.ReaderId = item.ReaderId;
                borrowViewModel.ReaderName = (await _context.Readers.FirstOrDefaultAsync(x => x.Id == item.ReaderId)).Name;
                borrowViewModel.BorrowDate = item.BorrowDate;
                borrowViewModel.PayDate = item.PayDate;
                borrowViewModel.CreatedDate = item.CreatedDate;
                borrowViewModel.UpdatedDate = item.UpdatedDate;
                borrowViewModel.BorrowName = item.BorrowName;

                item.Status = (DateTime.Now > item.PayDate ? Enums.StatusBorrow.OutOfDate : item.Status);
                _context.Borrows.Update(item);
                await _context.SaveChangesAsync();

                borrowViewModel.Status = item.Status;

                
                borrowViewModels.Add(borrowViewModel);
            }

            if (null == borrowViewModels || 0 == borrowViewModels.Count())
                return null;
            return borrowViewModels;
        }

        public async Task<object> GetBorrowbyStatus()
        {
            var borrow = await _context.Borrows.Where(x => (int)x.Status == 1).ToListAsync();
            var borrowViewModels = new List<BorrowRequest>();

            foreach (var item in borrow)
            {
                var borrowViewModel = new BorrowRequest();
                borrowViewModel.Id = item.Id;
                borrowViewModel.ReaderId = item.ReaderId;
                borrowViewModel.ReaderName = (await _context.Readers.FirstOrDefaultAsync(x => x.Id == item.ReaderId)).Name;
                borrowViewModel.BorrowDate = item.BorrowDate;
                borrowViewModel.PayDate = item.PayDate;
                borrowViewModel.CreatedDate = item.CreatedDate;
                borrowViewModel.UpdatedDate = item.UpdatedDate;
                borrowViewModel.BorrowName = item.BorrowName;

                item.Status = (DateTime.Now > item.PayDate ? Enums.StatusBorrow.OutOfDate : item.Status);
                _context.Borrows.Update(item);
                await _context.SaveChangesAsync();

                borrowViewModel.Status = item.Status;


                borrowViewModels.Add(borrowViewModel);
            }

            if (null == borrowViewModels || 0 == borrowViewModels.Count())
                return null;
            return borrowViewModels;
        }

        public async Task<object> GetBorrowDetailByBorrow(BorrowRequest request)
        {
            var BorrowDetail = await _context.BorrowDetails.Where(x => x.BorrowId == request.Id).ToListAsync();
            return BorrowDetail;
        }

        public async Task<object> GetCountBorrow()
        {
            var borrow = await _context.Borrows.ToListAsync();
            var borrowActive = await _context.Borrows.Where(x => (int)x.Status == 1).ToListAsync();
            var borrowInActive = await _context.Borrows.Where(x => (int)x.Status == 0).ToListAsync();
            var borrowProcess = await _context.Borrows.Where(x => (int)x.Status == 2).ToListAsync();

            var count = new CountBorrowRequest();
            count.CountBorrow = borrow.Count();
            count.CountBorrowActive = borrowActive.Count();
            count.CountBorrowInActive = borrowInActive.Count();
            count.CountBorrowProcess = borrowProcess.Count();

            return count;
        }

        public async Task<object> UpdateBorrow(BorrowRequest request)
        {
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == request.Id);
            if (null == borrow)
                return null;

            var reader = _context.Readers.FirstOrDefault(x => x.Id == request.ReaderId && (int)x.Status == 1);
            if (null == reader)
                return null;

            borrow.UpdatedDate = request.UpdatedDate;
            borrow.Status = request.Status;
            borrow.ReaderId = request.ReaderId;
            borrow.PayDate = request.PayDate;

            // Xoá toàn bộ boroww detail
            var borrowDetailId = _context.BorrowDetails.Where(x => x.BorrowId == borrow.Id).ToList();

            foreach (var item in borrowDetailId)
            {
                var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
                book.Quantity = book.Quantity + item.Quantity;
            }

            _context.BorrowDetails.RemoveRange(borrowDetailId);
            await _context.SaveChangesAsync();


            //Cập nhật lại số lượng 
            foreach (var item in request.BorrowDetail)
            {
                var borrowDetail = new BorrowDetail();
                borrowDetail.BookId = item.BookId;
                borrowDetail.BorrowId = borrow.Id;
                borrowDetail.Status = item.Status;
                borrowDetail.Quantity = item.Quantity;

                _context.BorrowDetails.Add(borrowDetail);

                var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
                if (book.Quantity < borrowDetail.Quantity)
                    return null;
                book.Quantity = book.Quantity - borrowDetail.Quantity;

                _context.Books.Update(book);
            }

            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }
    }
}
