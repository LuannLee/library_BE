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
    public class BorrowDetailService : IBorrowDetailService
    {
        private readonly AppDbContext _context;

        public BorrowDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CreateBorrowDetail(BorrowDetailRequest request)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.BookId && (int)x.Status == 1);
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == request.BorrowId && (int)x.Status == 1);

            if (null == book || null == borrow)
                return null;

            var borrowDetail = new BorrowDetail();
            borrowDetail.BookId = request.BookId;
            borrowDetail.BorrowId = request.BorrowId;
            borrowDetail.Quantity = request.Quantity;
            borrowDetail.CreatedDate = request.CreatedDate;
            borrowDetail.Status = Enums.Status.Active;

            _context.BorrowDetails.Add(borrowDetail);
            await _context.SaveChangesAsync();

            return borrowDetail;
        }

        public async Task<bool> DeleteBorrowDetail(string Id)
        {
            //var borrowDetail = _context.BorrowDetails.FirstOrDefault(x => x.Id.ToString() == Id);
            //if (null == borrowDetail)
            //    return false;

            //_context.BorrowDetails.Remove(borrowDetail);
            //await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetBorrowDetail()
        {
            var borrowDetail = await _context.BorrowDetails.ToListAsync();
            var borrowDetailViewModels = new List<BorrowDetailRequest>();

            foreach (var item in borrowDetail)
            {
                var borrowDetailViewModel = new BorrowDetailRequest();
                borrowDetailViewModel.BookId = item.BookId;
                borrowDetailViewModel.BorrowId = item.BorrowId;
                borrowDetailViewModel.BookName = (_context.Books.FirstOrDefault(x => x.Id == item.BookId)).Name;
                borrowDetailViewModel.Quantity = item.Quantity;
                borrowDetailViewModel.CreatedDate = item.CreatedDate;
                borrowDetailViewModel.UpdatedDate = item.UpdatedDate;
                borrowDetailViewModel.Status = item.Status;

                borrowDetailViewModels.Add(borrowDetailViewModel);
            }


            if (null == borrowDetailViewModels || 0 == borrowDetailViewModels.Count())
                return null;
            return borrowDetailViewModels;
        }

        public async Task<object> UpdateBorrowDetail(BorrowDetailRequest request)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.BookId && (int)x.Status == 1);
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == request.BorrowId && (int)x.Status == 1);
            var borrowDetail = _context.BorrowDetails.FirstOrDefault(x => x.BorrowId == request.BorrowId && x. BookId == request.BookId);

            if (null == book || null == borrow || null == borrowDetail)
                return null;

            borrowDetail.BookId = request.BookId;
            borrowDetail.BorrowId = request.BorrowId;
            borrowDetail.Quantity = request.Quantity;
            borrowDetail.UpdatedDate = request.UpdatedDate;
            borrowDetail.Status = request.Status;

            _context.BorrowDetails.Update(borrowDetail);
            await _context.SaveChangesAsync();

            return borrowDetail;
        }
    }
}
