using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController
{
    public class Grid
    {
        private static int gridDimension;
        private int[,] grid;
        public  int xRock { get; set; }
        public int yRock { get; set; }
        public int xHole { get; set; }
        public int yHole { get; set; }

        private int rockPopulation=4;
        private int holePopulation=3;
        private int spinPopulation = 3;
        

        public Grid()
        {

        }
        public Grid(int Dimension)
        {
            gridDimension = Dimension;
            grid = new int[gridDimension, gridDimension];
            int rockCount = 0;
            int holeCount = 0;
            int spinCount = 0;
            Random rndrockHole = new Random();
           
            for(int i=0; i < gridDimension; i++)
            {
                for (int j = 0; j < gridDimension; j++)
                {
                    int rockhole = rndrockHole.Next(50);
                    
                    if (rockhole >= 30 && rockCount < rockPopulation)
                    {
                        grid[i, j] = 10;//this location signify a rock
                        rockCount++;
                    }
                    else if (rockhole >= 20 && rockhole < 30 && spinCount < spinPopulation)
                    {
                        grid[i, j] = 5;//this location a 90 degrees spin location change in y axis by 1
                       spinCount++;
                    }
                    else if (rockhole < 20 && holeCount < holePopulation)
                    {
                        grid[i, j] = 0;//this location signifies a hole
                        holeCount++;
                    }

                    else
                        grid[i, j] = 1;//this is a passable location
                }
                    
            }
        } 

        public int [,] getGrid()
        {
            return grid;
        }
        
    }
}
