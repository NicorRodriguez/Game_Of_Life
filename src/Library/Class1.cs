using System.IO;

namespace PII_Game_Of_Life{

    public class celula{
        public bool state {get; set;}

        public bool imAlive(int neighboursAlive){
            if(state && neighboursAlive<2) this.state = false;
            if(state && neighboursAlive>3) this.state = false;
            if(!state && neighboursAlive==3) this.state = false;
            if(state && (neighboursAlive ==2 || neighboursAlive ==3) ) this.state = true;
            return this.state;
        }
    }
    public class Board{
        // public static celula[,] newBoard(int width, int height){ return new celula[width, height];}
        public celula[,] board;
        int boardWidth;
        int boardHeight;

        public celula[,] getBoard(){ return this.board; }

        public int width(){ return boardWidth; }
        public int height(){ return boardHeight; }

        public void importBoard(string path){
            string url = path;
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            this.boardHeight = contentLines.Length;
            this.boardWidth = contentLines[0].Length;
            celula[,] myBoard = new celula[contentLines.Length, contentLines[0].Length];
            for (int  y=0; y<contentLines.Length;y++){
                for (int x=0; x<contentLines[y].Length; x++){
                    celula mycell = new celula();
                    mycell.state = false;
                    if(contentLines[y][x]=='1'){ mycell.state = true; }
                    myBoard[x,y]=mycell;
                }
            }

            this.board = myBoard;
        }

        public int getNeighbours(int posX, int posY){

            int aliveNeighbors = 0;
            for (int i = posX-1; i<=posX+1;i++){
                for (int j = posY-1;j<=posY+1;j++){
                    if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && this.board[i,j].state)
                    {
                        aliveNeighbors++;
                    }
                }
            }

            return aliveNeighbors;
            
        }

    }

    public class Game{

    }
}
