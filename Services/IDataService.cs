using EasyXNoteApp.Models;

namespace EasyXNoteApp.Services
{
    public interface IDataService
    {
        // IEnumerable<string> GetUser();
        string GetUsers();
        OperationResult InsertUser(string jsonData);
        string GetUserProfiles();
        string GetNoteBooks();
        string GetNotes();
    }
}
