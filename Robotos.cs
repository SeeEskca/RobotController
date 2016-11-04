using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace RobotController
{
    class program
    {

        /// <summary>
        /// sample input command string 'lllrllrrldluudlr'
        /// r-move right
        /// l-move left
        /// u-move up
        /// d- move down
        /// 
        /// hole- dive in hole and proceed to next connected node
        /// rock - terminate move
        /// spin - change y coordinates by 1 => 90 degrees spin
        /// 
        /// if none expected character is entered, input is ignored
        /// there is no regorous input validation on the command string
        /// 
        /// obtables: holes, rocks and spin areas are randomly inserted into the grid on
        /// 
        /// goto grid class to manually change obstacle distribution and concentration
        /// 
        /// 
        /// initialization of the in the grid contructor
        /// unit testing on principal move method in the robot class was successfully carried
        /// uncomment exception lines in robot class before testing unit test module
        /// comment out console output and return statement in exception area before unit testing
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
               

            IKernel kernel = new StandardKernel();
            kernel.Bind<IRobotMove<Robot>>().To<Robot>();
            kernel.Bind<IRobotReact>().To<Robot>();

            var control = kernel.Get<Controller>();

            Console.Write("Enter Grid Dimension:> ");
            int gridDimension = Convert.ToInt32(Console.ReadLine());
            control.initializeGrid(gridDimension);
            Console.Write("Enter starting XCord[less than dimension]:> ");
            int xcord = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter starting YCord[less than dimension]:> ");
            int ycord = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Command String[eg. lllrrldduurrlldru]:> ");
            string cmdString = Convert.ToString(Console.ReadLine());

            Robot rb = control.startRobot(xcord, ycord, cmdString);

            Console.WriteLine("Press any key to observe robot movement");
            Console.ReadLine();
            Console.Clear();
            control.moveRobot(rb);//initiate robot movement

            Console.ReadLine();
        }
    }
}
