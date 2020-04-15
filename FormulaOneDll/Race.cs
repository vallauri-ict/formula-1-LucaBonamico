using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{

    [DataContract(Name = "Race")]
    public class Race
    {
        #region Attributes
        [DataMember(Name = "id")]
        private readonly int id;
        [DataMember(Name = "name")]
        private string name;
        [DataMember(Name = "circuit")]
        private Circuit circuit;
        [DataMember(Name = "date")]
        private DateTime date;
        #endregion

        #region Constructors
        public Race () { }

        public Race (int id)
        {
            this.id = id;
        }

        public Race(int id, string name, Circuit circuit, DateTime date) : this(id)
        {
            this.Name = name;
            this.Circuit = circuit;
            this.Date = date;
        }
        #endregion

        #region Properties
        public int Id => id;

        public string Name { get => name; set => name = value; }
        public Circuit Circuit { get => circuit; set => circuit = value; }
        public DateTime Date { get => date; set => date = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{this.id} - {this.Name}";
        }
        #endregion
    }
}
