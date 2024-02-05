public class Flowers
{
    public int FlowerId { get; set; }
    public string FlowerName { get; set; }
    public string Color { get; set; }
    public DateTime BloomTime { get; set; }
    public decimal Price { get; set; }

    public List<Flowers> Children { get; set; }

}
