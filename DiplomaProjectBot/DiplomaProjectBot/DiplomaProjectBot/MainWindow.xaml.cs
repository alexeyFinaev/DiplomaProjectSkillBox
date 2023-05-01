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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomaProjectBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPresenter presenter;
        public MainWindow()
        {
            InitializeComponent();

            presenter = new Presenter(this);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            presenter.InvokeStart();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            presenter.InvokeStop();
        }
    }
}
