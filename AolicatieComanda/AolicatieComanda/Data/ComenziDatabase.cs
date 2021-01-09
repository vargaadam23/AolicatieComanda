using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

using System.Threading.Tasks;
using AolicatieComanda.Models;

namespace AolicatieComanda.Data
{  
    public class ComenziDatabase
    {
        readonly SQLiteAsyncConnection _database;
        readonly SQLiteConnection dbsincron;
        public ComenziDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            dbsincron = new SQLiteConnection(dbPath);
            _database.CreateTableAsync<Feluri>().Wait();
            _database.CreateTableAsync<Comanda>().Wait();
            _database.CreateTableAsync<Subcomanda>().Wait();
        }
        public Task<List<Feluri>> GetFeluriAsync()
        {
            return _database.Table<Feluri>().ToListAsync();
        }
        public Task<List<Comanda>> GetComenziAsync()
        {
            return _database.Table<Comanda>().ToListAsync();
        }
        public Task<List<Subcomanda>> GetSubcomenziAsync()
        {
            return _database.Table<Subcomanda>().ToListAsync();
        }
        public Task<Feluri> GetFeluriAsync(int id)
        {
            return _database.Table<Feluri>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveSubcomandaAsync(Subcomanda slist)
        {
                return _database.InsertAsync(slist);
        }
        
        public Task<int> SaveFelAsync(Feluri slist)
        {
            return _database.InsertAsync(slist);
        }
        public Task<int> SaveComandaAsync(Comanda slist)
        {
            return _database.InsertAsync(slist);
        }
        public Task<int> SaveFeluriAsync(Feluri slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteFeluriAsync(Feluri slist)
        {
            return _database.DeleteAsync(slist);
        }
        public int GetComanda()
        {
            List<Comanda> lista=dbsincron.Query<Comanda>("SELECT ID FROM Comanda ORDER BY ID DESC LIMIT 1");
            if (lista.Count > 0)
            {
                return lista[0].ID;
            }
            return 0;
        }
    }
}
