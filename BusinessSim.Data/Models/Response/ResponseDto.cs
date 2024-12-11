using System.Net;

namespace BusinessSim.Data.Models.Response
{
    public class ResponseDto<T> : ResponseDto where T : class
    {
        /// <summary>
        /// an object of the specified type containing the response data
        /// </summary>
        public new T? Data { get; set; }
    }

    public class ResponseDto
    {
        /// <summary>
        /// an object of the specified type containing the response data
        /// </summary>
        public object? Data { get; set; }
        
        /// <summary>
        /// a message back to the requestor containing additional details.  Optional. 
        /// </summary>
        public string Message { get; set; } = string.Empty;
        
        
        /// <summary>
        /// a list of string error messages containing additional details.  Optional.
        /// </summary>
        public List<string> Errors { get; set; } = [];
        
        
        /// <summary>
        /// the status code returned back to the user
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        
        /// <summary>
        /// a boolean to indicate whether or not the request completed successfully.
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}
