using VinylShop.EfCore;

namespace VinylShop.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        public List<VinylModel> GetVinyls()
        {
            List<VinylModel> response = new List<VinylModel>();
            var dataList = _context.Vinyls.ToList();
            dataList.ForEach(row => response.Add(new VinylModel()
            {
                VinylId = row.VinylId,
                Title = row.Title,
                Artist = row.Artist,
                Format = row.Format,
                ReleaseYear = row.ReleaseYear,
                Genre = row.Genre,
                Label = row.Label,
                CatalogueNum = row.CatalogueNum,
            }));
            return response;
        }
        public VinylModel GetVinylsById(int id)
        {
            VinylModel response = new VinylModel();
            var row = _context.Vinyls.Where(d => d.VinylId.Equals(id)).FirstOrDefault();
            return new VinylModel()
            {
                VinylId = row.VinylId,
                Title = row.Title,
                Artist = row.Artist,
                Format = row.Format,
                ReleaseYear = row.ReleaseYear,
                Genre = row.Genre,
                Label = row.Label,
                CatalogueNum = row.CatalogueNum,
            };
        }
        public void SaveVinyl(VinylModel vinylModel)
        {
            Vinyl dbTable = new Vinyl();
            if (vinylModel.VinylId > 0)
            {
                dbTable = _context.Vinyls.Where(d => d.VinylId.Equals(vinylModel.VinylId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Title = vinylModel.Title;
                    dbTable.Artist = vinylModel.Artist;
                    dbTable.Format = vinylModel.Format;
                    dbTable.ReleaseYear = vinylModel.ReleaseYear;
                    dbTable.Genre = vinylModel.Genre;
                    dbTable.Label = vinylModel.Label;
                    dbTable.CatalogueNum = vinylModel.CatalogueNum;
                }
            }
            else
            {
                dbTable.VinylId = vinylModel.VinylId;
                dbTable.Title = vinylModel.Title;
                dbTable.Artist = vinylModel.Artist;
                dbTable.Format = vinylModel.Format;
                dbTable.ReleaseYear = vinylModel.ReleaseYear;
                dbTable.Genre = vinylModel.Genre;
                dbTable.Label = vinylModel.Label;
                dbTable.CatalogueNum = vinylModel.CatalogueNum;
                _context.Vinyls.Add(dbTable);
            }
            _context.SaveChanges();
        }
    
        

        public void DeleteVinyl(int id)
        {
            var vinyl = _context.Vinyls.Where(d => d.VinylId.Equals(id)).FirstOrDefault();
            if(vinyl != null)
            {
                _context.Vinyls.Remove(vinyl);
                _context.SaveChanges();
            }
        }
    }
}
