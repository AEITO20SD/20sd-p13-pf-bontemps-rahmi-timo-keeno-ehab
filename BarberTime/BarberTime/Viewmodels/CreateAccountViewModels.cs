using BarberTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BarberTime
{
    public class CreateAccountViewModels
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // variable for the SQLite connection
        private SQLiteConnection conn;

        private void Init()
        {
            // code to initialize the repository
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CreateAccount>();
        }

        public CreateAccountViewModels(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewPersonAsync(string name, string email, string password, string number)
        {
            int result = 0;
            try
            {
                // verify the database is initialized
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                if (string.IsNullOrEmpty(email))
                    throw new Exception("Valid email required");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("Valid password is required");

                if (string.IsNullOrEmpty(number))
                    throw new Exception("Valid numeber is required");

                // TODO: Insert the new person into the database
                result = conn.Insert(new CreateAccount { Name = name, Email = email, Password = password, Phone_number = number });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name, email, password, number);
                await Shell.Current.GoToAsync("//MainPage");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add");
            }

        }

        //public List<CreateAccount> GetAllPeople()
        //{
        //    // TODO: Init then retrieve a list of Person objects from the database into a list
        //    try
        //    {
        //        Init();
        //        return conn.Table<CreateAccount>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        //    }

        //    return new List<CreateAccount>();
        //}
    }
}