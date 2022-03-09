namespace backend.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(List<string> errors)
        {
            Message = errors;
        }

        public ErrorViewModel(string error)
        {
            Message.Add(error);
        }
        public List<string> Message { get; private set; } = new();
    }
}