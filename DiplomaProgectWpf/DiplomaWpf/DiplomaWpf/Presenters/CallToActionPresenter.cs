using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class CallToActionPresenter : ICallToActionPresenter,INotifyPropertyChanged
    {
        MainWindow view;
        ISkillProfiContext context;
        private ObservableCollection<CallToAction> actionsList;
        private string textBoxAction;
       

        /// <summary>
        /// список с призывами к действию
        /// </summary>
        public ObservableCollection<CallToAction> ActionsList { get => actionsList; set { actionsList = value;OnPropertyChanged("ActionsList"); } }

        /// <summary>
        /// свойство для записи нового призыва
        /// </summary>
        public string TextBoxAction { get=>textBoxAction; set { textBoxAction = value;OnPropertyChanged("TextBoxAction"); } }

        public void CallToActionVisability()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Visible;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
            view.callToActionGrid.Visibility = Visibility.Visible;
        }

        public CallToActionPresenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
            ActionsList = new ObservableCollection<CallToAction>();
            view.callToActionGrid.DataContext = this;

        }


        /// <summary>
        /// добавить призыв
        /// </summary>
        /// <param name="action"></param>
        public void AddAction()
        {
            view.textBoxActionGrid.Visibility = Visibility.Visible;
            view.borderAddAction.Visibility = Visibility.Collapsed;
            view.borderSaveAction.Visibility = Visibility.Visible;
 
        }

        /// <summary>
        /// сохраняет призыв
        /// </summary>
        public void SaveAction()
        {
            //сохраняем запись с новым призывом и обновляем список
            StatusResult.Invoke(context.AddCallToAction(new CallToAction { Text = TextBoxAction }), () =>
            {
                GetActionList();
                TextBoxAction = default;
                view.textBoxActionGrid.Visibility = Visibility.Collapsed;
                view.borderAddAction.Visibility = Visibility.Visible;
                view.borderSaveAction.Visibility = Visibility.Collapsed;
            });
        }

        /// <summary>
        /// получить список с призывами
        /// </summary>
        public void GetActionList()
        {
            ActionsList = new ObservableCollection<CallToAction>(context.GetCallToActions());
        }

        /// <summary>
        /// удалить призыв
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAction()
        {
           var index= view.listBoxAction.SelectedIndex;//получаем индекс

            if (index != -1)
            {
                var itemId = ActionsList[index].Id;//получаем Id

                StatusResult.Invoke(context.DeleteCallToAction(itemId), () => GetActionList());
            }
            else
            {
                view.checkBlockCallToActionGrid.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// событие при выборе элемента в списке
        /// </summary>
        public void SelectionChanged()
        {
            view.checkBlockCallToActionGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// возвращает назад
        /// </summary>
        public void BackAction()
        {
            view.mainGrid.Visibility = Visibility.Visible;
            TextBoxAction = default;
            view.callToActionGrid.Visibility = Visibility.Collapsed;
            view.textBoxActionGrid.Visibility = Visibility.Collapsed;
            view.borderAddAction.Visibility = Visibility.Visible;
            view.borderSaveAction.Visibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
