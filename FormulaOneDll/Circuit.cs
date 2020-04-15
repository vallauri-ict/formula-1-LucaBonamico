using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract(Name = "Circuit")]
    public class Circuit
    {
        #region Attributes
        [DataMember(Name = "id")]
        private readonly int id;
        [DataMember(Name = "name")]
        private string name;
        [DataMember(Name = "length")]
        private int length;
        [DataMember(Name = "laps")]
        private int laps;
        [DataMember(Name = "country")]
        private Country country;
        [DataMember(Name = "recordLap")]
        private string recordLap;
        [DataMember(Name = "img")]
        private string img;
        #endregion

        #region Constructors
        public Circuit() { }

        public Circuit(int id)
        {
            this.id = id;
        }

        public Circuit(int id, string name, int length, int laps, Country country, string recordLap, string img) : this(id)
        {
            this.Name = name;
            this.Length = length;
            this.Laps = laps;
            this.Country = country;
            this.RecordLap = recordLap;
            this.Img = img;
        }
        #endregion

        #region Properties
        public int Id => id;
        public string Name { get => name; set => name = value; }
        public int Length { get => length; set => length = value; }
        public int Laps { get => laps; set => laps = value; }
        public Country Country { get => country; set => country = value; }
        public string RecordLap { get => recordLap; set => recordLap = value; }
        public string Img { get => img; set => img = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.id} - {this.Name}";
        }
        #endregion
    }
}
