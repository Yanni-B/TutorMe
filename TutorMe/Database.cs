using SQLite;
using TutorMe.Models;

namespace TutorMe
{
    public class Database

    {

        private const string DB_NAME = "db.db3";
        private readonly SQLiteAsyncConnection connection;

        public Database()
        {


            // Création BD
            connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3"));
            connection.CreateTableAsync<Person>();
            connection.CreateTableAsync<Tuteur>();
            connection.CreateTableAsync<Eval>();
            connection.CreateTableAsync<Rapport>();
        }

        // Connexion
        public async Task<List<Person>> GetClients()
        {
            return await connection.Table<Person>().ToListAsync();
        }

        public async Task<List<Tuteur>> GetTuteurs()
        {
            return await connection.Table<Tuteur>().ToListAsync();
        }

        public async Task<List<Eval>> GetEvalTuteurs()
        {
            return await connection.Table<Eval>().ToListAsync();
        }

        public async Task<List<Rapport>> GetRapport()
        {
            return await connection.Table<Rapport>().ToListAsync();
        }

        // Chercher l'ID
        public async Task<Person> GetByIdPerson(int id)
        {
            return await connection.Table<Person>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tuteur> GetByIdTuteur(int id)
        {
            return await connection.Table<Tuteur>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Eval> GetByIdEvalTuteur(int id)
        {
            return await connection.Table<Eval>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Rapport> GetByIdRapport(int id)
        {
            return await connection.Table<Rapport>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        // Création données
        public async Task Create(Person client)
        {
            await connection.InsertAsync(client);
        }

        public async Task Create(Tuteur tuteur)
        {
            await connection.InsertAsync(tuteur);
        }

        public async Task Create(Eval Eval)
        {
            await connection.InsertAsync(Eval);
        }

        public async Task Create(Rapport rapport)
        {
            await connection.InsertAsync(rapport);
        }
    }
}



/*
   SOURCE :
   https://learn.microsoft.com/fr-fr/training/modules/store-local-data/4-exercise-store-data-locally-with-sqlite
   https://youtu.be/VziMUc-VQko?si=FeJ1QJWf-yCqF44P
*/