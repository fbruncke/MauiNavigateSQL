using MauiNavigateSQL.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNavigateSQL.Services
{
    public class ItemDatabase
    {
        SQLiteAsyncConnection dbConnection;
        public ItemDatabase()
        {
        }

        //Lazy initialization of DB
        async Task Init()
        {
            if (dbConnection is not null)
                return;

            SQLitePCL.Batteries.Init();
            dbConnection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await dbConnection.CreateTableAsync<Item>();
        }

        /// <summary>
        /// fetch all item entries
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetItemsAsync()
        {
            await Init();
            return await dbConnection.Table<Item>().ToListAsync();
        }

        /// <summary>
        /// Save an Item to the DB, if the item PK exists, then just update the existing item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> SaveItemAsync(Item item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await dbConnection.UpdateAsync(item);
            }
            else
            {
                return await dbConnection.InsertAsync(item);
            }
        }

        /// <summary>
        /// Using SQL for fetching all items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetItemsAsyncWithSQL()
        {
            await Init();

            //sql version
            return await dbConnection.QueryAsync<Item>("SELECT * FROM [Item] WHERE [Price] = 42");

            //linq version
            //return await dbConnection.Table<Item>().Where(item => item.Price == 42).ToListAsync();
        }
    }
}
