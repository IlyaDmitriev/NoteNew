using System;
using System.Collections.Generic;
using System.Text;

namespace NotesCore.Models
{
	public class Note
	{
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст заментки
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///  Дата и время создание заметки
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Жизненый цикл
        /// </summary>
        public LifeTimeNote LifeTime { get; set; }
    }
}
