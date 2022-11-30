namespace ZadaniaAPI.Zadania
{
    public class Zadanie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public DateTime? Date { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }
    }
}
