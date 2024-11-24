namespace Matala1_ASP.BL
{
    public class Movie
    {
        int id;
        string title;
        double rating;
        int income;
        int releaseYear;
        int duration;
        string language;
        string description;
        string genre;
        string photoUrl;
        static List<Movie> MovieList = new List<Movie>();

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public double Rating { get => rating; set => rating = value; }
        public int Income { get => income; set => income = value; }
        public int ReleaseYear { get => releaseYear; set => releaseYear = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Language { get => language; set => language = value; }
        public string Description { get => description; set => description = value; }
        public string Genre { get => genre; set => genre = value; }
        public string PhotoUrl { get => photoUrl; set => photoUrl = value; }

        static public bool Insert(Movie movieTOInsert)
        {
            foreach (var movie in MovieList)
            {
                if (movie.Id == movieTOInsert.Id)
                {
                    return false;
                }
            }
            try
            {
                MovieList.Add(movieTOInsert);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        static public List<Movie> Read()
        {
            return MovieList;
        }

        // New Methods
        static public List<Movie> ReadByRating(double rating)
        {
            return MovieList.Where(movie => movie.Rating >= rating).ToList();
        }

        static public List<Movie> ReadByDuration(double duration)
        {
            return MovieList.Where(movie => movie.Duration <= duration).ToList();
        }
    }
}
