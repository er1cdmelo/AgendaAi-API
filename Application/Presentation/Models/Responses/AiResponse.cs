namespace Application.Models.Responses
{
    public class AiResponse
    {
        public AiResponse()
        {
            code = 0;
            message = "OK";
            errors = new string[0];
            data = string.Empty;
        }
        public int code { get; set; }
        public string message { get; set; }
        public string[] errors { get; set; }
        public string data { get; set; }
    }
}
