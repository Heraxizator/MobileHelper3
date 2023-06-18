using MobileHelper.Models.Tables;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public class SqliteDB
    {
        private SQLiteConnection db { get; set; }
        private string databasePath { get; set; }

        public SqliteDB()
        {
            Init();
        }
        public async void Init()
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data.db");

            db = new SQLiteConnection(databasePath);

            await CreateTableAsync<Technique>();

        }

        public async Task<int> GetCountAsync<T>() where T : new()
        {
            return await Task.Run(() =>
            {
                return db.Table<T>().Count();
            });
        }

        public async Task<List<T>> GetListAsync<T>() where T : new()
        {
            return await Task.Run(() =>
            {
                return db.Table<T>().ToList();
            });
        }
        public async Task CreateTableAsync<T>()
        {
            await Task.Run(() =>
            {
                db.CreateTable<T>();
            });
        }

        public async Task DeleteAllAsync<T>()
        {
            await Task.Run(() =>
            {
                db.DeleteAll<T>();
            });
        }

        public async Task InsertAsync<T>(T item)
        {
            await Task.Run(() =>
            {
                db.Insert(item);
            });
        }

        public async Task InsertAllAsync<T>(List<T> items)
        {
            await Task.Run(() =>
            {
                db.InsertAll(items);
            });
        }

        public async Task UpdateAsync<T>(T item)
        {
            await Task.Run(() =>
            {
                db.Update(item);
            });
        }

        public async Task UpdateAllAsync<T>(List<T> items)
        {
            await Task.Run(() =>
            {
                db.UpdateAll(items);
            });
        }

        public async Task QueryAsync<T>(string query) where T : new()
        {
            await Task.Run(() =>
            {
                db.Query<T>(query);
            });
        }

        public async Task<T> GetElementById<T>(int id) where T : new()
        {
            return await Task.Run(async () =>
            {
                var list = await GetListAsync<T>();
                return list[id];
            });
        }
        
    }
}
