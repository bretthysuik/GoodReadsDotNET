using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodreadsDotNET.Entities
{
    public class Series
    {
        #region Public Properties

        /// <summary>
        /// The name of the series.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The series' Goodreads ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// The total number of primary and non-primary books in the series.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets the primary number of books in the series.
        /// </summary>
        public int PrimaryCount { get; set; }

        /// <summary>
        /// The collection of books in the series.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// A description or summary of the series.
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constrcutors

        public Series()
        {

        }

        public Series(string title, int id, int count)
        {
            Title = title;
            ID = id;
            Count = count;
        }

        #endregion
    }
}
