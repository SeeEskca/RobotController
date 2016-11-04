using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace RobotController
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRobotMove<Robot>>().To<Robot>();
            Bind<IRobotReact>().To<Robot>();
        }
    }
}
