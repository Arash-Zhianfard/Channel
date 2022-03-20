namespace Service.Model
{
    public class TopSoldProductComparer : IEqualityComparer<TopSoldProduct>
    {
        public new bool Equals(TopSoldProduct? x, TopSoldProduct? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Gtin == y.Gtin && Equals(x.TotalQuantity, y.TotalQuantity)
               && x.Description == y.Description;
        }

        public int GetHashCode(TopSoldProduct obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.GetHashCode();
                hash = hash * 23 + obj.GetHashCode();
                hash = hash * 23 + obj.GetHashCode();
                return hash;
            }
        }
    }
}
