namespace QuizAPI.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string? Architector { get; set; }
        public string? Customer { get; set; }
        public string? Style { get; set; }
    }
}
