using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CrudTest.Etudiant;
using Microsoft.WindowsAppSDK.Runtime;

namespace CrudTest.Etudiant
{
    internal class EtudiantRepository
    {
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection("/");
            conn.CreateTable<Etudiant>();
        }

        public void AddEtudiant(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Please enter a name");

                result = conn.Insert(new Etudiant { Name = name });
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }

        public void RemoveEtudiant(string name)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Please enter a name");

                result = conn.Delete(new Etudiant { Name = name });
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }
        }


        public List<Etudiant> GetAllTuteurs()
        {
            try
            {
                Init();
                return conn.Table<Etudiant>().ToList();
            }
            catch (Exception ex)
            {
                string StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Etudiant>();
        }
    }


}
