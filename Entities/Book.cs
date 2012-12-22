using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadsDotNET.Entities
{
    public class Book
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the book's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the book's GoodReads ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the book's plot summary.
        /// </summary>
        public string PlotSummary { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        public int NumPages { get; set; }

        /// <summary>
        /// Gets or sets the book's publication date.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the book.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the number of user ratings.
        /// </summary>
        public int RatingsCount { get; set; }
        
        /// <summary>
        /// Gets or sets the book's average user rating.
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the book's author(s).
        /// </summary>
        public List<Author> Author { get; set; }

        /// <summary>
        /// Gets or sets the series this book belongs to (if any).
        /// </summary>
        public Series Series { get; set; }

        public int? NumInSeries { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink to the book's cover.
        /// </summary>
        public string CoverLink { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink to the book's cover (small image).
        /// </summary>
        public string CoverSmallLink { get; set; }

        /// <summary>
        /// Gets or sets the book's ISBN-10 code.
        /// </summary>
        public int Isbn10 { get; set; }

        /// <summary>
        /// Gets or sets the book's ISBN-13 code.
        /// </summary>
        public int Isbn13 { get; set; }

        /// <summary>
        /// Gets or sets the book's GoodReads link.
        /// </summary>
        public string Link { get; set; }

        #endregion

        #region Constructor

        public Book(string title, int id)
        {
            Title = title;
            ID = id;
        }

        #endregion
    }
}
