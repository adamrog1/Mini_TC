using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacToe_MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string winner)
        {
            InitializeComponent();
            if (winner.Equals("X") || winner.Equals("O")) Winner.Text = $"Zwycięzca jest {winner}";
            else Winner.Text = "Remis";
        }
    }
}
