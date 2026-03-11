using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibaraySystem.Models;


namespace CityLibaraySystem.Extensions
{
    //<summary>
    // create a contract for the borrow capility so it will be used for any product 
    // not just book but if we add [ magzines, newspapers, ....] theses methods will behave different
   // </summary>
    internal interface IBorrowable
    {
        void Borrow(Member member, int loanDays = 14);
        bool IsAvailable();
        decimal Return();
    }
}
