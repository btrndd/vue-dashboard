namespace backend.DTOs
{
    public class ResultDTO<T>
    {
        public ResultDTO(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public ResultDTO(T data)
        {
            Data = data;
        }
        public ResultDTO(string message)
        {
            Message = message;
        }
        
        public T Data { get; private set; }
        public string Message { get; set; }
    }
}