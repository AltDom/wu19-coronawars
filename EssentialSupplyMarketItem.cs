namespace Corona_Wars
{
    // A product available at supermarkets.
    public class EssentialSupplyMarketItem
    {
        public string SupplyName { get; }
        public int Size { get; }
        public int QuantityAvailable { get; set; }
        public int GoingRate { get; }

        public EssentialSupplyMarketItem(string supplyName, int size, int quantityAvailable, int goingRate)
        {
            SupplyName = supplyName;
            Size = size;
            QuantityAvailable = quantityAvailable;
            GoingRate = goingRate;
        }
    }
}