using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodreadsDotNET.Entities
{
    public class Book
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the book's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the book's Goodreads ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets a brief description of the book.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        public int NumPages { get; set; }

        /// <summary>
        /// Gets or sets the book's original publication date.
        /// </summary>
        public DateTime OriginalPublicationDate { get; set; }

        /// <summary>
        /// Gets the publication date of this editon of the book.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        public string Edition { get; set; }

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
        public List<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the series this book belongs to (if any).
        /// </summary>
        public Series Series { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink to the book's cover.
        /// </summary>
        public string CoverLink { get; set; }

        /// <summary>
        /// Gets the hyperlink to the book's cover (small image).
        /// </summary>
        public string CoverSmallLink { get; set; }

        /// <summary>
        /// Gets the book's ISBN-10 code.
        /// </summary>
        public int Isbn10 { get; set; }

        /// <summary>
        /// Gets the book's ISBN-13 code.
        /// </summary>
        public long Isbn13 { get; set; }

        /// <summary>
        /// Gets the book's Goodreads link.
        /// </summary>
        public string Link { get; set; }

        public string Format { get; set; }

        #endregion

        #region Constructors

        public Book()
        {
            Authors = new List<Author>();
        }

        public Book(string title, int id) : this()
        {
            Title = title;
            ID = id;
        }

        #endregion

        public override string ToString()
        {
            return String.Format("{0} - {1}", this.Authors.First().Name, this.Title);
        }
    }
}
