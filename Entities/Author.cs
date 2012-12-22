using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadsDotNET.Entities
{
    public class Author
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the author's full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the author's GoodReads ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the the author's GoodReads link.
        /// </summary>
        public string Link { get; set; }

        #endregion

        #region Constructor

        public Author(string name, int id, string link)
        {
            Name = name;
            ID = id;
            Link = link;
        }

        #endregion
    }
}
