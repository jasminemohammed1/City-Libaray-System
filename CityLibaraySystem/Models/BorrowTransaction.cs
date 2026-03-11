using CityLibaraySystem.Extensions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CityLibaraySystem.Models
{
  public class BorrowTransaction : IDisplayable
    {

        private static int _counter = 1000;
        private const decimal FinePerDay = 10m;
        private const string FormatDate = "dd/MM/yyyy";
        public int  BorrowTransactionId { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnedDate { get; private set; }
        public DateOnly BorrowedDate { get; private set; }
        public Member Member { get; private set; } = null!;
        public BookCopy BookCopy { get; private set; } = null!;

        public BorrowTransaction(Member member, BookCopy bookCopy , int loanDays)
        {
            BorrowTransactionId = ++_counter;
            Member = member;
            BookCopy = bookCopy;
            BorrowedDate = DateOnly.FromDateTime(DateTime.Today);
            ReturnedDate = null;
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
            
        }
        public bool IsReturned() => ReturnedDate.HasValue;


  

        public decimal CalculateFine()
        {
            DateOnly effective = ReturnedDate ?? DateOnly.FromDateTime(DateTime.Today);
            int overDueDays = effective.DayNumber - DueDate.DayNumber;
            return overDueDays > 0 ? overDueDays * FinePerDay : 0;
        }

        public decimal CalculateFine(DateOnly returnDate)
        {
            int overDueDays = returnDate.DayNumber - DueDate.DayNumber;
            return overDueDays > 0 ? overDueDays * FinePerDay : 0;
        }

        public void MarkReturned(DateOnly returnDate) => ReturnedDate = returnDate;


        public string ToDisplayString()
        {
            string status = ReturnedDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnedDate.HasValue ? ReturnedDate.Value.ToString(FormatDate) : "Not returned yet";
            string fineLine = fine > 0 ? $"{fine:F2} EGP" : "None";

            return $@"── Transaction #{BorrowTransactionId} ──────────────
Book      : {BookCopy.Book.Title}
Copy ID   : {BookCopy.CopyId}
Borrowed  : {BorrowedDate.ToString(FormatDate)}
Due       : {DueDate.ToString(FormatDate)}
Returned  : {returnInfo}
Status    : {status}
Fine      : {fineLine}";
        }


    }
}
