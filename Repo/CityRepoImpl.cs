
using BookMyShowProjectNewAPI.DTO;
using BookMyShowProjectNewAPI.Entity;


namespace BookMyShowProjectNewAPI.Repo
{
    public class CityRepoImpl : IRepo<CityDTO>
    {
        private ProjectDbContext context;

        public CityRepoImpl(ProjectDbContext ctx)
        {
            context = ctx;
        }

        public bool Add(CityDTO item)
        {
            City cityNew = new City
            {
                CityName = item.CityName
            };
            context.Cities.Add(cityNew);
            context.SaveChanges();
            return true;
        }

        public List<CityDTO> GetAll()
        {
            var result = context.Cities.Select(r => new CityDTO { CityID = r.CityID, CityName = r.CityName }).ToList();
            return result;
        }

        public bool Delete(CityDTO item)
        {
            var cityToDelete = context.Cities.FirstOrDefault(c => c.CityID == item.CityID);
            if (cityToDelete != null)
            {
                context.Cities.Remove(cityToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CityDTO updatedCity)
        {
            var cityToUpdate = context.Cities.FirstOrDefault(c => c.CityID == updatedCity.CityID);
            if (cityToUpdate != null)
            {
                cityToUpdate.CityName = updatedCity.CityName;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

    