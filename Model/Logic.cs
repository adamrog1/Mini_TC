using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_MVVM.View;

namespace TicTacToe_MVVM.Model
{
    class Logic
    {
        private char[] buttons;
        private bool currplayer;
        private int X;
        private char mark;
        public Logic(char[] Buttons, char Mark, int x, bool PlayerTurn)
        {
            currplayer = PlayerTurn;
            buttons = Buttons;
            mark = Mark;
            X = x;
        }

        public (char[], char,bool) move()
        {
            
            if (buttons[X] == 'X' || buttons[X] == 'O') return (buttons, mark,currplayer);
            buttons[X] = mark;
            if (currplayer) { 
                currplayer = false;
                mark = 'X';
                return (buttons, mark,currplayer);
            }
            else {
                currplayer = true;
                mark = 'O';
                return (buttons, mark,currplayer);

            }
            
        }

        private void startnewgame()
        {
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = ' ';
            }
        }

        private void whowon(int i)
        {

            string winner;
            if (i == 1) winner = "remis";
            else
            {
                if (currplayer) winner = "X";
                else winner = "O";
            }
            Window1 popup = new Window1(winner);
            popup.Show();
        }






        public bool checkforawin(object obj)
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i] == buttons[i + 3] && buttons[i] == buttons[i + 6] &&
                    (buttons[i] == 'X' || buttons[i] == 'O'))
                {
                    whowon(0);
                    startnewgame();
                    return false;
                }
            }
            for (int i = 0; i < 8; i += 3)
            {
                if (buttons[i] == buttons[i + 1] && buttons[i] == buttons[i + 2] &&
                    (buttons[i] == 'X' || buttons[i] == 'O'))
                {
                    whowon(0);
                    startnewgame();
                    return false;
                }
            }
            if (buttons[0] == buttons[4] && buttons[0] == buttons[8] &&
                   (buttons[0] == 'X' || buttons[0] == 'O'))
            {
                whowon(0);
                startnewgame();
                return false;
            }
            else if (buttons[2] == buttons[4] && buttons[2] == buttons[6] && (buttons[2] == 'X' || buttons[2] == 'O'))
            {
                whowon(0);
                startnewgame();
                return false;
            }

            foreach (var box in buttons)
            {
                if (box != 'X' && box != 'O')
                    return true;

            }
            whowon(1);
            startnewgame();
            return false;


        }
    }
}
