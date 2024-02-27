namespace EasyXNoteApp.Services
{
    public interface IDataService
    {
        // IEnumerable<string> GetUser();
        string GetUsers();
        string InsertUser(string jsonData);
        string GetUserProfiles();
        string GetNoteBooks();
        string GetNotes();
    }
}
