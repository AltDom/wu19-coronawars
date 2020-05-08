namespace Corona_Wars
{
    // An item added to the player's car boot.
    public class BootItem
    {
        public string SupplyName { get; set; }
        public int Size { get; }
        public int Quantity { get; set; }
        
        public BootItem(string supplyName, int size, int quantity)
        {
            SupplyName = supplyName;
            Size = size;
            Quantity = quantity;
        }
    }
}