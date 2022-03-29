using Perseverance.Core.Data.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    public class RoverInfo
    {
        public RoverInfo()
        {
            Commands = new List<ICommand>();
        }
        public int Id { get; set; }

        public Coordinates Coordinates { get; set; }
        public List<ICommand> Commands { get; set; }
    }
}
