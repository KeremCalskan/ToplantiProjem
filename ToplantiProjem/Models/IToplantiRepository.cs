namespace ToplantiProjem.Models
{
    public interface IToplantiRepository : IRepository<Toplanti>
    {
        void Guncelle(Toplanti toplanti);
        void Kaydet();
    }
}
