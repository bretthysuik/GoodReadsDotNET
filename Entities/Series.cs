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
        public string Title { get; internal set; }

        /// <summary>
        /// The series' Goodreads ID.
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// ???
        /// </summary>
        public string Note { get; internal set; }

        /// <summary>
        /// The total number of primary and non-primary books in the series.
        /// </summary>
        public int TotalCount { get; internal set; }

        /// <summary>
        /// Gets the primary number of books in the series.
        /// </summary>
        public int PrimaryCount { get; internal set; }

        /// <summary>
        /// The collection of books in the series.
        /// </summary>
        public List<Book> Books { get; internal set; }

        /// <summary>
        /// A description or summary of the series.
        /// </summary>
        public string Description { get; internal set; }

        #endregion

        #region Constrcutors

        public Series()
        {
            Books = new List<Book>();
        }

        public Series(string title, int id, int count) : this()
        {
            Title = title;
            ID = id;
            TotalCount = count;
        }

        #endregion
    }
}
