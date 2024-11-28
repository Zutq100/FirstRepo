
namespace EFCore.Repo
{
    public class CarsModelRepository
    {
        KnowledgeBaseContext _context;
        DbSet<CarsModel> _cars;

        public CarsModelRepository()
        {
            _context = new KnowledgeBaseContext();
            _cars = _context.Set<CarsModel>();
        }
        public string GetCarBrandToId(int Id)
        {
            if (Id == 0)
                return "Отсутствует автомобиль в списке";
            return _cars.First(x => x.ID == Id).CarBrand;
        }

        public List<CarsModel> GetAll() => _cars.ToList();
    }
}
