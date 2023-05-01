﻿using System;

namespace DiplomaProjectWebApi.Models
{
    public class Proposal
    {
        public int Id { get; set; }

        /// <summary>
        /// имя и фамилия
        /// </summary>
        public string LastFirstName { get; set; }

        /// <summary>
        /// почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// текст обращения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// статус заявки
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// дата
        /// </summary>
        public DateTime Data { get; set; }

        public Proposal()
        {
            LastFirstName = "";
            Email = "";
            Text = "";
            Status = "Получена";
            Data = DateTime.Now;
        }
    }
}