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

namespace Maze
{
    /// <summary>
    /// Логика взаимодействия для create.xaml
    /// </summary>
    public partial class create : Window
    {
        public create()
        {
            InitializeComponent();
        }

        private void Create_hero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                location.Town town = new location.Town();
                town.Show();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
