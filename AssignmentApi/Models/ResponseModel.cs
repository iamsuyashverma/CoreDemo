using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace AssignmentApi.Models
{
    public class ResponseModel
    {
        public ResponseModel() { }
        public ResponseModel(int StatusCode, object? Value = null) =>
        (statusCode, result) = (StatusCode, Value);
        public int statusCode { get; set; }
        public string message { get; set; } = "Request successful.";
        public bool isError { get; set; }
        public object responseException { get; set; }
        public object result { get; set; }
    }
}
