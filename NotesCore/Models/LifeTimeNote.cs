using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesCore.Models
{

    public class LifeTimeNote
    {
        /// <summary>
        /// Дата когда должна быть удалена заментка.
        /// </summary>
        public DateTime? DeletingDate { get; set; }

        /// <summary>
        /// Количество допустимых просмотров.
        /// </summary>
        public int Count { get; set; }
    }

    public class DateTimeLifeTime : LifeTimeNote
    {
       
    }

    public class CountLifeTime : LifeTimeNote
    {
        
    }
}
