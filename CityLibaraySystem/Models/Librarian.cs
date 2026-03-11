using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Models
{
    public class Librarian : LibraryUser
    {
        public string LibrarianId { get; private set; } = null!;

        public decimal Salary { get; private set; }

        public DateOnly HireDate { get; private set; }

       public  Librarian(string librarianId, string name,decimal salay, DateOnly hireDate , string phone) : base (name, phone)
        {
            LibrarianId = librarianId;
            Salary = salay;
            HireDate = hireDate;
        }

        public override string ToDisplayString()
        {
          return $@"ID      : {LibrarianId}
Name    : {Name}
Phone   : {Phone}
Salary  : {Salary:C}
Hired   : {HireDate:dd/MM/yyyy}";
        }
    }
}
