using SQLite;
using TutorMe.Models;
using System.Linq;


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
            connection.CreateTableAsync<Utilisateur>();
            connection.CreateTableAsync<MatchingInfo>();
            connection.CreateTableAsync<Rencontres>();
        }

        public async Task InitializeAsync()
        {
            // Création de la table Utilisateur s'il elle n'existe pas encore
            await connection.CreateTableAsync<Utilisateur>();

            // Essayer de récupérer l'utilisateur admin de la base de données
            var adminUser = await connection.Table<Utilisateur>().FirstOrDefaultAsync(u => u.Username == "admin");

            // Si l'utilisateur admin n'existe pas, le créer
            if (adminUser == null)
            {
                // Création de l'utilisateur admin
                adminUser = new Utilisateur
                {
                    Username = "admin",
                    Password = "123", // Vous devez utiliser un mot de passe sécurisé ici
                    isAdmin = true // Marquer l'utilisateur comme administrateur
                };

                // Insérer l'utilisateur admin dans la base de données
                await connection.InsertAsync(adminUser);
            }
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

        public async Task<List<Rencontres>> GetRencontres()
        {
            return await connection.Table<Rencontres>().ToListAsync();
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

        public async Task<Utilisateur> GetUserByUsername(string username)
        {
            return await connection.Table<Utilisateur>().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<Person>> GetAllEtudiants()
        {
            return await connection.Table<Person>().ToListAsync();
        }

        public async Task<List<Tuteur>> GetAllTuteurs()
        {
            return await connection.Table<Tuteur>().ToListAsync();
        }




        // Création données

        public async Task AddUser(string username, string password, bool isTutor )
        {
            // Create a new Utilisateur object
            var user = new Utilisateur
            {
                Username = username,
                Password = password,
                isTutor = isTutor,
                
            };

            // Insert the user into the Utilisateur table
            await connection.InsertAsync(user);
        }


        public async Task AddAdminUser(string username, string password)
        {
            var adminUser = new Utilisateur
            {
                Username = username,
                Password = password,
                isTutor = true, // Définir l'administrateur comme un tuteur si nécessaire
                isAdmin = true // Marquer l'utilisateur comme administrateur
            };

            await connection.InsertAsync(adminUser);
        }

        public async Task DeleteAllUsers()
        {
            // Exécute une requête SQL pour supprimer tous les enregistrements de la table Utilisateur
            await connection.DeleteAllAsync<Utilisateur>();
            await connection.DeleteAllAsync<Tuteur>();
            await connection.DeleteAllAsync<Person>();
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            // Retrieve the user record from the database based on the username
            var user1 = await connection.Table<Utilisateur>().Where(u => u.Username == username).FirstOrDefaultAsync();

            if (user1 != null)
            {
                // Verify the provided password against the stored password
                return password == user1.Password;
            }

            // If no user found or password doesn't match, return false
            return false;
        }
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