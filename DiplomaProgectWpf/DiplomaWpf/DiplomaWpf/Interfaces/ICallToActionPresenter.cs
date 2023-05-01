using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface ICallToActionPresenter
    {
        /// <summary>
        /// список с призывами к действию
        /// </summary>
        ObservableCollection<CallToAction> ActionsList { get; set; }

        /// <summary>
        /// видимость грида со списком
        /// </summary>
        void CallToActionVisability();

        /// <summary>
        /// получить список с призывами
        /// </summary>
        void GetActionList();

        /// <summary>
        /// добавить призыв
        /// </summary>
        /// <param name="action"></param>
        void AddAction();

        /// <summary>
        /// сохранить призыв
        /// </summary>
        void SaveAction();

        /// <summary>
        /// возвращает назад
        /// </summary>
        void BackAction();

        /// <summary>
        /// удалить призыв
        /// </summary>
        /// <param name="id"></param>
        void RemoveAction();

        /// <summary>
        /// событие при выборе элемента в списке
        /// </summary>
        void SelectionChanged();



    }
}
