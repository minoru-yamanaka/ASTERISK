namespace Asterisk.Shared.Queries
{
    public class GenericQueryResult : IQueryResult
    {
        public GenericQueryResult(bool successFailure, string message, object data)
        {
            SuccessFailure = successFailure;
            Message = message;
            Data = data;
        }

        public bool SuccessFailure { get; set; } // true = success message || false = failure message
        public string Message { get; set; } // custom message to help front-end
        public Object Data { get; set; } // return an object (a user, for example)
    }
}
