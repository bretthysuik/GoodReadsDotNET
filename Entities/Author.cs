using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodreadsDotNET.Entities
{
    public class Author
    {
        #region Public Properties

        /// <summary>
        /// Gets the author's full name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the author's Goodreads ID.
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets the the author's Goodreads link.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the number of Goodreads fans of the author.
        /// </summary>
        public int FansCount { get; internal set; }

        /// <summary>
        /// Gets a link to an image of the author.
        /// </summary>
        public string ImageLink { get; internal set; }

        /// <summary>
        /// Gets a link to a small image of the author.
        /// </summary>
        public string ImageSmallLink { get; internal set; }

        /// <summary>
        /// Gets a description about the author.
        /// </summary>
        public string About { get; internal set; }

        /// <summary>
        /// Gets a collection of authors that influenced this author.
        /// </summary>
        public List<string> Influences { get; internal set; }

        /// <summary>
        /// Gets the number of works (books) by the author.
        /// </summary>
        public int WorksCount { get; internal set; }

        /// <summary>
        /// Gets the author's gender.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets the author's hometown.
        /// </summary>
        public string Hometown { get; internal set; }

        /// <summary>
        /// Gets the author's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets the author's date of death, if applicable.
        /// </summary>
        public DateTime? DateOfDeath { get; internal set; }

        /// <summary>
        /// Gets a collection of the author's published books.
        /// </summary>
        public List<Book> Books { get; internal set; }

        #endregion

        #region Constructor

        public Author()
        {
            Books = new List<Book>();
            Influences = new List<string>();
        }

        public Author(string name, int id) : this()
        {
            Name = name;
            ID = id;
        }

        public Author(string name, int id, string link) : this(name, id)
        {
            Link = link;
        }

        public Author(string name, int id, string link, string imageLink, string imageSmallLink) : this(name, id, link)
        {
            ImageLink = imageLink;
            ImageSmallLink = imageSmallLink;
        }

        #endregion
    }
}
