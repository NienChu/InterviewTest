using System.Text.Json.Serialization;

namespace OrderCheck.Model {
    public class ErrorResponse {

        public ErrorResponse(string message) {
            Message = message;
        }

        [JsonPropertyName("message")]
        public string Message { get; set; } = "發生錯誤";
    }
}
