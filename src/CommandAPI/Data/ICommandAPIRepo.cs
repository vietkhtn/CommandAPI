using System.Collections.Generic;
using CommandAPI.Models;

// Khai bao các hàm chức năng xử lý dữ liệu
namespace CommandAPI.Data
{
    public interface ICommandAPIRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById (int id);
        void CreateCommand (Command cmd);
        void UpdateCommand (Command cmd);
        void DeleteCommand (Command cmd);
    }
}