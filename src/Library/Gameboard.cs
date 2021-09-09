using System;

namespace PII_Game_Of_Life
{
    public class Gameboard
    {
        public bool [,] GameboardState;
        int boardWidth;
        int boardHeight;

        public Gameboard() 
        {
            this.GameboardState = Leerarchivo.Leertxt();
            int boardWidth = GameboardState.GetLength(0);
            int boardHeight = GameboardState.GetLength(1);
        }
        

        public void RunGame()
        {
            bool[,] cloneboard = new bool[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && GameboardState[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(GameboardState[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (GameboardState[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (GameboardState[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!GameboardState[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = GameboardState[x,y];
                    }
                }
            }
            GameboardState = cloneboard;
            cloneboard = new bool[boardWidth, boardHeight];
        }
    }
}