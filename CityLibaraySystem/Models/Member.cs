using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Models
{
    public class Member : LibraryUser
    {
        private static  int _counter = 1;
        public string MembershipId {  get; private  set; }

       public DateOnly? DateOfBirth { get; private set; }

       public  DateOnly MemberShipDate { get; private set; }
        public string? Email {  get; private set; }

        private readonly List<BorrowTransaction> _transactions = new ();
        public IReadOnlyList<BorrowTransaction> Transactions
        {
            get { 
                return _transactions;
            } 
        }

        public Member(string name , string phone , DateOnly? dob, DateOnly memberShipDate, string? email) : base(name , phone)
        {
            MembershipId = $"MEN-{_counter++:D3}";
            DateOfBirth = dob;
            MemberShipDate = memberShipDate;
            Email = email;
        }

        public Member(string name, string phone) : this(name, phone, null, DateOnly.FromDateTime(DateTime.Today), null)
        {

        }

        public void AddTransaction(BorrowTransaction tran) => _transactions.Add(tran);
        public override string ToDisplayString() => $@"ID      : {MembershipId}
Name    : {Name}
Phone   : {Phone}
Email   : {Email ?? "N/A"}
Joined  : {MemberShipDate:dd/MM/yyyy}
Borrows : {Transactions.Count}";




        public string GetHistoryDisplayString()
        {
           
            if(Transactions.Count ==0)
            {
                return "  No transactions found";
            }
            var sb = new StringBuilder();
            for(int i=0;i<Transactions.Count;i++)
            {
                sb.AppendLine( Transactions[i].ToDisplayString());
            }
            return sb.ToString();
        }







        
    }
}
