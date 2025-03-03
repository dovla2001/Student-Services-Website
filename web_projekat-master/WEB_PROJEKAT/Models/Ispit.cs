using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_PROJEKAT.Models
{
    public class Ispit
    {
        private string profesor;
        private string predmet;
        private string datumIVremeOdrzavanja;
        private string ucionica;
        private string ispitniRok;

        private string ime;
        private string prezime;

        public Ispit()
        {
        }

        public Ispit(string profesor, string predmet, string datumIVremeOdrzavanja, string ucionica, string ispitniRok, string ime, string prezime) : this(profesor, predmet, datumIVremeOdrzavanja, ucionica, ispitniRok)
        {
            this.ime = ime;
            this.prezime = prezime;
        }

        public Ispit(string profesor, string predmet, string datumIVremeOdrzavanja, string ucionica, string ispitniRok)
        {
            this.Profesor = profesor;
            this.Predmet = predmet;
            this.DatumIVremeOdrzavanja = datumIVremeOdrzavanja;
            this.Ucionica = ucionica;
            this.IspitniRok = ispitniRok;
        }

        public string Profesor { get => profesor; set => profesor = value; }
        public string Predmet { get => predmet; set => predmet = value; }
        public string DatumIVremeOdrzavanja { get => datumIVremeOdrzavanja; set => datumIVremeOdrzavanja = value; }
        public string Ucionica { get => ucionica; set => ucionica = value; }
        public string IspitniRok { get => ispitniRok; set => ispitniRok = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
    }
}