using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndObjects
{

    class Program
    {
        class movie
        {
            public string title;
            public string rating;
            public string year;

            public movie(string _title, string _rating, string _year)
            {
                title = _title;
                rating = _rating;
                year = _year;

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filepath = @"C:C:\Users\opilane\samples";
            string fileName = @"imbd.txt";
            //a list to store the movies from the file
            List <string> movieList = File.ReadAllLines(Path.Combine(filepath, fileName)).ToList();
            List<movie> listOfMovies = new List<movie>();

            foreach(string movieItem in movieList)
            {
                string[] tempArray = movieItem.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                movie newMovie = new movie(tempArray[0], tempArray[1], tempArray[2]);

                listOfMovies.Add(newMovie);

            }

            foreach(movie movie in listOfMovies)
            {
                Console.WriteLine($"Title: {movie.title}; Rating: {movie.rating}; Year: {movie.year}");

            }
            Console.WriteLine("what is your favourite movie: ");
            string FavmovieTitle = Console.ReadLine();
            Console.WriteLine("Enter your favourite movie rating");
            string FavMovieRating = Console.ReadLine();
            Console.WriteLine("Enter the release year");
            string FavMovieYear = Console.ReadLine();


            movie FavMovie = new movie(FavmovieTitle, FavMovieRating, FavMovieYear);
            string FavMovieLine = $"{FavMovie.title};{ FavMovie.rating};{FavMovie.year}";

            movieList.Add(FavMovieLine);
            File.WriteAllLines(Path.Combine(filepath ,fileName), movieList);



        }
    }
}
