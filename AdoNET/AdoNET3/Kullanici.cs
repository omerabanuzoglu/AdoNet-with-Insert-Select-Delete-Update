namespace AdoNET3
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAd { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }


        public Kullanici(int kulId, string ad, string soyad, string kullaniciAd, string email, string sifre)
        {
            this.KullaniciId = kulId;
            this.Ad = ad;
            this.Soyad = soyad;
            this.KullaniciAd = kullaniciAd;
            this.Email = email;
            this.Sifre = sifre;
        }
    }
}
