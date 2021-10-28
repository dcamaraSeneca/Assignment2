using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assignment2
{
    class NetworkingManager
    {
        private string url = "https://www.omdbapi.com/?apikey=b22ec629&s=";
        private string url2 = "&r=json";
        private string url3 = "&plot=full";
        private string url4 = "&page=";
        private string urlMovie = "https://www.omdbapi.com/?apikey=b22ec629&i=";

        HttpClient client = new HttpClient();


        public NetworkingManager()
        {
        }

        public async Task<ShortMovieList> getMovies(string qry)
        {
            string completeURL = url +qry + url2;
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ShortMovieList();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (jsonString);
                
                //Stores Response success
                var a2 = dic.ElementAt(dic.Count - 1);
              
                //Stores Total results
                var a3 = dic.ElementAt(dic.Count - 2);

                //Testing to see if the response was false
                if (a2.Value.ToString() != "True")
                {
                    return new ShortMovieList("0", a2.Value.ToString(), new List<ShortMovie>());
                }
                else
                {
                    var array = dic.ElementAt(0).Value;
                    var movieList = JsonConvert.DeserializeObject<List<ShortMovie>>
                         (array.ToString());
                    return new ShortMovieList(a3.Value.ToString(), a2.Value.ToString(), movieList);
                }
            }
        }

        public async Task<ShortMovieList> getMovies(string qry, int i)
        {
            string completeURL = url + qry + url2 + url4 + i;
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ShortMovieList();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (jsonString);

                //Stores Response success
                var a2 = dic.ElementAt(dic.Count - 1);

                //Stores Total results
                var a3 = dic.ElementAt(dic.Count - 2);

                //Testing to see if the response was false
                if (a2.Value.ToString() != "True")
                {
                    return new ShortMovieList("0", a2.Value.ToString(), new List<ShortMovie>());
                }
                else
                {
                    var array = dic.ElementAt(0).Value;
                    var movieList = JsonConvert.DeserializeObject<List<ShortMovie>>
                         (array.ToString());
                    return new ShortMovieList(a3.Value.ToString(), a2.Value.ToString(), movieList);
                }
            }
        }

        public async Task<Movie> getMovie(string id)
        {
            
            string completeURL = urlMovie + id + url2 + url3;
           
            var response = await client.GetAsync(completeURL);
           
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
            
                return new Movie();
            }
            else
            {
               
                var jsonString = await response.Content.ReadAsStringAsync();
           
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
      
                return new Movie(dic.ElementAt(0).Value.ToString(), 
                    dic.ElementAt(1).Value.ToString(),
                    dic.ElementAt(2).Value.ToString(),
                    dic.ElementAt(5).Value.ToString(),
                    dic.ElementAt(6).Value.ToString(),
                    dic.ElementAt(7).Value.ToString(),
                    dic.ElementAt(8).Value.ToString(),
                    dic.ElementAt(9).Value.ToString(),
                    dic.ElementAt(13).Value.ToString(),
                    id);
            }
        }
    }
}
