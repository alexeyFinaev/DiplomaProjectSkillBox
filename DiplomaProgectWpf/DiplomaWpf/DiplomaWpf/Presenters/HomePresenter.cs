using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
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
using System.Windows.Controls;

namespace DiplomaWpf.Presenters
{
    class HomePresenter:IHomePresenter,INotifyPropertyChanged
    {

        /// <summary>
        /// поля
        /// </summary>
        ISkillProfiContext context;
        MainWindow view;

        private ObservableCollection<Proposal> proposals;
        private DateTime startDate;//начальная дата
        private DateTime endDate;//конечная дата
        private string received;//хранит процент полученых заявок
        private string atWork;//хранит процент заявок в работе
        private string done;//хранит процент выполненых заявок
        private string cancelled;//хранит процент отклоненных заявок 
        private string rejected;//хранит процент отмененных заявок
        private string proposalsCount;//хранит число заявок

        private int id;
        private string lastFirstName;
        private string email;
        private string text;
        private string status;
        private DateTime data;



        /// <summary>
        /// Свойства
        /// </summary>
        public ObservableCollection<Proposal> Proposals { get => proposals; set { proposals = value;OnPropertyChanged("Proposals"); } }
        public DateTime StartDate { get => startDate; set { startDate = value;OnPropertyChanged("StartDate"); } }
        public DateTime EndDate { get => endDate; set { endDate = value;OnPropertyChanged("EndDate"); } }
        public string ProposalsCount { get=>proposalsCount; set { proposalsCount = value;OnPropertyChanged("ProposalsCount"); } }

        public string Received { get => received; set { received = value;OnPropertyChanged("Received"); } }
        public string AtWork { get => atWork; set { atWork = value;OnPropertyChanged("AtWork"); } }
        public string Done { get => done; set { done = value;OnPropertyChanged("Done"); } }
        public string Cancelled { get => cancelled; set { cancelled = value;OnPropertyChanged("Cancelled"); } }
        public string Rejected { get => rejected; set { rejected = value;OnPropertyChanged("Rejected"); } }

        public int Id { get=>id; set { id = value;OnPropertyChanged("Id"); } }
        public string LastFirstName { get=>lastFirstName; set { lastFirstName = value;OnPropertyChanged("LastFirstName"); } }
        public string Email { get=>email; set { email = value;OnPropertyChanged("Email"); } }
        public string Text { get => text; set { text = value;OnPropertyChanged("Text"); } }
        public string Status { get => status; set { status = value;OnPropertyChanged("Status"); } }
        public DateTime Data { get => data; set { data = value;OnPropertyChanged("Data"); } }



        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public HomePresenter(MainWindow view)
        {
            context = new SkillProfiContext();
            this.view = view;
            Proposals = new ObservableCollection<Proposal>();
            view.homeGrid.DataContext = this;
            view.proposalGrid.DataContext = this;
        }

       


        /// <summary>
        /// показывает страницу с заявками
        /// </summary>
        public void DesctopGridVisability()
        {
            view.homeGrid.Visibility = Visibility.Visible;
            view.mainGrid.Visibility = Visibility.Collapsed;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// метод загрузки заявок в таблицу
        /// </summary>
        public void GetProposalDataGrid()
        {
            Proposals = new ObservableCollection<Proposal>(context.GetProposals());//присваиваем свойству значение

            GetPrecentProposals(Proposals);//показываем процентное соотношение заявок

            ProposalsCount = $"Всего заявок: {Proposals.Count()}";

            CalendarButtonsStart();
        }


        #region Методы Выборки заявок по времени и категории

        /// <summary>
        /// выборка заявок по дате
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public void GetDateProposals(DateTime startDate, DateTime endDate)
        {
            //отключаем grid с календарем
            view.calendarGrid.Visibility = Visibility.Collapsed;

            //получаем список с выборкой по дате
            Proposals = new ObservableCollection<Proposal>(context.GetDateProposals(startDate, endDate));

            //присваиваем свойствам значения
            StartDate = startDate;
            EndDate = endDate;


            //выводим текст с кол-вом заявок
            view.proposalsCountPeriod.Text = $" {Proposals.Count()}";

            //выводим количество заявок в процентах
            GetPrecentProposals(Proposals);

        }

        /// <summary>
        /// подсчет кол-ва процентов данной категории
        /// </summary>
        /// <param name="proposals"></param>
        /// <param name="categoriProposalsCount"></param>
        /// <returns></returns>
        private string PrecentString(IEnumerable<Proposal> proposals,int categoriProposalsCount)
        {
            string str;
            if(proposals.Count()>0)
            {
                //если количество заявок больше нуля считаем процент заявок и записываем в строку
                double precent = categoriProposalsCount / (double)proposals.Count() * 100;

                //форматируем значения
                string strPrecent = string.Format("{0:0}", precent);

                //записываем значения в переменную
                str = $"{categoriProposalsCount}({strPrecent}%)";

            }
            else { str = "0(0%)"; }

            return str;
        
        }

        /// <summary>
        /// процентное отношение заявок по категориям
        /// </summary>
        /// <param name="proposals"></param>
        private void GetPrecentProposals(ObservableCollection<Proposal> proposals)
        {
            //получаем количество заявок каждой категории
            var receivedCount = CategoryProposalsCount(proposals, StatusesProposal.Statuses[0]);
            var atWorkCount = CategoryProposalsCount(proposals, StatusesProposal.Statuses[1]);
            var doneCount = CategoryProposalsCount(proposals, StatusesProposal.Statuses[2]);
            var cancelledCount = CategoryProposalsCount(proposals, StatusesProposal.Statuses[3]);
            var rejectedCount = CategoryProposalsCount(proposals, StatusesProposal.Statuses[4]);

            //вычисляем и присваиваем значения свойствам
            Received = PrecentString(proposals, receivedCount);

            AtWork = PrecentString(proposals, atWorkCount);

            Done = PrecentString(proposals, doneCount);

            Cancelled = PrecentString(proposals, cancelledCount);

            Rejected = PrecentString(proposals, rejectedCount);


        }

        /// <summary>
        /// возвращает кол-во элементов данной категории
        /// </summary>
        /// <param name="proposals"></param>
        /// <returns></returns>
        private int CategoryProposalsCount(IEnumerable<Proposal> proposals, string str)
        {
            //возвращаем кол-во элементов списка с заданной категории
            return proposals.Where(w => w.Status == str).Count();
        }

        /// <summary>
        /// вызов календаря
        /// </summary>
        public void GetCalendarStart()
        {
            view.checkText.Text = "";

            //блокируем выбор дат после сегодняшней
            view.calendarStart.DisplayDateEnd = DateTime.Now;

            //включаем видимость календаря
            view.calendarGrid.Visibility = Visibility.Visible;
            view.calendarStart.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// метод ввода начальной даты календаря
        /// </summary>
        public void EnterCalendarPeriodStart()
        {
            //устанавливаем значение даты в текстовое поле кнопки
            view.periodStart.Content = view.calendarStart.SelectedDate.Value.ToString("dd.MM.yyyy");
            
            //отключаем видимость календаря
            view.calendarGrid.Visibility = Visibility.Collapsed;
            view.calendarStart.Visibility = Visibility.Collapsed;

            var date = new DateTime();

            //если введен конечный период
            if (DateTime.TryParse(view.periodEnd.Content.ToString(), out  date))
            {
                //используем метод выборки по дате
                GetDateProposals(DateTime.Parse(view.periodStart.Content.ToString()),
                    date);
            }

        }

        /// <summary>
        /// выборка с установкой даты по календарю
        /// </summary>
        public void GetCalendarEnd()
        {
            var date = new DateTime();

            //если выбрано начальное значение даты
            if (DateTime.TryParse(view.periodStart.Content.ToString(), out date))
            {
                view.checkText.Text = "";

                //устанавливаем конечную дату из контекста кнопки periodStart
                view.calendarEnd.DisplayDateStart = date;
                view.calendarEnd.DisplayDateEnd = DateTime.Now;

                //включаем видимость календаря
                view.calendarGrid.Visibility = Visibility.Visible;
                view.calendarEnd.Visibility = Visibility.Visible;

            }
            else
            {
                view.checkText.Text = "Введите начальную дату";
            }

        }

        /// <summary>
        /// метод ввода конечной даты календаря
        /// </summary>
        public void EnterCalendarPeriodEnd()
        {
            //устанавливаем значение даты в текстовое поле кнопки
            view.periodEnd.Content = view.calendarEnd.SelectedDate.Value.ToString("dd.MM.yyyy");

            //выключаем видимость календаря
            view.calendarGrid.Visibility = Visibility.Collapsed;
            view.calendarEnd.Visibility = Visibility.Collapsed;

            //используем метод выборки по дате
            GetDateProposals(DateTime.Parse(view.periodStart.Content.ToString()),
                DateTime.Parse(view.periodEnd.Content.ToString()).AddDays(1));

        }

        /// <summary>
        /// стартовые значения контента кнопок вызова календаря
        /// </summary>
        public void CalendarButtonsStart()
        {
            view.periodStart.Content = "периуд с";
            view.periodEnd.Content = "по";
        }

        #endregion


        /// <summary>
        /// возвращает список элементов указаной категории
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public void GetCategory(string status)
        {
            Proposals = new ObservableCollection<Proposal>(context.GetProposalsStatus(status));
        }

        /// <summary>
        /// информация по выбранной заявке
        /// </summary>
        /// <param name="sender"></param>
        public void ProposalInfoSelection(object sender)
        {
            var s = (DataGrid)sender;//приводим объект к DataGrid

            var index = s.SelectedIndex;//получаем индекс

            
            view.proposalGrid.Visibility = Visibility.Visible;//включаем видимость грида


            if (index != -1)
            {
                var proposal = Proposals[index];//получаем выделенную заявку

                //передаем значения свойствам
                LastFirstName = proposal.LastFirstName;
                Email = proposal.Email;
                Text = proposal.Text;
                Status = proposal.Status;
                Id = proposal.Id;

            }
        }

        /// <summary>
        /// изменение статуса заявки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void ProposalStatusToChange(int id, string status)
        {
            //передаем свойству значение нового статуса
            Status = status;

            //меняем статус заявки и выводим значение статуса
            StatusResult.Invoke(context.UpdateProposal(Convert.ToString(id), status), () => {});
                   
        }

        /// <summary>
        /// закрывает страницу с информацией по заявке
        /// </summary>
        public void ProposalInfoClose()
        {
            //получаем список по выбранным датам
            Proposals= new ObservableCollection<Proposal>(context.GetDateProposals(StartDate, EndDate));

            //обновляем значения кнопок с процентами категорий
            GetPrecentProposals(Proposals);

            //скрываем видимость grid
            view.proposalGrid.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

}

