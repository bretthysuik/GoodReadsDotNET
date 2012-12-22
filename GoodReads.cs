using GoodReadsDotNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadsDotNET
{
    public class GoodReads
    {
        #region API URLs

        private const string BOOK_INFO = @"http://www.goodreads.com/book/{1}?format=xml&key={0}";

        private const string SEARCH_BOOK = @"http://www.goodreads.com/search.xml?key={0}&q={1}";

        private const string AUTHOR_INFO = @"http://www.goodreads.com/author/show/{1}.xml?key={0}";

        private const string SEARCH_AUTHOR = @"http://www.goodreads.com/api/author_url/{1}?key={0}";

        #endregion

        #region Public Properties

        public string ApiKey { get; set; }

        #endregion

        #region Constructor

        public GoodReads(string apiKey)
        {
            ApiKey = apiKey;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Search for a book using the title as the seach query.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <returns>The collection of books matching the query.</returns>
        public async Task<string> SearchForBook(string title)
        {
            string url = String.Format(SEARCH_BOOK, ApiKey, FormatQuery(title));
            string response = await GetXmlResponse(url);
            // TODO: parse response
            // TODO: return results

            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Seach for a book using the GoodReads ID as the seach query.
        /// </summary>
        /// <param name="id">The GoodReads ID.</param>
        /// <returns>The book.</returns>
        public Book SearchForBook(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search for an author using their name as the search query.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <returns>The collection of authors matching the query.</returns>
        public List<Author> SearchForAuthor(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search for an author using the GoodReads ID as the search query.
        /// </summary>
        /// <param name="id">The GoodReads ID.</param>
        /// <returns>The author.</returns>
        public Author SearchForAuthor(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Format the query for ???
        /// </summary>
        /// <param name="query">The query string to format.</param>
        /// <returns>The formatted query.</returns>
        public string FormatQuery(string query)
        {
            return query.Replace(" ", "+");
        }

        /// <summary>
        /// Gets the XML reponse after querying the GoodReads API.
        /// </summary>
        /// <param name="url">The url to query.</param>
        /// <returns>The XML repsonse.</returns>
        internal static async Task<string> GetXmlResponse(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        #endregion
    }
}
