namespace ColegioRojasAPI.Models
{
    public class Colegio
    {
        public int ColegioID { get; set; }
        public string Name { get; set; }

        public string Aforo { get; set; }

        public string Aulas { get; set; }

        public bool IsActive { get; set; }
    }
}
