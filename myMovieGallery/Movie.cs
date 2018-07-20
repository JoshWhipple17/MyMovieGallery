using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMovieGallery
{
     public class Movie
    {
        // fields
        private int? id = null;
        private string title = null;
        private string genre = null;
        private int? year = null;
        private string format = null;
        private string synopsis = null;

        // properties
        public int? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }
        public int? Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public string Format
        {
            get
            {
                return format;
            }
            set
            {
                format = value;
            }
        }
        public string Synopsis
        {
            get
            {
                return synopsis;
            }
            set
            {
                synopsis = value;
            }
        }

    }
}
