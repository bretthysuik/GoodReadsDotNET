using GoodreadsDotNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GoodreadsDotNET
{
    public class Goodreads
    {
        #region API Endpoints

        private const string BookInfo = @"http://www.Goodreads.com/book/show/{1}?format=xml&key={0}";

        private const string BookSearch = @"http://www.Goodreads.com/search.xml?key={0}&q={1}";

        private const string AuthorInfo = @"http://www.Goodreads.com/author/show/{1}.xml?key={0}";

        private const string AuthorSearch = @"http://www.Goodreads.com/api/author_url/{1}?key={0}";

        #endregion

        #region Public Properties

        public string ApiKey { get; set; }

        #endregion

        #region Constructor

        public Goodreads(string apiKey)
        {
            ApiKey = apiKey;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Search for a book using the title as the seach query.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="numResults">Limit to the first x number of results.</param>
        /// <returns>The collection of books matching the query.</returns>
        public async Task<IEnumerable<Book>> SearchForBookAsync(string title, int numResults = 10)
        {
            string url = String.Format(BookSearch, ApiKey, FormatQuery(title));
            var response = await GetXmlResponse(url);

            return XmlParser.ParseBookSearchResults(response, numResults);
        }
        
        /// <summary>
        /// Seach for a book using the Goodreads ID as the seach query.
        /// </summary>
        /// <param name="id">The Goodreads ID.</param>
        /// <returns>The book.</returns>
        public Book SearchForBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search for an author using their name as the search query.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <returns>The author matching the query.</returns>
        public async Task<Author> SearchForAuthorAsync(string name)
        {
            string url = String.Format(AuthorSearch, ApiKey, FormatQuery(name));
            var response = await GetXmlResponse(url);

            return XmlParser.ParseAuthorSearchResults(response);
        }

        /// <summary>
        /// Gets info about an author using its Goodreads ID.
        /// </summary>
        /// <param name="id">The author's Goodreads ID.</param>
        /// <returns>The author's information as a new <see cref="Author"/> object.</returns>
        public async Task<Author> GetAuthorInfoAsync(int id)
        {
            string url = String.Format(AuthorInfo, ApiKey, id);
            var response = await GetXmlResponse(url);

            return XmlParser.ParseAuthorInfoResults(response);
        }

        /// <summary>
        /// Gets info about a book using its Goodreads ID.
        /// </summary>
        /// <param name="id">The book's Goodreads ID.</param>
        /// <returns>The book's information as a new <see cref="Book"/> object.</returns>
        public async Task<Book> GetBookInfoAsync(int id)
        {
            string url = String.Format(BookInfo, ApiKey, id);
            var response = await GetXmlResponse(url);

            return XmlParser.ParseBookInfoResults(response);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Format the query for ???
        /// </summary>
        /// <param name="query">The query string to format.</param>
        /// <returns>The formatted query.</returns>
        private string FormatQuery(string query)
        {
            return query.Replace(" ", "+");
        }

        /// <summary>
        /// Gets the XML reponse after querying the Goodreads API.
        /// </summary>
        /// <param name="url">The url to query.</param>
        /// <returns>The XML document containing the response data.</returns>
        private async Task<XDocument> GetXmlResponse(string url)
        {
            using (var client = new HttpClient())
            {
                var responseStream = await client.GetStreamAsync(url);

                return XDocument.Load(responseStream);
            }
        }

        #endregion
    }
}
