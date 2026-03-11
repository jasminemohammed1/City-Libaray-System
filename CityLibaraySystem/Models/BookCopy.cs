using CityLibaraySystem.Extensions;
using CityLibaraySystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CityLibaraySystem.Models
{
    public class BookCopy : IDisplayable , IBorrowable
    {
        public string CopyId { get; private set; }
        public string Condition {  get; private set; }
        public BookCopyStatus Status { get; private set; }

        public Book Book { get; private set; }

        public BorrowTransaction? ActiveTransaction {  get; private set; }


        public BookCopy(string copyid, Book book , string condition = "Good")
        {
            CopyId = copyid;
            Condition = condition;
            Status = BookCopyStatus.Available;
            Book = book;
            
        }
        public bool IsAvailable()=> Status==BookCopyStatus.Available;

        public string ToDisplayString()
        {
            string avail = IsAvailable() ? "Available" : $"{Status}";
            return $"Copy [{CopyId}] — {Book.Title} | Condition: {Condition} | {avail}";
        }

        public void Borrow(Member member , int loanDays = 14)
        {
            if(!IsAvailable())
            {
                throw new InvalidOperationException($"Copy {CopyId} is not available (Status: {Status}).");


            }
            Status = BookCopyStatus.Borrowed;
             ActiveTransaction = new BorrowTransaction(member, this, loanDays);
            member.AddTransaction(ActiveTransaction);

        }

        public decimal Return()
        { if(ActiveTransaction == null)

            {
                throw new InvalidOperationException("No active transaction for this copy. ");
            }
         if(Status != BookCopyStatus.Borrowed)
            {
                throw new InvalidOperationException($"Copy {CopyId} is not currently borrowed.");
            }
            ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
            decimal fine = ActiveTransaction.CalculateFine();
            Status = BookCopyStatus.Available;
            ActiveTransaction = null;

            return fine;
        }

    }
}
