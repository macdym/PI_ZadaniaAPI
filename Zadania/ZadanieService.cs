namespace ZadaniaAPI.Zadania
{
    public interface IZadanieService
    {
        void Create(Zadanie zadanie);
        void Delete(Guid id);
        List<Zadanie> GetAll();
        Zadanie GetById(Guid id);
        void Update(Guid id);
    }
   
    public class ZadanieService : IZadanieService
    {
        public ZadanieService()
        {
            var zadanie = new Zadanie { Title = "Learn MinimalAPI" };
            _zadania[zadanie.Id] = zadanie;
        }
        private readonly Dictionary<Guid, Zadanie> _zadania = new();

        public Zadanie GetById(Guid id)
        {
            return _zadania.GetValueOrDefault(id);
        }

        public List<Zadanie> GetAll()
        {
            return _zadania.Values.ToList();
        }

        public void Create(Zadanie zadanie)
        {
            if (zadanie is null)
            {
                return;
            }
            _zadania[zadanie.Id] = zadanie;
        }

        public void Update(Guid id)
        {
            var zadanie = GetById(id);
            if (zadanie is null)
            {
                return;
            }
            zadanie.IsCompleted = true;
        }

        public void Delete(Guid id)
        {
            _zadania.Remove(id);
        }
    }
}
