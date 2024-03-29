﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using Microsoft.SqlServer.Management.Smo;

namespace FormulaOneDll
{
    public class DbTools
    {
        public const string WORKINGPATH = @"C:\Dati\";
        public const string CONNSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Dati\FormulaOne.mdf;Integrated Security=True";

        private Dictionary<string, Country> countries;
        private Dictionary<int, Driver> drivers;
        private Dictionary<int, Circuit> circuits;
        private Dictionary<int, Race> races;
        private Dictionary<int, RacesScore> racesScores;
        private Dictionary<int, Score> scores;

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNSTR);
            var cmd = new SqlCommand("query", con);
            con.Open();
            int i = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine($"\tErrore: {err.Number} - {err.Message}");
                }
            }
            con.Close();
        }

        public void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNSTR);
            var cmd = new SqlCommand($"Drop Table {tableName};", con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                Console.WriteLine($"\tErrore SQL: {err.Number} - {err.Message}");
            }
            con.Close();
        }

        public Dictionary<string, Country> GetCountries()
        {
            if (countries == null)
            {
                countries = new Dictionary<string, Country>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Countries;", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string countryIsoCode = reader.GetString(0);
                        Country country = new Country(countryIsoCode, reader.GetString(1));
                        countries.Add(countryIsoCode, country);
                    }
                    reader.Close();
                }
            }
            return countries;
        }

        public Dictionary<int, Driver> GetDrivers(bool forceReload = false)
        {
            if (forceReload || drivers == null)
            {
                drivers = new Dictionary<int, Driver>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Drivers", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Driver d = new Driver(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3).ToShortDateString(),
                            reader.GetString(4),
                            GetCountries()[reader.GetString(5)],
                            reader.GetString(6),
                            reader.GetString(7)
                        );
                        drivers.Add(d.Id, d);
                    }
                }
            }
            return drivers;
        }

        public Dictionary<int, Circuit> GetCircuits(bool forceReload = false)
        {
            if (forceReload || circuits == null)
            {
                circuits = new Dictionary<int, Circuit>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Circuits", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Circuit c = new Circuit(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            GetCountries()[reader.GetString(4)],
                            reader.GetString(5),
                            reader.GetString(6));
                        circuits.Add(c.Id, c);
                    }
                }
            }
            return circuits;
        }

        public Dictionary<int, Race> GetRaces(bool forceReload = false)
        {
            if (forceReload || races == null)
            {
                races = new Dictionary<int, Race>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Races", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Race r = new Race(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            GetCircuits()[reader.GetInt32(2)],
                            reader.GetDateTime(3)
                        );
                        races.Add(r.Id, r);
                    }
                }
            }
            return races;
        }

        public Dictionary<int, RacesScore> GetRacesScores(bool forceReload = false)
        {
            if (forceReload || racesScores == null)
            {
                racesScores = new Dictionary<int, RacesScore>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM RacesScores", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        RacesScore rS = new RacesScore(
                            reader.GetInt32(0),
                            GetDrivers()[reader.GetInt32(1)],
                            GetScores()[reader.GetInt32(2)],
                            GetRaces()[reader.GetInt32(3)],
                            reader.GetString(4)
                        );
                        racesScores.Add(rS.Id, rS);
                    }
                }
            }
            return racesScores;
        }

        public Dictionary<int, Score> GetScores(bool forceReload = false)
        {
            if (forceReload || scores == null)
            {
                scores = new Dictionary<int, Score>();
                var con = new SqlConnection(CONNSTR);

                using (con)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Scores", con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Score s = new Score(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2)
                        );
                        scores.Add(s.Pos, s);
                    }
                }
            }
            return scores;
        }

        /*public Dictionary<int, RacesScore> GetRaceResults()
        {
            RacesScore[] results = new RacesScore[20];

            var con = new SqlConnection(CONNSTR);

            using (con)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM RacesScores WHERE extRace=@id", con);
                command.Parameters.AddWithValue("@id", 1);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RacesScore rs = new RacesScore(
                        reader.GetInt32(0),
                        GetDrivers()[reader.GetInt32(1)],
                        GetScores()[reader.GetInt32(2)],
                        GetRaces()[reader.GetInt32(3)],
                        reader.GetString(4));
                    
                }
            }

        }*/

        public BindingList<Team> LoadTeams()
        {
            BindingList<Team> retVal = new BindingList<Team>();

            var con = new SqlConnection(CONNSTR);

            using (con)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Teams;", con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string teamCountryCode = reader.GetString(3);
                    // Country teamCountry = GetCountries().Find(item => item.CountryCode == teamCountryCode);
                    Country teamCountry = GetCountries()[teamCountryCode];
                    Driver firstDriver = GetDrivers()[reader.GetInt32(7)];
                    Driver secondDriver = GetDrivers()[reader.GetInt32(8)];

                    Team t = new Team(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        teamCountry,
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        firstDriver,
                        secondDriver,
                        reader.GetString(9),
                        reader.GetString(10)
                    );
                    retVal.Add(t);
                }
                reader.Close();
            }
            return retVal;
        }

        public bool SerializeToJSON<T>(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.AutoFlush = true;
                sw.WriteLine("{");
                sw.WriteLine($"\t\"teams\": {JsonConvert.SerializeObject(LoadTeams(), Formatting.Indented)},");
                sw.WriteLine($"\t\"drivers\": {JsonConvert.SerializeObject(GetDrivers().Values, Formatting.Indented)},");
                sw.WriteLine($"\t\"races\": {JsonConvert.SerializeObject(GetRaces().Values, Formatting.Indented)},");
                sw.WriteLine($"\t\"circuits\": {JsonConvert.SerializeObject(GetCircuits().Values, Formatting.Indented)},");
                sw.WriteLine($"\t\"countries\": {JsonConvert.SerializeObject(GetCountries().Values, Formatting.Indented)}");
                sw.Write("}");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
