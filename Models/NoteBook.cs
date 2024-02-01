using System;

namespace EasyXNoteApp.Models
{
    public class NoteBook
    {
        public int NoteBookID { get; set; }
        public int UserID { get; set; }
        public string NoteBookName { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
    }
}