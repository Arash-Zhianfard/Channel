using Service.Interfaces;
using System.Text;

namespace Service.Model
{
    public class UpdateStockResponse : BaseReponse<object>
    {
        public object Content { get; set; }
        public int StatusCode { get; set; }
        public int? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("  Content: ").Append(Content).Append("\n");
            stringBuilder.Append("  StatusCode: ").Append(StatusCode).Append("\n");
            stringBuilder.Append("  LogId: ").Append(LogId).Append("\n");
            stringBuilder.Append("  Success: ").Append(Success).Append("\n");
            stringBuilder.Append("  Message: ").Append(Message).Append("\n");
            stringBuilder.Append("  ValidationErrors: ").Append(ValidationErrors).Append("\n");
            return stringBuilder.ToString();
        }

    }
}
