namespace Corona_Wars
{
    // An product available in the game.
    public class EssentialSupply
    {
        public string SupplyName { get; }
        public int Size { get; }
        public double MinPrice { get; }
        public double MaxPrice { get; }

        public EssentialSupply(string supplyName, int size, int minPrice, int maxPrice)
        {
            SupplyName = supplyName;
            Size = size;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}