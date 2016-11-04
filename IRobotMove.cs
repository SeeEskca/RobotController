using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController
{
    public interface IRobotMove<in T>
    {
        void move(T bot, Grid grid);
        
    }
}
