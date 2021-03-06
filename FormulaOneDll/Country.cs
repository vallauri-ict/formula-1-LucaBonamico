﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{

    [DataContract(Name = "Country")]
    public class Country
    {
        [DataMember(Name = "countryCode")]
        private string countryCode;
        [DataMember(Name = "countryName")]
        private string countryName;

        public Country(string countryCode, string countryName)
        {
            this.CountryCode = countryCode;
            this.CountryName = countryName;
        }

        public string CountryCode
        {
            get
            {
                return countryCode;
            }

            set
            {
                countryCode = value;
            }
        }

        public string CountryName
        {
            get
            {
                return countryName;
            }

            set
            {
                countryName = value;
            }
        }

        public override string ToString()
        {
            string stOut = this.CountryName + " (" + this.CountryCode + ")";
            return stOut; 
        }
    }
}
