using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_PROJEKAT.Models
{
    public class Profesor
    {
        private string korisnickoIme;
        private string sifra;
        private string ime;
        private string prezime;
        private string datumRodjenja;
        private string elektronskaPosta;
        private List<string> predmeti = new List<string>();
        private List<string> ispiti = new List<string>();

        public Profesor()
        {
        }

        public Profesor(string korisnickoIme, string sifra, string ime, string prezime, string datumRodjenja, string elektronskaPosta, List<string> predmeti, List<string> ispiti)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.ElektronskaPosta = elektronskaPosta;
            this.Predmeti = predmeti;
            this.Ispiti = ispiti;
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string ElektronskaPosta { get => elektronskaPosta; set => elektronskaPosta = value; }
        public List<string> Predmeti { get => predmeti; set => predmeti = value; }
        public List<string> Ispiti { get => ispiti; set => ispiti = value; }
    }
}