using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController
{
    public interface IRobotReact
    {
        void spin(char move, Robot bot);
        void dive(char move, Robot bot);
    }
}
