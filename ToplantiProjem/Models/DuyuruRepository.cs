using ToplantiProjem.Utility;

namespace ToplantiProjem.Models
{
    public class DuyuruRepository : Repository<Duyuru>, IDuyuruRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public DuyuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Duyuru duyuru)
        {
            _uygulamaDbContext.Update(duyuru);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
