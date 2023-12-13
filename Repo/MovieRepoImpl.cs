using BookMyShowProjectNewAPI.DTO;
using BookMyShowProjectNewAPI.Entity;
using BookMyShowProjectNewAPI.Repo;

public class MovieRepoImpl : IRepo<MovieDTO>
{
    private ProjectDbContext context;

    public MovieRepoImpl(ProjectDbContext ctx)
    {
        context = ctx;
    }

    public bool Add(MovieDTO item)
    {
        Movie movie = new Movie
        {
            MovName = item.MovName,
            ReleaseDate = item.ReleaseDate
        };

        context.Movies.Add(movie);
        context.SaveChanges();
        return true;
    }

    public List<MovieDTO> GetAll()
    {
        var result = context.Movies
            .Select(r => new MovieDTO
            {
                MovID = r.MovID,
                MovName = r.MovName,
                ReleaseDate = r.ReleaseDate
            })
            .ToList();

        return result;
    }

    public bool Delete(MovieDTO item)
    {
        var movieToDelete = context.Movies.FirstOrDefault(m => m.MovID == item.MovID);
        if (movieToDelete != null)
        {
            context.Movies.Remove(movieToDelete);
            context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Update(MovieDTO updatedMovie)
    {
        var movieToUpdate = context.Movies.FirstOrDefault(m => m.MovID == updatedMovie.MovID);
        if (movieToUpdate != null)
        {
            movieToUpdate.MovName = updatedMovie.MovName;
            movieToUpdate.ReleaseDate = updatedMovie.ReleaseDate;
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
