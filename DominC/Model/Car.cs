using System.Security.Cryptography.X509Certificates;

namespace DominC.Model
{
    //كلاس يحوي معلومات حول السبارة
    public class Car : BClass
    {
        public string? Model { get; set; }
        public DateTime Year { get; set; }
        public string? Gear { get; set; }
        public int Km { get; set; }
        public List<Part> Part { get; set; } = new List<Part>();
    }
}