using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class MainPresenter:IMainPresenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        ISkillProfiContext context;
        MainWindow view;
        private string text1;
        private string text2;
        private string textButton;
        private string text3;


        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public MainPresenter(MainWindow view)
        {
            this.view = view;

            context = new SkillProfiContext();

            view.mainGrid.DataContext = this;
        }

        /// <summary>
        /// свойства
        /// </summary>
        public string Text1 { get => text1; set { text1 = value;OnPropertyChanged("Text1"); } }
        public string Text2 { get => text2; set { text2 = value;OnPropertyChanged("Text2"); } }
        public string TextButton { get => textButton;set { textButton = value; OnPropertyChanged("TextButton"); } }
        public string Text3 { get => text3; set { text3 = value;OnPropertyChanged("Text3"); } }

        /// <summary>
        /// отображает главную страницу
        /// </summary>
        public void MainVisability()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Visible;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// отображает текстбоксы для редактирования
        /// </summary>
        public void ViewTextBlockMainGrid()
        {
            view.textBox_1MainGrid.Visibility = Visibility.Visible;
            view.textBox_2MainGrid.Visibility = Visibility.Visible;
            view.textBoxButtonTitleMainGrid.Visibility = Visibility.Visible;
            view.submitProposalTextBox.Visibility = Visibility.Visible;
            view.borderSaveButtonMainGrid.Visibility = Visibility.Visible;
            view.borderEditButtonMainGrid.Visibility = Visibility.Collapsed;
            view.CallToActionVisibilityButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// отключает текстбоксы для редактирования
        /// </summary>
        private void DesabledViewTextBlockMainGrid()
        {
            view.textBox_1MainGrid.Visibility = Visibility.Collapsed;
            view.textBox_2MainGrid.Visibility = Visibility.Collapsed;
            view.textBoxButtonTitleMainGrid.Visibility = Visibility.Collapsed;
            view.submitProposalTextBox.Visibility = Visibility.Collapsed;
            view.CallToActionVisibilityButton.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// получение текста для текстовых блоков главной страницы
        /// </summary>
        /// <returns></returns>
        public void GetContent()
        {
            //получаем данные из контекста
            var textHome = context.GetTextHome();

            //присваиваем значения свойствам
            Text1 = textHome.Text_1;
            Text2 = textHome.Text_2;
            TextButton = textHome.TextButton;
            Text3 = textHome.Text_3;

        }

        /// <summary>
        /// изменение контента на странице
        /// </summary>
        public void UpdateContent()
        {

            //отправляем запрос с новыми данными=>вслучае успехо обновляем страницу=>скрываем кнопку изменения
            StatusResult.Invoke(context.UpdateTextHome(new TextHome(Text1, Text2, TextButton, Text3)), () =>
             { GetContent(); DesabledViewTextBlockMainGrid();
                 view.borderSaveButtonMainGrid.Visibility = Visibility.Collapsed;
                 view.borderEditButtonMainGrid.Visibility = Visibility.Visible;
             });
        }

   


        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        #region gttryr
        ///// <summary>
        ///// отображение вкладки "Главная"
        ///// </summary>
        //public void MainVisability()
        //{
        //    view.homeGrid.Visibility = Visibility.Collapsed;
        //    view.mainGrid.Visibility = Visibility.Visible;
        //    view.projectGrid.Visibility = Visibility.Collapsed;
        //    view.projectInfoGrid.Visibility = Visibility.Collapsed;
        //    view.projectInfoGrid.Visibility = Visibility.Collapsed;
        //    view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
        //    view.serviceGrid.Visibility = Visibility.Collapsed;
        //}

        ///// <summary>
        ///// изменение текста блоков главной страницы
        ///// </summary>
        ///// <param name="text1"></param>
        ///// <param name="text2"></param>
        ///// <param name="textButton"></param>
        //private void UpdateTextBlock(string text1,string text2,string textButton,string text3)
        //{
        //    //создаем экземпляр класса TextHome
        //    var textHome = new TextHome(text1, text2, textButton,text3);

        //    //изменяем данные
        //    context.UpdateTextHome(textHome);
        //}

        ///// <summary>
        ///// отображает названия текстовых блоков на главной странице
        ///// </summary>
        //public void ViewTextBlockMainGrid()
        //{
        //    //получаем значения текстовых блоков из базы данных
        //    var textHome = context.GetTextHome();

        //    //присваиваем значения
        //    view.textBlock_1MainGrid.Text = textHome.Text_1;

        //    view.textBlock_2MainGrid.Text = textHome.Text_2;

        //    view.textBlockButtonTitleMainGrid.Text = textHome.TextButton;

        //    view.submitProposalTextBlock.Text = textHome.Text_3;


        //}

        ///// <summary>
        ///// отображение текстбок для редактирования
        ///// </summary>
        //public void VisibilityTextBoxMainGrid()
        //{
        //    //присваиваем текстбоксам значения текстовых блоков
        //    view.textBox_1MainGrid.Text = view.textBlock_1MainGrid.Text;
        //    view.textBox_2MainGrid.Text = view.textBlock_2MainGrid.Text;
        //    view.textBoxButtonTitleMainGrid.Text =view.textBlockButtonTitleMainGrid.Text;
        //    view.submitProposalTextBox.Text = view.submitProposalTextBlock.Text;

        //    //включаем видимость TextBox
        //    view.textBox_1MainGrid.Visibility = Visibility.Visible;
        //    view.textBox_2MainGrid.Visibility = Visibility.Visible;
        //    view.textBoxButtonTitleMainGrid.Visibility = Visibility.Visible;
        //    view.submitProposalTextBox.Visibility = Visibility.Visible;

        //    //включам видимость кнопки сохранения данных
        //    view.borderSaveButtonMainGrid.Visibility = Visibility.Visible;
        //}

        ///// <summary>
        ///// отправляет новые значения
        ///// </summary>
        //public void ViewUpdateTextBlock()
        //{
        //    //принимаем значения из текстовых боксов
        //    var text_1 = view.textBox_1MainGrid.Text;
        //    var text_2 = view.textBox_2MainGrid.Text;
        //    var buttonText = view.textBoxButtonTitleMainGrid.Text;
        //    var text_3 = view.submitProposalTextBox.Text;

        //    //изменяем значения 
        //    UpdateTextBlock(text_1, text_2, buttonText,text_3);

        //    //передаем новые значения в TextBlock 
        //    view.textBlock_1MainGrid.Text = text_1;
        //    view.textBlock_2MainGrid.Text = text_2;
        //    view.textBlockButtonTitleMainGrid.Text = buttonText;
        //    view.submitProposalTextBlock.Text = text_3;


        //    //отключаем видимость текстовых боксов
        //    CollapsedTextBoxMainGrid();
        //}

        ///// <summary>
        ///// отключаем видимость текстовых боксов
        ///// </summary>
        //private void CollapsedTextBoxMainGrid()
        //{
        //    //выключаем видимость TextBox
        //    view.textBox_1MainGrid.Visibility = Visibility.Collapsed;
        //    view.textBox_2MainGrid.Visibility = Visibility.Collapsed;
        //    view.textBoxButtonTitleMainGrid.Visibility = Visibility.Collapsed;
        //    view.submitProposalTextBox.Visibility = Visibility.Collapsed;
        //    //выключаем видимость кнопки сохранения изменений
        //    view.borderSaveButtonMainGrid.Visibility = Visibility.Collapsed;

        //}
        #endregion
    }
}
