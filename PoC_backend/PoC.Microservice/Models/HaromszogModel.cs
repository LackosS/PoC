namespace PoC.Microservice.Models
{
    public class HaromszogModel
    {
        public string Guid { get; set; }
        public PontModel Pont1 { get; set; }
        public PontModel Pont2 { get; set; }
        public PontModel Pont3 { get; set; }
        public PontModel Irany { get; set; }
        public string Color { get; set; }
    }

    public class PontModel
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}