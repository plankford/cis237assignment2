//Patrick Lankford cis237 TR

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
        int solved = 0;

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

            solved = 0;
            int facing = 0;

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

            printMaze(maze, xPos, yPos);

            maze[xPos, yPos] = 'X';

            /*
             * Stepping through the maze will check the current direction we are facing. Once the direction
             * is determined it will check if the spot in either direction is open. If the spot is open it
             * will move their and send the new position and direction back to the method to start over again. 
             * If no spot is open it will mark its position with a 0 and return to the previous position. This
             * will continue until it reach the base case which is the exit of the maze. once that is done it 
             * will return to the start point and back to start on the next maze.
             * */
            while (solved == 0)
            {
                //Test if at the exit of the maze - base case
                if ((xPos == 4) && (yPos == 11) || (xPos == 11) && (yPos == 4))
                {
                    //At the exit of the maze - set success high 
                    printMaze(maze, xPos, yPos);
                    solved = 1;                 
                    Console.WriteLine("You have solved this maze!!");
                    return;
                }
                else if (facing == 0)   //Facing Up
                {
                    if (maze[xPos,yPos + 1] == '.') //Try Right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move to the right
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Try Up
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 1); // Move up
                    }
                    else if (maze[xPos, yPos - 1] == '.') //Try Left
                    {
                        mazeTraversal(maze, xPos, yPos - 1, 3); // Move left
                    }
                    else if (maze[xPos +1, yPos] == '.') //Try Down
                    {
                        mazeTraversal(maze, xPos + 1, yPos, 2); // Move Down
                    }
                    else
                    {
                        //If no open positions mark the space with a 0 as a bad direction
                        if (solved == 0)
                        {
                            maze[xPos, yPos] = '0';
                        }
                        return;
                    }
                }
                else if (facing == 1)   //Facing Right
                {
                    if (maze[xPos, yPos + 1] == '.') //Try Right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move Right
                    }
                    else if (maze[xPos + 1, yPos] == '.') //Try Down
                    {
                        mazeTraversal(maze, xPos + 1, yPos, 2); // Move Down
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Try Up
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 0); // Move up
                    }
                    else if (maze[xPos, yPos - 1] == '.') //Try Left
                    {
                        mazeTraversal(maze, xPos, yPos - 1, 3); // Move left
                    }
                    else
                    {
                        //If no open positions mark the space with a 0 as a bad direction
                        if (solved == 0)
                        {
                            maze[xPos, yPos] = '0';
                        }
                        return;
                    }
                }
                else if (facing == 2)   //Facing Down
                {
                    if (maze[xPos + 1, yPos] == '.') //Try Down
                    {
                        mazeTraversal(maze, xPos + 1, yPos, 2); // Move down
                    }
                    else if (maze[xPos, yPos + 1] == '.') //Try Right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move right
                    }
                    else if (maze[xPos, yPos - 1] == '.') //Try Left
                    {
                        mazeTraversal(maze, xPos, yPos - 1, 3); // Move Left
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Try Up
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 0); // Move up
                    }
                    else
                    {
                        //If no open positions mark the space with a 0 as a bad direction
                        if (solved == 0)
                        {
                            maze[xPos, yPos] = '0';
                        }
                        return;
                    }
                }
                else if (facing == 3)   //Facing Left
                {
                    if (maze[xPos, yPos - 1] == '.') //Try Left
                    {
                        mazeTraversal(maze, xPos, yPos - 1, 3); // Move Left
                    }
                    else if (maze[xPos + 1, yPos] == '.') //Try Down
                    {
                        mazeTraversal(maze, xPos + 1, yPos, 2); // Move Down
                    }
                    else if (maze[xPos - 1, yPos] == '.') //Try Up
                    {
                        mazeTraversal(maze, xPos - 1, yPos, 0); // Move up
                    }
                    else if (maze[xPos, yPos + 1] == '.') //Try Right
                    {
                        mazeTraversal(maze, xPos, yPos + 1, 1); // Move right
                    }
                    else
                    {
                        //If no open positions mark the space with a 0 as a bad direction
                        if (solved == 0)
                        {
                            maze[xPos, yPos] = '0';
                        }
                        return;
                    }
                }
            }
    
        }

        public void printMaze(char[,] maze, int xPos, int yPos)
        {
            //Clear the current maze on the console
            Console.Clear();

            int counter = 0;

            //Loop through the maze to print the current position
            foreach (char x in maze)
            {
                //If at the edge of the maze add line to continue printing
                if (counter == 11)
                {
                    Console.WriteLine(x);
                    counter = 0;
                }
                //If not at the edge continue printing the current line
                else
                {
                    Console.Write(x);
                    counter++;
                }

            }
            //Delay to show current progress through the maze
            System.Threading.Thread.Sleep(500);
        }
    }
}
