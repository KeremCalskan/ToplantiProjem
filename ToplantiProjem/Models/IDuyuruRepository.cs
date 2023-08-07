namespace ToplantiProjem.Models
{
    public interface IDuyuruRepository : IRepository<Duyuru>
    {
        void Guncelle(Duyuru duyuru);
        void Kaydet();
    }
}
