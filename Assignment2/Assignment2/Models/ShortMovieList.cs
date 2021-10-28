using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Assignment2.Models
{
    class ShortMovieList
    {

        public string totalResults { get; set; }
        public string Response { get; set; }

        public List<ShortMovie> movies { get; set; }

        public ShortMovieList() { }
        public ShortMovieList(string t, string r, List<ShortMovie> m)
        {
            totalResults = t;
            Response = r;
            movies = m;
        }
    }
}
