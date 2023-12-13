
using BookMyShowProjectNewAPI.Entity;


namespace BookMyShowProjectNewAPI.Repo
{
    public class UnitOfWork
    {
        ProjectDbContext context = null;
        CityRepoImpl CityRepoImpl = null;
        MultiplexInfoRepoImpl MultiplexInfoRepoImpl = null;
        MovieRepoImpl MovieRepoImpl = null;
        public UnitOfWork(ProjectDbContext ctx)
        {
            context = ctx;
        }

        public CityRepoImpl CityImplObject
        {
            get
            {
                if (CityRepoImpl == null)
                    CityRepoImpl = new CityRepoImpl(context);
                return CityRepoImpl;
            }
        }

        public MultiplexInfoRepoImpl MultiplexInfoImplObject
        {
            get
            {
                if (MultiplexInfoRepoImpl == null)
                    MultiplexInfoRepoImpl = new MultiplexInfoRepoImpl(context);
                return MultiplexInfoRepoImpl;
            }
        }
        public MovieRepoImpl MovieImplObject
        {
            get
            {
                if (MovieRepoImpl == null)
                    MovieRepoImpl = new MovieRepoImpl(context);
                return MovieRepoImpl;
            }
        }

       

        public void SaveAll()
        {
            if (context != null)
            {
                context.SaveChanges();
            }
        }
    }
}




