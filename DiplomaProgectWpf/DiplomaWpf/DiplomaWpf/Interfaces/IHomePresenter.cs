using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IHomePresenter
    {
        /// <summary>
        /// Свойства
        /// </summary>
        ObservableCollection<Proposal> Proposals { get; set; }//коллекция
        DateTime StartDate { get; set; }//начальная дата
        DateTime EndDate { get; set; }//конечная дата
        string ProposalsCount { get; set; }

        string Received { get; set; }//статус "получена"
        string AtWork { get; set; }//статус "в работе"
        string Done { get; set; }//статус "выполнена"
        string Cancelled { get; set; }//статус "отменена"
        string Rejected { get; set; }//статус "отклонена"

        int Id { get; set; }//id заявки
        string LastFirstName { get; set; }//имя и фамилия в заявке
        string Email { get; set; }//email
        string Text { get; set; }//текст заявки
        string Status { get; set; }//статус заявки
        DateTime Data { get; set; }//дата заявки




        /// <summary>
        /// показывает страницу с заявками
        /// </summary>
        void DesctopGridVisability();

        /// <summary>
        /// метод загрузки заявок в таблицу
        /// </summary>
        void GetProposalDataGrid();

        /// <summary>
        /// выборка заявок по дате
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        void GetDateProposals(DateTime startDate, DateTime endDate);

        /// <summary>
        /// вызов календаря
        /// </summary>
        void GetCalendarStart();

        /// <summary>
        /// метод ввода начальной даты календаря
        /// </summary>
        void EnterCalendarPeriodStart();

        /// <summary>
        /// выборка с установкой даты по календарю
        /// </summary>
        void GetCalendarEnd();

        /// <summary>
        /// метод ввода конечной даты календаря
        /// </summary>
        void EnterCalendarPeriodEnd();

        /// <summary>
        /// стартовые значения контента кнопок вызова календаря
        /// </summary>
        void CalendarButtonsStart();

        /// <summary>
        /// возвращает список элементов указаной категории
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        void GetCategory(string status);

        /// <summary>
        /// информация по выбранной заявке
        /// </summary>
        /// <param name="sender"></param>
        void ProposalInfoSelection(object sender);

        /// <summary>
        /// изменение статуса заявки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        void ProposalStatusToChange(int id, string status);

        /// <summary>
        /// закрывает страницу с информацией по заявке
        /// </summary>
        void ProposalInfoClose();
        

    }
}
