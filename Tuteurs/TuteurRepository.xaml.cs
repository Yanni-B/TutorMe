using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CrudTest.Tuteurs;
using Microsoft.WindowsAppSDK.Runtime;

namespace CrudTest.Tuteurs
{
    internal class TuteurRepository
    {
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection("/");
            conn.CreateTable<Tuteur>();
        }

        public void AddTuteur(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Please enter a name");

                result = conn.Insert(new Tuteur { Name = name });
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public void RemoveTuteur(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Please enter a name");

                result = conn.Delete(new Tuteur { Name = name});
            } catch (Exception ex) 
                {
                    throw new Exception("error");
            }
        }


        public List<Tuteur> GetAllTuteurs()
        {
            try
            {
                Init();
                return conn.Table<Tuteur>().ToList();
            }
            catch (Exception ex)
            {
                string StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Tuteur>();
        }
    }

    
}
