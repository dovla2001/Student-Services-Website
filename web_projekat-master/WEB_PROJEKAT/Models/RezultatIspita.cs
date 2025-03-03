using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_PROJEKAT.Models
{
    public class RezultatIspita
    {
        private string ispit;
        private string student;
        private string ocena;

        public RezultatIspita()
        {
        }

        public RezultatIspita(string ispit, string student, string ocena)
        {
            this.Ispit = ispit;
            this.Student = student;
            this.Ocena = ocena;
        }

        public string Ispit { get => ispit; set => ispit = value; }
        public string Student { get => student; set => student = value; }
        public string Ocena { get => ocena; set => ocena = value; }
    }
}