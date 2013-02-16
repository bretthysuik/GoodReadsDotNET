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
        /// Gets the book's title.
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the book's Goodreads ID.
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets a brief description of the book.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Gets the number of pages.
        /// </summary>
        public int PagesCount { get; internal set; }

        /// <summary>
        /// Gets the book's original publication date.
        /// </summary>
        public DateTime OriginalPublicationDate { get; internal set; }

        /// <summary>
        /// Gets the publication date of this editon of the book.
        /// </summary>
        public DateTime PublicationDate { get; internal set; }

        /// <summary>
        /// Gets the book's edition.
        /// </summary>
        public string Edition { get; internal set; }

        /// <summary>
        /// Gets the publisher of the book.
        /// </summary>
        public string Publisher { get; internal set; }

        /// <summary>
        /// Gets the number of user ratings.
        /// </summary>
        public int RatingsCount { get; internal set; }
        
        /// <summary>
        /// Gets the book's average user rating.
        /// </summary>
        public double AverageRating { get; internal set; }

        /// <summary>
        /// Gets the book's author(s).
        /// </summary>
        public List<Author> Authors { get; internal set; }

        /// <summary>
        /// Gets the series this book belongs to (if any).
        /// </summary>
        public Series Series { get; internal set; }

        /// <summary>
        /// Gets the hyperlink to the book's cover.
        /// </summary>
        public string CoverLink { get; internal set; }

        /// <summary>
        /// Gets the hyperlink to the book's cover (small image).
        /// </summary>
        public string CoverSmallLink { get; internal set; }

        /// <summary>
        /// Gets the book's ISBN-10 code.
        /// </summary>
        public string Isbn10 { get; internal set; }

        /// <summary>
        /// Gets the book's ISBN-13 code.
        /// </summary>
        public string Isbn13 { get; internal set; }

        /// <summary>
        /// Gets the book's Goodreads link.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the type of book binding (hardcover, softcover, etc) for this edition of the book.
        /// </summary>
        public string Format { get; internal set; }

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
            return String.Format("Author: {0}\nTitle: {1}\nID: {2}", this.Authors.First().Name, this.Title, this.ID);
        }
    }
}
