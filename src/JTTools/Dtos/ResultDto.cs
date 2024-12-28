namespace JTTools.Dtos
{
    public class ResultDto<T> 
    {
        public string Message { get; set; } = "";
        public int Code { get; set; } = 200;
        public T? Result { get; set; } = default;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex)
        {
            Code = 500;
            Message = ex.StackTrace ?? "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Error(string msg)
        {
            Code = 500;
            Message = msg;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Fail(string msg="")
        {
            Code = 400;
            Message = msg;
        }
    }
}
