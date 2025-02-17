namespace CompanyAPI.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Amount { get; set; }
    }
}