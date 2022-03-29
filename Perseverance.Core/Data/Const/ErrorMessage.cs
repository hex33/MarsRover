using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    public class ErrorMessage
    {
        #region
        internal const string ER_MATCH_PLATEAU = "Plateau size is not match";
        internal const string ER_MATCH_ROVER_COORDINATE = "Rover coordinates is not match";
        internal const string ER_MATCH_ROVER_COMAND = "Rover command is not match";

        internal const string ER_UNDEFINED_COMAND = "Undefined command";
        internal const string ER_ROVER_NOT_FOUND = "Rover not found";

        #endregion
    }
}
