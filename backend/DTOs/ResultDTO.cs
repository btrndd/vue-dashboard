namespace backend.DTOs
{
    public class ResultDTO<T>
    {
        public ResultDTO(T data, List<string> errors)
        {
            Data = data;
            Message = errors;
        }

        public ResultDTO(T data)
        {
            Data = data;
        }
        public ResultDTO(string error)
        {
            Message.Add(error);
        }
        
        public T Data { get; private set; }
        public List<string> Message { get; private set; } = new();
    }
}