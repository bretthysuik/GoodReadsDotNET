using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReadsDotNET.Entities
{
    public class Series
    {
        public string Title { get; set; }

        public int ID { get; set; }

        public int Count { get; set; }

        public List<Book> Books { get; set; }

        public string Description { get; set; }

        public Series(string title, int id, int count)
        {
            Title = title;
            ID = id;
            Count = count;
        }
    }
}
