//Patrick Lankford cis237 TR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);


            //Print the final results for both maze1 and maze2
            PrintMaze(maze1);
            Console.WriteLine("Results For Maze 1" + Environment.NewLine);
            PrintMaze(maze2);
            Console.WriteLine("Results For Maze 2" + Environment.NewLine);
            Console.ReadLine();       

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {

            int rowCount = 12;
            int columnCount = 12;
            char[,] transposedMaze = new char[columnCount, rowCount];

            //Transpose the maze1 into maze2 as transposedMaze
            for (int j = 0; j < 12; j++)
                for (int i = 0; i < 12; i++)
                    transposedMaze[j,i] = mazeToTranspose[i,j];

           // return the new transposed maze to maze 2 
            return transposedMaze;
        }  
        
        //Used for printing final results of both mazes
        static void PrintMaze(char[,] mazeToPrint)
        {
            int counter = 0;

            //Loop through the maze to print the current position
            foreach (char x in mazeToPrint)
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
        }     
    }
}
