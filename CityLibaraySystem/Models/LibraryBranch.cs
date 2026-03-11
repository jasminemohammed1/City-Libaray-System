using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibaraySystem.Extensions;
using CityLibaraySystem.Models.Enums;

namespace CityLibaraySystem.Models
{
    public class LibraryBranch : IDisplayable
    {
        public string BranchId { get; private set; } = null!;
        public string BranchName { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string OpeningHours { get; private set; } = null!;

        public Librarian Manager { get; private set; }= null!;

        private readonly List<BookCopy> _copies= new ();
        private readonly List<Member> _members = new();
        public IReadOnlyList<Member> Members => _members;
        public IReadOnlyList<BookCopy> Copies => _copies;

        //Public Property for all users manager + members
        public IReadOnlyList<LibraryUser> Users
        {
            get
            {
                List<LibraryUser> users = new List<LibraryUser> ();
                users.Add(Manager);
                for(int i=0; i<_members.Count; i++)
                {
                    users.Add(Members[i]);
                }
                return users;
            }
        }
        public LibraryBranch(string branchId, string address,string phone, string name, string openingHours , Librarian manager)
        {
            BranchId = branchId;
            Address = address;
            Phone = phone;
            BranchName = name;
            Manager = manager;
                
            
        }

        public Member RegisterMember(string name , string phone)
        {
            var mem = new Member (name, phone);
            _members.Add(mem);
            return mem;
        }

        public Member RegisterMember(string name, DateOnly? dob, string? email, string phone, DateOnly membershipDate)
        {
            var member = new Member(name,phone,dob,membershipDate,email);
            _members.Add(member);
            return member;
        }

        public Member FindMember(string MemberShipId)
        {
            string normalize = MemberShipId.NormalizedId();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].MembershipId== normalize)
                {
                    return _members[i];
                }
               
            }
            throw new InvalidOperationException("Member not found.");
        }

        public BookCopy FindCopy(string copyId)
        {
            string normalized = copyId.NormalizedId();
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].CopyId == normalized)
                    return _copies[i];
            }
            throw new InvalidOperationException("Book copy not found.");
        }

        public void AddBookCopy(BookCopy copy)
        {
            _copies.Add(copy);
        }

        public List<BookCopy> GetAvailableBookCopyies()
        {
            List<BookCopy> AvailList = new List<BookCopy>();
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].Status == BookCopyStatus.Available)
                {
                    AvailList.Add(_copies[i]);
                }
            }
            return AvailList;
        }


        public string ToDisplayString() => $@"ID : {BranchId}
Name : {BranchName}
Address : {Address}
Phone : {Phone}
Opening Hours : {OpeningHours}
Manager : {Manager.Name}
Total Members : {_members.Count}
Total Book Copies : {_copies.Count}";
    }






}

