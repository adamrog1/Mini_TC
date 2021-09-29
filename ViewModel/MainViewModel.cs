using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_MVVM.View;

namespace TicTacToe_MVVM.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private char mark;
        private ICommand command;
        private bool playerturn;
        private char[] buttons = new char[9];

        

        public char Mark
        {
            get { return mark; }

            set
            {
                mark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mark)));

            }
        }
        public char[] Buttons
        {
            get { return buttons; }

            set
            {
                buttons = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Buttons)));

            }
        }

        public bool PlayerTurn
        {
            get { return playerturn; }

            set
            {
                playerturn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerTurn)));

            }
        }

        public ICommand Select
        {
            get
            {
                return command ?? (command = new RelayCommand(whenselect, checkforawin));
            }
        }

        private bool checkforawin(object obj)
        {
            if (obj == null)
                return false;

            if (!int.TryParse(obj.ToString(), out int index))
                return false;

            return _ = new Model.Logic(Buttons, Mark, index, PlayerTurn).checkforawin(obj);
            
        }
            private void whenselect(object obj)
        {
            if (obj == null)
                return;

            if (!int.TryParse(obj.ToString(), out int index))
                return;

            (Buttons, Mark, PlayerTurn) = new Model.Logic(Buttons, Mark, index, PlayerTurn).move();


        }


    }
}
