using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController
{
    public class Controller
    {
        IRobotMove<Robot> _irob;
        IRobotReact _ireact;
        //int gridInitializer;
        Grid grid;

        //public Controller()
        //{
        //    _irob = new Robot();
        //    _ireact = new Robot();
        //}
        public Controller(IRobotMove<Robot> robotmove, IRobotReact react)
        {
            _irob = robotmove;
            _ireact = react;
           // grid = new Grid(gridInitializer);
        }
        public void moveRobot(Robot rb)
        {
            _irob.move(rb, grid);
        }

        public void initializeGrid(int dim)
        {
            grid = new Grid(dim);
        }
        public Robot startRobot(int xCord, int yCord, string commandStr)
        {
            Robot rb = new Robot();
            rb.startX = xCord;
            rb.startY = yCord;
            rb.commandString = commandStr;

            return rb;
        }
    }
}
