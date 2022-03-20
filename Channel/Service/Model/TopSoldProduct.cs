using System.Text;

namespace Service.Model
{
    public class TopSoldProduct
    {
        public string Gtin { get; }
        public string Description { get; }
        public int TotalQuantity { get; }

        public TopSoldProduct(string gtin, string description, int totalQuantity)
        {
            Gtin = gtin;
            Description = description;
            TotalQuantity = totalQuantity;
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("  Description: ").Append(Description).Append("\n");
            stringBuilder.Append("  Gtin: ").Append(Gtin).Append("\n");
            stringBuilder.Append("  TotalQuantity: ").Append(TotalQuantity).Append("\n");
            return stringBuilder.ToString();
        }
    }
}
