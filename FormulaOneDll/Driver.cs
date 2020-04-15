using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract(Name = "driver")]
    public class Driver
    {
        #region Attributes
        [DataMember(Name="id")]
        private readonly int id;
        [DataMember(Name = "firstname")]
        private string firstname;
        [DataMember(Name = "lastname")]
        private string lastname;
        [DataMember(Name = "dob")]
        private DateTime dob;
        [DataMember(Name = "placeOfBirth")]
        private string placeOfBirth;
        [DataMember(Name = "country")]
        private Country country;
        [DataMember(Name = "img")]
        private string img;
        [DataMember(Name = "description")]
        private string description;
        #endregion

        #region Constructors
        public Driver() { }

        public Driver(int id) { this.id = id; }

        public Driver(int id, string firstname, string lastname, DateTime dob, string placeOfBirthday, Country country, string img, string description) : this (id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Dob = dob;
            this.PlaceOfBirth = placeOfBirthday;
            this.Country = country;
            this.Img = img;
            this.Description = description;
        }
        #endregion

        #region Properties
        public int Id { get => id; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public Country Country { get => country; set => country = value; }
        public string Img { get => img; set => img = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Firstname} {this.lastname}";
        }
        #endregion
    }
}
