using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.Concrete
{
    public class EFImageRepository
    {
        private readonly EFDbContext context;
        public EFImageRepository()
        {
            context = new EFDbContext();
        }

        public IEnumerable<ProImage> GetAllImages
        {
            get { return (IEnumerable<ProImage>)context.Images; }
        }

        public bool SaveImage(ProImage image)
        {
            context.Images.Add(image);

            return context.SaveChanges() > 0;
        }

        public IEnumerable<ProImage> GetImagesByIDs(List<int> imageIDs)
        {
            return (IEnumerable<ProImage>)imageIDs.Select(x => context.Images.Find(x)).ToList();
        }
    }
}
