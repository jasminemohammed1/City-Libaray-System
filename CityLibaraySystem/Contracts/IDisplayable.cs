using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Extensions
{ 
    //<summary>
    // Add this interface as every class print in its own style to apply 
    // the principle code to interface rather than implementation
    //</summary>


    internal interface IDisplayable
    {
        string ToDisplayString();
    }
}
