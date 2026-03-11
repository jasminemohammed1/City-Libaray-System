using CityLibaraySystem.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Models
{
    public class Book : IDisplayable
    {
        public string ISBN { get; private set; }
        public string AuthorName { get; private set; }

        public string Title { get; private set; }

        public int PublicationYear {  get; private set; }

        public string Category {  get; private set; }


        public Book(string isbn, string authorName,string title,int publicationYear,string category)
        {
            ISBN = isbn;
            AuthorName = authorName;
            Title = title;
            PublicationYear = publicationYear;
            Category = category;
        }
        public Book( string isbn,string title) : this(isbn,"UnKnown",title,0,"General")
        {

        }

        public string ToDisplayString() => $"[{ISBN}] \"{Title}\" by {AuthorName} ({PublicationYear}) — {Category}";


    }
}
