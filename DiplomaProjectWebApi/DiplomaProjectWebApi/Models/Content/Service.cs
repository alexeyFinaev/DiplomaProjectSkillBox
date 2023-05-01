namespace DiplomaProjectWebApi.Models
{
    public class Service
    {
        public int Id { get; set; }

        /// <summary>
        /// название услуги
        /// </summary>
        public string NameService { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        public string Text { get; set; }
    }
}