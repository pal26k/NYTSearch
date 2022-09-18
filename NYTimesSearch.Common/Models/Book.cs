using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYTimesSearch.Common.Models
{
    public class Result
    {
        public string url { get; set; }
        public string publication_dt { get; set; }
        public string byline { get; set; }
        public string book_title { get; set; }
        public string book_author { get; set; }
        public string summary { get; set; }
        public string uuid { get; set; }
        public string uri { get; set; }
        public List<string> isbn13 { get; set; }
    }

    public class Book
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public List<Result> results { get; set; }
    }
}
