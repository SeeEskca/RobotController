using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController
{
    public class Robot:IRobotMove<Robot>, IRobotReact
    {
        public int startX { get; set; }
        public int startY { get; set; }
        public string commandString { get; set; }
        private int[,] localGrid;
        

        public void spin(char move, Robot bot)
        {
            switch (move)
            {
                case 'l':
                    bot.startY++;//left move results in upward spin by 90 degree
                    break;
                case 'r':
                    bot.startY--;//rightward move results in downward spin by 90 degree
                    break;
                
            }
        }

        public void dive(char move, Robot bot)
        {
            switch (move)
            {
                case 'l':
                    bot.startX--;
                    break;
                case 'r':
                    bot.startX++;
                    break;
                case 'u':
                    bot.startY++;
                    break;
                case 'd':
                    bot.startY--;
                    break;
            }
        }

       

        public void move(Robot bot, Grid grid)
        {
           
            char move;
            string moveString = bot.commandString.Trim().ToLower();
            localGrid = grid.getGrid();

            if (bot.startX >= localGrid.GetLength(0) || bot.startY >= localGrid.GetLength(0))
            {
                //throw new ArgumentOutOfRangeException();//enable this for unit testing of this method
                Console.WriteLine("Start coordinates out of grid boundaries...terminated");
                return;
            }
            else if (bot.startX < 0 || bot.startY < 0)
            {
                // throw new ArgumentOutOfRangeException();//un comment this for unit testing of this method
                Console.WriteLine("Start coordinates out of grid boundaries...terminated");//throw new ArgumentOutOfRangeException();
                return;
            }


            for (int i = 0; i < moveString.Length; i++)
            {
                move = moveString[i];

                switch (move)
                {
                    case 'l':
                        bot.startX--;
                        if (!isSafeRobotStep(bot, move))
                            return;
                        break;
                    case 'r':
                        bot.startX++;
                        if (!isSafeRobotStep(bot, move))
                            return;
                        break;
                    case 'u':
                        bot.startY++;
                        if (!isSafeRobotStep(bot, move))
                            return;
                        break;
                    case 'd':
                        bot.startY--;
                        if (!isSafeRobotStep(bot, move))
                            return;
                        break;
                    default:
                        continue;

                }
            }


           
        }



        private bool isRock(int x, int y)
        {
            return localGrid[x, y] == 10;//rock locations contains 10
        }

        private bool isHole(int x, int y)
        {
            return localGrid[x, y] == 0;//holes contains zero
        }

        private bool isWithinGrid(int x, int y)
        {
            return x >= 0 && y < localGrid.GetLength(0);
        }

        private bool isSpinLocation(int x, int y)
        {
            return localGrid[x, y] == 5;
        }

        private bool isSafeDive(Robot bot, char move)
        {
            Console.Write("({0},{1} is a Hole) ", bot.startX, bot.startY);
            Console.WriteLine("Diving into hole!...");
            dive(move, bot);

            if (!isWithinGrid(bot.startX, bot.startY))
            {
                Console.Write("Dive into Hole, ({0},{1}) referenced none grid location...move terminated", bot.startX, bot.startY);
                return false;
            }
            else if (isRock(bot.startX, bot.startY))
            {
                Console.Write("Dive into Hole, ({0},{1}) terminated in Rock...move terminated", bot.startX, bot.startY);
                return false;
            }
            else
                Console.Write("({0},{1}) ", bot.startX, bot.startY);//location after hole

            return true;
        }

        private bool isSafeSpin(Robot bot, char move)
        {
            Console.Write("({0},{1} is a Spin) ", bot.startX, bot.startY);
            Console.WriteLine("Spinning to new Location!...");
            spin(move, bot);

            if (!isWithinGrid(bot.startX, bot.startY))
            {
                Console.Write("Spin, ({0},{1}) referenced none grid location...move terminated", bot.startX, bot.startY);
                return false;
            }
            else if (isRock(bot.startX, bot.startY))
            {
                Console.Write("Spin, ({0},{1}) terminated in Rock...move terminated", bot.startX, bot.startY);
                return false;
            }
            else
                Console.Write("({0},{1}) ", bot.startX, bot.startY);//location after spin

            return true;
        }
        private bool isSafeRobotStep(Robot bot, char move)
        {
            if (!isWithinGrid(bot.startX, bot.startY))
            {
                Console.Write("Move ({0},{1}) reference none grid location...move terminated", bot.startX, bot.startY);
                return false;
            }
            else if (isRock(bot.startX, bot.startY))
            {
                Console.WriteLine("The spot ({0},{1}), is a Rock. Cant move to this spot...", bot.startX, bot.startY);
                return false;
            }
            else if (isHole(bot.startX, bot.startY))
            {
                if (!isSafeDive(bot, move))
                    return false;

            }
            else if (isSpinLocation(bot.startX, bot.startY))
            {
                if (!isSafeSpin(bot, move))
                    return false;
            }
            else
                Console.Write("({0},{1}) ", bot.startX, bot.startY);

            return true;
        }

    }
}
