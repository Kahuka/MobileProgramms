using System;
using System.Collections.Generic;
using System.Text;

namespace MugShot.Model
{
    public class Root
    {
        public int status { get; set; }
        public int next_page { get; set; }
        public List<Record> records { get; set; }
        public int current_page { get; set; }
        public int total_records { get; set; }
        public string msg { get; set; }
    }
    public class Record
    {
        public string county_state { get; set; }
        public string name { get; set; }
        public List<string> charges { get; set; }
        public int id { get; set; }
        public string source { get; set; }
        public string book_date_formatted { get; set; }
        public string mugshot { get; set; }
        public string book_date { get; set; }
        public string source_id { get; set; }
        public string more_info_url { get; set; }
    }


}
