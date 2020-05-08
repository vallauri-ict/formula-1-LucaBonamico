using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    [DataContract(Name = "scores")]

    public class Score
    {
        #region Attributes
        [DataMember(Name = "pos")]
        private readonly int pos;
        [DataMember(Name = "score")]
        private int score;
        [DataMember(Name = "description")]
        private string description;
        #endregion

        #region Constructors
        public Score() { }

        public Score(int pos) { this.pos = pos; }

        public Score(int pos, int score, string description) : this(pos)
        {
            this.Scores = score;
            this.Description = description;
        }
        #endregion

        #region Properties


        public int Pos => pos;
        public int Scores { get => score; set => score = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.Pos}";
        }
        #endregion
    }
}
