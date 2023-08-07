using ToplantiProjem.Utility;

namespace ToplantiProjem.Models
{
    public class ToplantiRepository : Repository<Toplanti>, IToplantiRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public ToplantiRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Toplanti toplanti)
        {
            _uygulamaDbContext.Update(toplanti);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
