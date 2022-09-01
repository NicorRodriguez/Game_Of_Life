using System;
using System.Text;
using System.Threading;

namespace PII_Game_Of_Life{
    class Program{
        public static void showBoard(Board myBoard){
            StringBuilder s = new StringBuilder();
            Console.Clear();
            for (int y = 0; y<myBoard.height();y++)
            {
                for (int x = 0; x<myBoard.width(); x++)
                {
                    if(myBoard.getBoard()[x, y].state)
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
        }

        static void Main(string[] args)
        {
            Board myBoard = new Board();
            myBoard.importBoard("../../assets/board2.txt");

            Board myNewBoard = new Board();

            myNewBoard.importBoard("../../assets/board2.txt");

            showBoard(myBoard);

            Console.WriteLine(myBoard.height());
            Console.WriteLine(myBoard.width());

            while(true){
                for(int x = 0; x < myBoard.width(); x++){
                    for(int y = 0; x < myBoard.height(); y++){

                        int aliveNeighbors = myBoard.getNeighbours(x, y);

                        myNewBoard.board[x,y].state = myBoard.board[x,y].imAlive(aliveNeighbors);


                    }
                }

                myBoard = myNewBoard;

                showBoard(myBoard);

                Thread.Sleep(300);
            }
        }

        
    }
}
