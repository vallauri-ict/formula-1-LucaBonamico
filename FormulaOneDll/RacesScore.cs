using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract(Name = "racesScores")]
    public class RacesScore
    {
        #region Attributes
        [DataMember(Name = "id")]
        private readonly int id;
        [DataMember(Name = "driver")]
        private Driver driver;
        [DataMember(Name = "pos")]
        private Score pos;
        [DataMember(Name = "race")]
        private Race race;
        [DataMember(Name = "fastestLap")]
        private string fastestLap;
        #endregion

        #region Constructors
        public RacesScore() { }

        public RacesScore(int id) { this.id = id; }

        public RacesScore(int id, Driver driver, Score pos, Race race, string fastestLap) : this(id)
        {
            this.Driver = driver;
            this.Pos = pos;
            this.Race = race;
            this.FastestLap = fastestLap;
        }

        #endregion

        #region Properties

        public int Id => id;
        public Driver Driver { get => driver; set => driver = value; }
        public Score Pos { get => pos; set => pos = value; }
        public Race Race { get => race; set => race = value; }
        public string FastestLap { get => fastestLap; set => fastestLap = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Driver.Lastname} - {this.Pos.Scores}";
        }
        #endregion
    }
}
