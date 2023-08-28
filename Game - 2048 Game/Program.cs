using System;
using System.Linq;
using System.Collections.Generic;

namespace Game___2048_Game
{

    class TwentyFortyEight
    {
        private int[,] board; 

        public int[,] Board 
        {
            get { return board; }  
            set { board = value; } 
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int SettingUpScore()
        {
            return 0;
        }

        public int[,] SettingUp()
        {
            Console.WriteLine("The Board:");
            Console.WriteLine();
            int[,] Board1 = CreateBoard();
            Printing2DArray(Board1);
            return Board1;
        }

        public void Printing2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int[,] CreateBoard()
        {
            int[,] TheBoard = new int[4, 4];
            Random rnd = new Random();
            int Position1Row = rnd.Next(0, 4);
            int Position1Coloumn = rnd.Next(0, 4);

            int Position2Row = rnd.Next(0, 4);
            int Position2Coloumn = rnd.Next(0, 4);
            bool equaltootherrandom = true;
            while (equaltootherrandom == true)
            {
                if (Position2Row != Position1Row || Position2Coloumn != Position1Coloumn)
                {
                    equaltootherrandom = false;
                }
                else
                {
                    Position2Row = rnd.Next(0, 4);
                    Position2Coloumn = rnd.Next(0, 4);
                }
            }
            TheBoard[Position1Row, Position1Coloumn] = 2;
            TheBoard[Position2Row, Position2Coloumn] = 2;
            return TheBoard;
        }

        public void AddingNewTile(int[,] Board)
        {
            bool TilePlaced = false;
            while (TilePlaced == false)
            {
                Random rnd = new Random();
                int Position1Row = rnd.Next(0, 4);
                int Position1Coloumn = rnd.Next(0, 4);
                if (Board[Position1Row, Position1Coloumn] == 0)
                {
                    Board[Position1Row, Position1Coloumn] = 2;
                    TilePlaced = true;
                    Console.WriteLine("Row " + Position1Row);
                    Console.WriteLine("Coloumn " + Position1Coloumn);

                }
            }
            
            
        }


        public int[] MovingAllTheNumbersLeft(int[] arr)
        {
            int change = 0;
            for (int i = (arr.Length - 1); i > -1; i--)
            {
                if (i != 0)
                {
                    if (arr[i] != 0 & arr[i - 1] == 0)
                    {
                        arr[i - 1] = arr[i];
                        arr[i] = 0;
                        change++;
                    }
                }

            }
            if (change != 0)
            {
                return MovingAllTheNumbersLeft(arr);
            }
            else
            {
                return arr;
            }
        }

        public int[] MovingAllTheNumbersRight(int[] arr)
        {
            int change = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    if (arr[i] != 0 & arr[i + 1] == 0)
                    {
                        arr[i + 1] = arr[i];
                        arr[i] = 0;
                        change++;
                    }
                }

            }
            if (change != 0)
            {
                return MovingAllTheNumbersRight(arr);
            }
            else
            {
                return arr;
            }

        }

        public int[] MovingAllTheNumbersDown(int[] arr)
        {
            int change = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    if (arr[i] != 0 & arr[i + 1] == 0)
                    {
                        arr[i + 1] = arr[i];
                        arr[i] = 0;
                        change++;
                    }
                }

            }
            if (change != 0)
            {
                return MovingAllTheNumbersDown(arr);
            }
            else
            {
                return arr;
            }
        }

        public int[] MoveingAllTheNumbersUp(int[] arr)
        {
            int change = 0;
            for (int i = (arr.Length - 1); i > -1; i--)
            {
                if (i != 0)
                {
                    if (arr[i] != 0 & arr[i - 1] == 0)
                    {
                        arr[i - 1] = arr[i];
                        arr[i] = 0;
                        change++;
                    }
                }

            }
            if (change != 0)
            {
                return MoveingAllTheNumbersUp(arr);
            }
            else
            {
                return arr;
            }
        }

        public int[] SeeingIfAnyNumbersCanCombine(int[] arr, string direction)
        {

            int CounterToSeeIfRestZeros = 0;
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != 0)
                {
                    CounterToSeeIfRestZeros++;
                }
            }

            if (CounterToSeeIfRestZeros > 1)
            {
                for (int i = 0; i < (arr.Length - 1); i++)
                {
                    if (arr[i + 1] == 0)
                    {
                        int NextFullNumIndex = 0;
                        for (int j = (i + 2); j < (arr.Length); j++)
                        {
                            if (arr[j] != 0)
                            {
                                NextFullNumIndex = j;
                                break;
                            }
                        }

                        if (arr[i] == arr[NextFullNumIndex])
                        {
                            Score = Score + (arr[i] * 2);
                            arr[i] = arr[i] * 2;
                            arr[NextFullNumIndex] = 0;
                            
                        }

                    }
                    else
                    {
                        if (arr[i] == arr[i + 1])
                        {
                            Score = Score + (arr[i] * 2);
                            arr[i] = arr[i] * 2;
                            arr[i + 1] = 0;
                        }
                    }

                }
            }


            if (direction == "Left")
            {
                int[] arr2 = MovingAllTheNumbersLeft(arr);
                return arr2;
            }
            else if (direction == "Right")
            {
                int[] arr2 = MovingAllTheNumbersRight(arr);
                return arr2;
            }
            else if (direction == "Down")
            {
                int[] arr2 = MovingAllTheNumbersDown(arr);
                return arr2;
            }
            else 
            {
                int[] arr2 = MoveingAllTheNumbersUp(arr);
                return arr2;
            }


        }

        public void PrecursorToSlide(int[,] arr, string Direction)
        {
            
            if (Direction == "Left")
            {
                Console.WriteLine("Left Slide");
            }
            else if (Direction == "Right")
            {
                Console.WriteLine("Right Slide");
            }
            else if (Direction == "Up")
            {
                Console.WriteLine("Up Slide");
            }
            else if (Direction == "Down")
            {
                Console.WriteLine("Down Slide");
            }

            if ((Direction == "Up") || (Direction == "Down"))
            {
                for (int ColID = 0; ColID < 4; ColID++)
                {
                    int[] CurrentRow = new int[4];
                    for (int RowID = 0; RowID < 4; RowID++)
                    {
                        CurrentRow[RowID] = Board[RowID,ColID];
                    }

                    int[] NewSlideRow = null;
                    

                    if (Direction == "Up")
                    {
                        (NewSlideRow) = SeeingIfAnyNumbersCanCombine(CurrentRow, "Up");
                    }
                    else if (Direction == "Down")
                    {
                        (NewSlideRow) = SeeingIfAnyNumbersCanCombine(CurrentRow, "Down");
                    }


                    for (int RowID = 0; RowID < 4; RowID++)
                    {
                        Board[RowID, ColID] = NewSlideRow[RowID];
                    }
                }
            }
            else
            {
                for (int RowID = 0; RowID < 4; RowID++)
                {
                    int[] CurrentRow = new int[4];
                    for (int ColID = 0; ColID < 4; ColID++)
                    {
                        CurrentRow[ColID] = Board[RowID, ColID];
                    }

                    int[] NewSlideRow = null;
                    
                    if (Direction == "Left")
                    {
                        (NewSlideRow) = SeeingIfAnyNumbersCanCombine(CurrentRow, "Left");
                    }
                    else if (Direction == "Right")
                    {
                        (NewSlideRow) = SeeingIfAnyNumbersCanCombine(CurrentRow, "Right");
                    }


                    for (int ColID = 0; ColID < 4; ColID++)
                    {
                        Board[RowID, ColID] = NewSlideRow[ColID];
                    }
                }


            }
            AddingNewTile(arr);
            Console.WriteLine("Your Score: " + Score );
        }



    }

    class Program
    {

        static void Main(string[] args)
        {
            TwentyFortyEight MyObj = new TwentyFortyEight();
            MyObj.Board = MyObj.SettingUp();
            bool GameInProgress = true;
            while (GameInProgress == true)
            {
                string Direction = Console.ReadLine();
                if (Direction == "end")
                {
                    break;
                }
                else if (Direction == "Up" || Direction == "Down" || Direction == "Right" || Direction == "Left")
                {
                    MyObj.PrecursorToSlide(MyObj.Board, Direction);
                    MyObj.Printing2DArray(MyObj.Board);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

        }
    }
}
