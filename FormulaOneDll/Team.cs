using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract(Name = "Team")]
    public class Team
    {
        [DataMember(Name = "id")]
        private int id;
        [DataMember(Name = "name")]
        private string name;
        [DataMember(Name = "fullTeamName")]
        private string fullTeamName;
        [DataMember(Name = "country")]
        private Country country;
        [DataMember(Name = "powerUnit")]
        private string powerUnit;
        [DataMember(Name = "technicalChief")]
        private string technicalChief;
        [DataMember(Name = "chassis")]
        private string chassis;
        [DataMember(Name = "firstDriver")]
        private Driver firstDriver;
        [DataMember(Name = "secondDriver")]
        private Driver secondDriver;
        [DataMember(Name = "img")]
        private string img;

        public Team(int id, string name, string fullTeamName, Country country, string powerUnit, string technicalChief, string chassis, Driver firstDriver, Driver secondDriver, string img)
        {
            this.Id = id;
            this.Name = name;
            this.FullTeamName = fullTeamName;
            this.Country = country;
            this.PowerUnit = powerUnit;
            this.TechnicalChief = technicalChief;
            this.Chassis = chassis;
            this.FirstDriver = firstDriver;
            this.SecondDriver = secondDriver;
            this.Img = img;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FullTeamName { get => fullTeamName; set => fullTeamName = value; }
        public Country Country { get => country; set => country = value; }
        public string PowerUnit { get => powerUnit; set => powerUnit = value; }
        public string TechnicalChief { get => technicalChief; set => technicalChief = value; }
        public string Chassis { get => chassis; set => chassis = value; }
        public Driver FirstDriver { get => firstDriver; set => firstDriver = value; }
        public Driver SecondDriver { get => secondDriver; set => secondDriver = value; }
        public string Img { get => img; set => img = value; }

        public override string ToString()
        {
            return $"{this.Name} ({this.Country.CountryName})";
        }
    }
}
