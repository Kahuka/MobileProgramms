using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //POST INFO
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public DateTime Date { get; set; }

        // USER INFO
        public string UserPhotoPath { get; set; }
        public string UserName { get; set; }
    }
}
