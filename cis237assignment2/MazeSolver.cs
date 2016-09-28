using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            int facing = 1;

            mazeTraversal(maze, xStart, yStart, facing);

            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>

        private void mazeTraversal(char[,] maze, int xPos, int yPos, int facing)
        {
            //Pass in parameters to move(this is the recursive method)
            //Implement maze traversal recursive call

            char currentPosition = maze[xPos, yPos];

            maze[xPos, yPos] = '0';

            printMaze(maze, xPos, yPos);

            int success = 0;

            while (success == 0)
            {
                if ((xPos == 4) && (yPos == 11))
                {
                    //At the exit of the maze - set success high
                    success = 1;
                }
                else if (facing == 0)   //Facing Up
                {
                    if (maze[xPos,yPos + 1] == '.') //Check spot to the right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move to the right
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Check spot above
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 1); // Move up
                    }
                    else if (maze[xPos, yPos - 1] == '.') //Check spot to the left
                    {
                        mazeTraversal(maze, xPos, yPos - 1, 1); // Move left
                    }
                    else
                    {
                        success = 0;
                    }
                }
                else if (facing == 1)   //Facing Right
                {
                    if (maze[xPos + 1, yPos] == '.') //Check spot down
                    {
                        mazeTraversal(maze, xPos + 1, yPos, 2); // Move down
                    }
                    else if (maze[xPos, yPos + 1] == '.') //Check to the right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move right
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Check spot above
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 0); // Move up
                    }
                    else
                    {
                        success = 0;
                    }
                }
                else if (facing == 2)   //Facing Down
                {
                    
                }
                else if (facing == 3)   //Facing Left
                {
                    
                }
            }
    
        }

        private void printMaze(char[,] maze, int xPos, int yPos)
        {
            int counter = 0;

            foreach (char x in maze)
            {
                if (counter == 11)
                {
                    Console.WriteLine(x);
                    counter = 0;
                }
                else
                {
                    Console.Write(x);
                    counter++;
                }

            }
        }
    }
}
