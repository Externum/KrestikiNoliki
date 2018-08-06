using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrestikiNoliki
{
    class Game
    {
        public int HorArea { get; private set; }
        public int VertArea { get; private set; }
        public string[,] area;
        private string firstPlayer = "X";
        private string secondPlayer = "O";
        public string Turn { get; private set; }
        private int numberTurns;
        private int cntHor;
        private int cntVert;
        private int leftDig;
        private int rightDig;

        public Game()
        {
            HorArea = 3;
            VertArea = 3;
            area = new string[HorArea, VertArea];
            for(int i = 0; i < HorArea; i++)
            {
                for(int j = 0; j < VertArea; j++)
                {
                    area[i, j] = null;
                }
            }
            Turn = firstPlayer;
            numberTurns = HorArea * VertArea;
        }

        public void ChangeTurn()
        {
            if(Turn == firstPlayer)
            {
                Turn = secondPlayer;
            }
            else
            {
                Turn = firstPlayer;
            }
        }

        public bool CheckFullArea()
        {
            numberTurns--;
            if(numberTurns == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveTurn(int btn, string turn)
        {
            int i = btn / 3;
            int j = btn % 3;
            area[i, j] = turn;
        }

        public bool CheckResult()
        {
            for(int i = 0; i < VertArea; i++)
            {
                cntHor = 0;
                for(int j = 0; j < HorArea; j++)
                {
                    if(area[i,j] == Turn)
                    {
                        cntHor++;
                        if(cntHor == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = 0; i < HorArea; i++)
            {
                cntVert = 0;
                for (int j = 0; j < VertArea; j++)
                {
                    if (area[j, i] == Turn)
                    {
                        cntVert++;
                        if (cntVert == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            rightDig = 0;
            leftDig = 0;
            for (int i = 0; i < 3; i++)
            {
                if (area[i, i] == Turn)
                {
                    rightDig++;
                }
                if (area[i, 2 - i] == Turn)
                {
                    leftDig++;
                }
            }
            if (rightDig == 3 || leftDig == 3)
            {
                return true;
            }

            return false;
        }
    }
}
