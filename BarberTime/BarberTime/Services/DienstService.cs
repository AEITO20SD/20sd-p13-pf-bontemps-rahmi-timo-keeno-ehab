using BarberTime.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTime.Services
{
    public class DienstService
    {

        private readonly SQLiteConnection _dbConnection;
        public DienstService()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BarberTime.db3");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<DienstenModel>();

        }

        public List<DienstenModel> GetAllDiensten()
        {
            var res = _dbConnection.Table<DienstenModel>().ToList();
            return res;
        }

        public int InsertDienst(DienstenModel obj)
        {
            return _dbConnection.Insert(obj);
        }

        public int UpdateDienst(DienstenModel obj)
        {
            return _dbConnection.Update(obj);
        }

        public int DeleteDienst(DienstenModel obj)
        {
            return _dbConnection.Delete(obj);
        }
    }
}
