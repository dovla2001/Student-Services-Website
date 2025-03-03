using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_PROJEKAT.Models
{
    public class Student
    {
        private string korisnickoIme;
        private string brojIndeksa;
        private string sifra;
        private string ime;
        private string prezime;
        private string datumRodjenja;
        private string elektronskaPosta;
        private List<string> prijavljeni = new List<string>();
        private List<string> polozeni = new List<string>();
        private List<string> nepolozeni = new List<string>();

        private string prijavljen;
        private string polozen;
        private string nepolozen;

        public Student(string korisnickoIme, string brojIndeksa, string sifra, string ime, string prezime, string datumRodjenja, string elektronskaPosta, string prijavljen, string polozen, string nepolozen)
        {
            this.korisnickoIme = korisnickoIme;
            this.brojIndeksa = brojIndeksa;
            this.sifra = sifra;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.elektronskaPosta = elektronskaPosta;
            this.prijavljen = prijavljen;
            this.polozen = polozen;
            this.nepolozen = nepolozen;
        }

        public Student()
        {
        }

        public Student(string korisnickoIme, string brojIndeksa, string sifra, string ime, string prezime, string datumRodjenja, string elektronskaPosta, List<string> prijavljeni, List<string> polozeni, List<string> nepolozeni)
        {
            this.KorisnickoIme = korisnickoIme;
            this.BrojIndeksa = brojIndeksa;
            this.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.ElektronskaPosta = elektronskaPosta;
            this.Prijavljeni = prijavljeni;
            this.Polozeni = polozeni;
            this.Nepolozeni = nepolozeni;
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string BrojIndeksa { get => brojIndeksa; set => brojIndeksa = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string ElektronskaPosta { get => elektronskaPosta; set => elektronskaPosta = value; }
        public List<string> Prijavljeni { get => prijavljeni; set => prijavljeni = value; }
        public List<string> Polozeni { get => polozeni; set => polozeni = value; }
        public List<string> Nepolozeni { get => nepolozeni; set => nepolozeni = value; }
        public string Prijavljen { get => prijavljen; set => prijavljen = value; }
        public string Polozen { get => polozen; set => polozen = value; }
        public string Nepolozen { get => nepolozen; set => nepolozen = value; }
    }
}