using GoodreadsDotNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GoodreadsDotNET
{
    /// <summary>
    /// Parses Goodreads XML responses.
    /// </summary>
    public static class XmlParser
    {
        public static IEnumerable<Book> ParseBookSearchResults(XDocument response, int numResults)
        {
            var books = from book in response.Descendants("work").Take(numResults)
                        select ParseBook(book, book.Element("best_book"));

            return books;
        }

        public static Author ParseAuthorSearchResults(XDocument response)
        {
            var author = from a in response.Descendants("author")
                         select new Author(a.Element("name").Value, int.Parse(a.Attribute("id").Value), a.Element("link").Value);

            return author.First();
        }

        public static Book ParseBookInfoResults(XDocument response)
        {
            var book = (from b in response.Descendants("book")
                       select ParseBookInfo(b)).FirstOrDefault();

            return book;
        }

        public static Author ParseAuthorInfoResults(XDocument response)
        {
            var author = (from a in response.Descendants("author")
                         select ParseAuthor(a)).FirstOrDefault();

            author.Books.AddRange(from books in response.Descendants("books")
                                  select ParseBookInfo(books.Element("book")));
            
            return author;
        }

        #region Helper Methods

        internal static Book ParseBook(XElement root, XElement xmlBook)
        {
            var book = new Book();
            book.ID = xmlBook.Element("id").IntValue();
            book.Title = xmlBook.Element("title").Value;
            book.CoverLink = xmlBook.Element("image_url").Value;
            book.CoverSmallLink = xmlBook.Element("small_image_url").Value;
            book.Authors.AddRange(from author in xmlBook.Descendants("author")
                                  select new Author(author.Element("name").Value, author.Element("id").IntValue()));
            book.OriginalPublicationDate = ParseDate(root, true);
            book.RatingsCount = root.Element("ratings_count").IntValue();
            book.AverageRating = root.Element("average_rating").DoubleValue();

            return book;
        }

        internal static Book ParseBookInfo(XElement xmlBook)
        {
            var book = new Book();
            book.ID = xmlBook.Element("id").IntValue();
            book.Isbn10 = xmlBook.Element("isbn").IntValue();
            book.Isbn13 = xmlBook.Element("isbn13").LongValue();
            book.RatingsCount = xmlBook.Element("text_reviews_count").IntValue();
            book.Title = xmlBook.Element("title").Value;
            book.CoverLink = xmlBook.Element("image_url").Value;
            book.CoverSmallLink = xmlBook.Element("small_image_url").Value;
            book.Link = xmlBook.Element("link").Value;
            book.NumPages = xmlBook.Element("num_pages").IntValue();
            book.Format = xmlBook.Element("format").Value;
            book.Edition = xmlBook.Element("edition_information").Value;
            book.Publisher = xmlBook.Element("publisher").Value;
            book.PublicationDate = ParseDate(xmlBook, false);
            book.AverageRating = xmlBook.Element("average_rating").DoubleValue();
            book.RatingsCount = xmlBook.Element("ratings_count").IntValue();
            book.Description = xmlBook.Element("description").Value;
            book.Authors.AddRange(from authors in xmlBook.Descendants("authors")
                                  select ParseAuthorBasic(authors.Element("author")));
            book.Series = (from series in xmlBook.Descendants("series")
                          select ParseSeriesBasic(series)).FirstOrDefault();
            return book;
        }

        internal static DateTime ParseDate(XElement node, bool isOriginalPublicationDate)
        {
            string q = "{0}publication_{1}";
            string original = isOriginalPublicationDate ? "original_" : "";
            int year, month, day;

            int.TryParse(node.Element(String.Format(q, original, "year")).Value, out year);
            int.TryParse(node.Element(String.Format(q, original, "month")).Value, out month);
            int.TryParse(node.Element(String.Format(q, original, "day")).Value, out day);

            // Month/day were null in the XML response so default to 1
            if (month == 0 || day == 0)
                return new DateTime(year, 1, 1);
            else
                return new DateTime(year, month, day);
        }

        internal static Author ParseAuthor(XElement xmlAuthor)
        {
            var author = new Author();
            author = ParseAuthorBasic(xmlAuthor);
            author.NumFans = xmlAuthor.Element("fans_count").IntValue();
            author.About = xmlAuthor.Element("about").Value;
            // TODO: parse influences
            author.NumWorks = xmlAuthor.Element("works_count").IntValue();
            author.Gender = xmlAuthor.Element("gender").Value.ToGender();
            author.Hometown = xmlAuthor.Element("hometown").Value;
            author.DateOfBirth = DateTime.Parse(xmlAuthor.Element("born_at").Value);
            author.DateOfDeath = DateTime.Parse(xmlAuthor.Element("died_at").Value);

            return author;
        }

        /// <summary>
        /// Parses the basic information from the XML response (ID, name, image links, Goodreads link).
        /// </summary>
        /// <param name="xmlAuthorBasic">The XML node containing the information.</param>
        /// <returns>The parsed <see cref="Author"/>.</returns>
        internal static Author ParseAuthorBasic(XElement xmlAuthorBasic)
        {
            var author = new Author();
            author.Name = xmlAuthorBasic.Element("name").Value;
            author.ID = xmlAuthorBasic.Element("id").IntValue();
            author.Link = xmlAuthorBasic.Element("link").Value;
            author.ImageLink = xmlAuthorBasic.Element("image_url").Value;
            author.ImageSmallLink = xmlAuthorBasic.Element("small_image_url").Value;

            return author;
        }

        internal static Series ParseSeriesBasic(XElement xmlSeries)
        {
            var series = new Series();
            series.ID = xmlSeries.Element("id").IntValue();
            series.Title = xmlSeries.Element("title").Value.Trim();
            series.Description = xmlSeries.Element("description").Value.Trim();
            series.Note = xmlSeries.Element("note").Value.Trim();
            series.Count = xmlSeries.Element("series_works_count").IntValue();
            series.PrimaryCount = xmlSeries.Element("primary_work_count").IntValue();

            return series;
        }

        #endregion
    }
}
