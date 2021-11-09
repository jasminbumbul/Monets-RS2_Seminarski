namespace Monets.Model
{
    public class JeloRezervacija
    {
        public int JeloId { get; set; }
        public int RezervacijaId { get; set; }
        public int JeloRezervacijaId { get; set; }
        public int Kolicina { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}