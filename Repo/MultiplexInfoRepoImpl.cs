using BookMyShowProjectNewAPI.DTO;
using BookMyShowProjectNewAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookMyShowProjectNewAPI.Repo
{
    public class MultiplexInfoRepoImpl : IRepo<MultiplexInfoDTO>
    {
        private ProjectDbContext context;

        public MultiplexInfoRepoImpl(ProjectDbContext ctx)
        {
            context = ctx;
        }

        public bool Add(MultiplexInfoDTO item)
        {
            MultiplexInfo multiplexInfo = new MultiplexInfo
            {
                MulID = item.MulID,
                MulName = item.MulName,
                CityID = item.CityID,
                ScreenNumber = item.ScreenNumber
            };

            context.MultiplexInfos.Add(multiplexInfo);
            context.SaveChanges();
            return true;
        }

        public List<MultiplexInfoDTO> GetAll()
        {
            var result = context.MultiplexInfos
                .Select(r => new MultiplexInfoDTO
                {
                    MulID = r.MulID,
                    MulName = r.MulName,
                    CityID = r.CityID,
                    ScreenNumber = r.ScreenNumber
                })
                .ToList();

            return result;
        }

        public bool Delete(MultiplexInfoDTO item)
        {
            var multiplexToDelete = context.MultiplexInfos.FirstOrDefault(m => m.MulID == item.MulID);
            if (multiplexToDelete != null)
            {
                context.MultiplexInfos.Remove(multiplexToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(MultiplexInfoDTO updatedMultiplex)
        {
            var multiplexToUpdate = context.MultiplexInfos.FirstOrDefault(m => m.MulID == updatedMultiplex.MulID);
            if (multiplexToUpdate != null)
            {
                multiplexToUpdate.MulName = updatedMultiplex.MulName;
                // Update other properties as needed
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
