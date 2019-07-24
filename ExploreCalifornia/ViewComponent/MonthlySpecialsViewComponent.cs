using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.ViewComponent
{
    /// <summary>
    ///  FOR A VIEW COMPONENT WE HAVE THREE OPTIONS
    ///  1. Create class with View Componenet Name
    ///  2. Decorate class with [ViewComponent]
    ///  3. Inherit :ViewComponent 
    ///  
    /// In this example I named the class as ViewComponent (option 1)
    /// </summary>
    public class MonthlySpecialsViewComponent
    {
        public string Invoke()
        {
            return "TODO: MONTHLY HELPERS";
        }

    }
}
