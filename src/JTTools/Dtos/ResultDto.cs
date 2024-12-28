namespace JTTools.Dtos
{
    public class ResultDto<T> 
    {
        public string Message { get; set; } = "";
        public int Code { get; set; } = 200;
        public T? Result { get; set; } = default;
    }
}
