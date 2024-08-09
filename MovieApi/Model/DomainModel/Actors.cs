using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class Actors
    {
        [Key]
        public Guid Id { get; set; }

        private string _fullName;
        private DateTime _birthdate;
        private bool _sex;
        private string _country;
        private byte[] _avatar;
        private DateTime _lastUpdate { set => _lastUpdate = DateTime.Now; }

        public string FullName { get { return _fullName; } set {  _fullName = value; } }
        public DateTime Birthdate { get { return _birthdate; } set { _birthdate = value; } }
        public bool Sex { get { return _sex; } set { _sex = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public byte[] Avatar { get { return _avatar;} set { _avatar = value; } }
    }
}
