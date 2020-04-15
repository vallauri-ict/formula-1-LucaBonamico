using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneDll;

namespace FormulaOneBatchConsoleProject
{
    class Program
    {
        static DbTools db = new DbTools();

        static string[] tables = new string[] {
            "Countries",
            "Drivers",
            "Teams",
            "Circuits",
            "Races",
            "RacesScores",
            "Scores"
        };

        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                Console.WriteLine("*** FORMULA ONE - BATCH SCRIPTS ***");
                Console.WriteLine("C - Create all db");
                Console.WriteLine("S - Set all constraints");
                Console.WriteLine("D - Drop all db");
                Console.WriteLine("E - Export to JSON");
                Console.WriteLine("------------------------");
                Console.WriteLine("X - EXIT");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case 'C':
                        createDB();
                        break;
                    case 'S':
                        setConstraints();
                        break;
                    case 'D':
                        resetDB();
                        break;
                    case 'E':
                        string path = @"C:\Dati\db.json";
                        path = Environment.ExpandEnvironmentVariables(path);
                        if (db.SerializeToJSON<Team>(path))
                            Console.WriteLine("OK.");
                        else
                            Console.WriteLine("Error...");
                        break;
                    case 'x': case 'X':
                        Console.WriteLine("\nUscita in corso...\n");
                        break;
                    default:
                        Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (scelta != 'X' && scelta != 'x');
        }

        private static void resetDB()
        {
            char scelta = ' ';
            Console.Write("ATTENIONE!!! Questo script resetterà il database. Sei sicuro di proseguire?[s/n] ");
            scelta = Console.ReadKey().KeyChar;
            if (scelta == 's' || scelta == 'S') {
                foreach (string table in tables.Reverse())
                {
                    CallDropTable(table);
                }
                Console.WriteLine("\nDB reset completed\n");
            }
            else
            {
                Console.WriteLine("Operazione annullata");
            }
        }

        static bool CallExecuteSqlScript(string scriptName)
        {
            try
            {
                db.ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine($"\nCreate {scriptName} - SUCCESS");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCreate {scriptName} - ERROR: {ex.Message}\n");
                return false;
            }
        }

        static bool CallDropTable(string tableName)
        {
            try
            {
                db.DropTable(tableName);
                Console.WriteLine($"\nDROP {tableName} - SUCCESS");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nDROP {tableName} - ERROR:{ex.Message}\n");
                return false;
            }
        }

        private static void createDB()
        {
            foreach (string table in tables)
            {
                CallExecuteSqlScript(table);
            }
        }

        private static void setConstraints()
        {
            CallExecuteSqlScript("SetConstraints.sql");
        }
    }
}
