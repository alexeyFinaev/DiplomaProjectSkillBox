using DiplomaWpf.Presenters;
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

namespace DiplomaWpf
{
    /// <summary>
    /// Логика взаимодействия для NewNameButtonNavigate.xaml
    /// </summary>
    public partial class NewNameButtonNavigate : Window
    {
        NewNameButtonNawigatePresenter presenter;

        public NewNameButtonNavigate()
        {
            InitializeComponent();

            presenter = new NewNameButtonNawigatePresenter(this);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //меняем название кнопки
            presenter.NavigateNameChange(Convert.ToInt32(indexNewNameButton.Text), newButtonName.Text);

            this.Close();

        }

        
    }
}
