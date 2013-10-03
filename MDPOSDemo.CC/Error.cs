namespace MDPOSDemo.CC
{
    public class Error
    {
        public Error()
        {
            
        }

        public Error(string errorMessage)
        {
            Message = errorMessage;
        }

        public string Message { get; set; }
        public int Code { get; set; }
    }
}