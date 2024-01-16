let me know if this right: using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FirstApp {
    public class PlayerDatabase {
        SQLiteAsyncConnection Database;
        private static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, "PlayerDB.db3");
        private SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public PlayerDatabase() {
        }

        private async Task Init() {
            if (Database == null) {
                Database = new SQLiteAsyncConnection(DatabasePath, Flags);
                await Database.CreateTableAsync<Models.Player>();
            }
        }

        public async Task<List<Models.Player>> GetPlayersAsync() {
            await Init();
            return await Database.Table<Models.Player>().ToListAsync();
        }

        public async Task<Models.Player> GetPlayerAsync(int id) {
            await Init();
            return await Database.Table<Models.Player>()
                .Where(player => player.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SavePlayerAsync(Models.Player player) {
            await Init();
            if (player.ID != 0) //already in database
                return await Database.UpdateAsync(player);
            //not in database
            return await Database.InsertAsync(player);
        }

        public async Task<int> DeletePlayerAsync(Models.Player player) {
            await Init();
            return await Database.DeleteAsync(player);
        }

        public async void ClearDatabase() {
            await Init();
            await Database.DeleteAllAsync<Models.Player>();
        }
    }
}
