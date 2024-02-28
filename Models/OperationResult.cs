namespace EasyXNoteApp.Models
{
    public struct OperationResult
    {
        public bool success { get; }
        public string message { get; }

        public OperationResult(bool success, string message)
        {
            this.success = success; 
            this.message = message; 
        }
    }
}