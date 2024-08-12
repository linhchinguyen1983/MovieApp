using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Movies
    {
        [Key]
        public Guid Id { get; set; }

        private string _title;
        private int? _ageRating;
        private DateTime _releaseDate { set => _releaseDate = DateTime.Now;  }
        private int _status;
        private string _url;
        private string _poster;

        public string Title { get => _title; set => _title = value == null ? "null" : value; }
        public string Description { get; set; }
        public int? AgeRating
        {
            get => _ageRating;
            set
            {
                if (value < 0) { _ageRating = 0; }
                if(value == null) { _ageRating = 0; }
                else { _ageRating = value; }
            }
        }
        public int Status { get => _status; set => _status = value; }
        public string Url { get => _url; set => _url = value; }
        public string Poster { get => _poster; set => _poster = value; }

        //Properties navigation
        public Genres Genre {  get; set; }
        public Actors Actors { get; set; }
    }
}
