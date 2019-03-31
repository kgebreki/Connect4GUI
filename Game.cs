using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Kaleb Gebrekirstos 
 * Carrik McNerlin
 * */
namespace Connect4GUI
{
    //Model class checks to see if win/lose situation occurs. Appropriate variables and 
    //properties are also declared here. 
    [Serializable]
    class Game
    {
        private static int col;
        private static int row;
        private static int sizeRow;
        private static int sizeCol;
        public char currPlayer;//Character to keep track of current player (R/B)        
        public char[,] board = new char[sizeRow, sizeCol];//dynamic board matrix
        //Default constructor
        public Game()
        {
            row = 0;
            col = 0;
            currPlayer = ' ';
        }
        //Constructor
        public Game(int r, int c, char p)
        {
            row = r;
            col = c;
            currPlayer = p;
        }
        //Setter and getter for row 
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        //Setter and getter for col
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        //Setter and getter for sizeRow
        public int SizeRow
        {
            get { return sizeRow; }
            set { sizeRow = value; }
        }
        //Setter and getter for sizeCol
        public int SizeCol
        {
            get { return sizeCol; }
            set { sizeCol = value; }
        }
        //Function to initialize the board
        public void Initialize()
        {
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    board[i, j] = '_';
                }
            }
        }
        //Check method to see if there are 4 disks of the same color connected 
        public bool GameWon()
        {
            for (int row = 0; row < sizeRow; row++)
            {
                for (int col = 0; col < sizeCol; col++)
                {
                    //Used to make sure that the center position is the selected one
                    string verticalCheck = "";
                    string horizontalCheck = "";
                    string downLeftCheck = "";
                    string downRightCheck = "";

                    try
                    {
                        for (int i = -3; i < 4; i++)//grid across: -3, -2 -1, 0 (designated center, slightly off), 1, 2, 3
                        {
                            //Checks to see if four are connected horizontally/vertically/diagonally
                            if (row + i >= 0 && row + i < sizeRow)
                            {
                                verticalCheck += board[row + i, col];

                                if (verticalCheck.IndexOf("BBBB") != -1 || verticalCheck.IndexOf("RRRR") != -1)
                                    return true;
                            }

                            if (col + i >= 0 && col + i < sizeCol)
                            {
                                horizontalCheck += board[row, col + i];

                                if (horizontalCheck.IndexOf("BBBB") != -1 || horizontalCheck.IndexOf("RRRR") != -1)
                                    return true;
                            }

                            if (row + i >= 0 && row + i < sizeRow && col - i >= 0 && col - i < sizeCol)
                            {
                                downLeftCheck += board[row + i, col - i];

                                if (downLeftCheck.IndexOf("BBBB") != -1 || downLeftCheck.IndexOf("RRRR") != -1)
                                    return true;
                            }

                            if (row + i >= 0 && row + i < sizeRow && col + i >= 0 && col + i < sizeCol)
                            {
                                downRightCheck += board[row + i, col + i];

                                if (downRightCheck.IndexOf("BBBB") != -1 || downRightCheck.IndexOf("RRRR") != -1)
                                    return true;
                            }
                        } // End i
                    }
                    //Exception caught if the board size is changed after the game is saved
                    catch (Exception e)
                    {
                        System.Environment.Exit(1);
                    }

                }  // End col

            } // End row

            // All win options attempted, no win found
            return false;
        }

    }
}