using CityLibaraySystem.Extensions;
using CityLibaraySystem.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Services
{
    public class LibraryService
    {
        private readonly LibraryBranch _branch;
        private readonly DisplayService _display;
        public LibraryService(LibraryBranch branch, DisplayService display)
        {
            _branch = branch;
            _display = display;
        }
        public void HandleBorrow()
        {
            string memberId = ThemeHelper.Prompt("Member ID").NormalizedId();
            Member member = _branch.FindMember(memberId);

            _display.ShowAvailableCopies(_branch);

            string copyId = ThemeHelper.Prompt("Copy ID to borrow").NormalizedId();
            BookCopy copy = _branch.FindCopy(copyId);

            copy.Borrow(member);
            _display.ShowBorrowSuccess(copy, member);
        }
        public void HandleReturn()
        {
            string copyId = ThemeHelper.Prompt("Copy ID to return").NormalizedId();
            BookCopy copy = _branch.FindCopy(copyId);

            decimal fine = copy.Return();
            _display.ShowReturnSuccess(copy, fine);
        }
        public void HandleHistory()
        {
            string memberId = ThemeHelper.Prompt("Member ID").NormalizedId();
            Member member = _branch.FindMember(memberId);
            _display.ShowMemberHistory(member);
        }
        public void HandleRegisterMember()
        {
            string name = ThemeHelper.Prompt("Full Name");

            string phone = ThemeHelper.Prompt("Phone Number");
            if (!phone.ContainsDigit())
                throw new InvalidOperationException("Phone number must contain at least one digit.");

            string email = ThemeHelper.Prompt("Email Address");
            if (!email.IsValidEmail())
                throw new InvalidOperationException("Invalid email format. Must contain '@' and '.'.");

            Member member = _branch.RegisterMember(name, null, email, phone, DateOnly.FromDateTime(DateTime.Now));
            _display.ShowRegistrationSuccess(member);
        }

    }
}
