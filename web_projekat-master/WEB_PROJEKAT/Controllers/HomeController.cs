using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB_PROJEKAT.Models;

namespace WEB_PROJEKAT.Controllers
{

    public class Global
    {
        public string ime = "";
        public string prezime = "";
        public string predmet = "";
    }
    public class HomeController : Controller
    {
        private string indeks;
        private string indeks2;

        private List<Student> studenti = new List<Student>();
        
        // GET: Home
        public ActionResult Index()
        {
            string prijavljeni = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljen.csv";

            using (StreamWriter writer = new StreamWriter(prijavljeni))
            {
                string prazanTekst = "";
                writer.WriteLine(prazanTekst);
            }
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Profesor()
        {
            return View();
        }

        public ActionResult KreiranjeStudenta()
        {
            return View();
        }

        public ActionResult KreirajIspit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prijava()
        {
            string profesorCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\profesor.csv";
            string studentCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";
            string adminCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\admin.csv";

            string prijavljentemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljen.csv";

            var korisnickoIme = Request["korisnickoIme"];
            var lozinka = Request["lozinka"];

            Global g = new Global();

            string lozinkaCsv = "";
            string korisnickoImeCsv = "";

            using (StreamReader reader = new StreamReader(adminCsv))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    korisnickoImeCsv = values[0];
                    lozinkaCsv = values[1];


                    if (korisnickoIme == korisnickoImeCsv && lozinka == lozinkaCsv)
                    {
                        g.ime = values[2];
                        g.prezime = values[3];

                        using (StreamWriter sw = new StreamWriter(prijavljentemp, false))
                        {
                            sw.Write(g.ime);
                            sw.Write(",");
                            sw.Write(g.prezime);
                        }
                        return RedirectToAction("Admin");
                    }
                }
            }

            using (StreamReader reader = new StreamReader(studentCsv))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    korisnickoImeCsv = values[0];
                    lozinkaCsv = values[2];

                    if (korisnickoIme == korisnickoImeCsv && lozinka == lozinkaCsv)
                    {
                        g.ime = values[3];
                        g.prezime = values[4];

                        using (StreamWriter sw = new StreamWriter(prijavljentemp, false))
                        {
                            sw.Write(g.ime);
                            sw.Write(",");
                            sw.Write(g.prezime);
                        }
                        return RedirectToAction("Student");
                    }
                }
            }

            using (StreamReader reader = new StreamReader(profesorCsv))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    korisnickoImeCsv = values[0];
                    lozinkaCsv = values[1];

                    if (korisnickoIme == korisnickoImeCsv && lozinka == lozinkaCsv)
                    {
                        g.ime = values[2];
                        g.prezime = values[3];
                        g.predmet = values[6];

                        using (StreamWriter sw = new StreamWriter(prijavljentemp, false))
                        {
                            sw.Write(g.ime);
                            sw.Write(",");
                            sw.Write(g.prezime);
                            sw.Write(",");
                            sw.Write(g.predmet);
                        }
                        return RedirectToAction("Profesor");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NoviStudent()
        {
            string studenttemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";
            string studentnovitemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\studentnovitemp.csv";

            string line;
            var korisnickoIme = Request["korisnickoIme"];
            var indeks = Request["indeks"];
            var sifra = Request["sifra"];
            var ime = Request["ime"];
            var prezime = Request["prezime"];
            var datumRodjenja = Request["datumRodjenja"];
            var elektronskaPosta = Request["elektronskaPosta"];
            var prijavljeniIspit = Request["prijavljeniIspit"];
            var polozeniIspit = Request["polozeniIspit"];
            var nepolozeniIspit = Request["nepolozeniIspit"];

            List<Student> studentiLista = new List<Student>();
            using (StreamReader reader = new StreamReader(studenttemp))
            {
                reader.ReadLine(); //da bi preskocili zaglavlje sa nazivima kolona
                string line1;
                string korisnickoIme1 = "";
                string brojIndeksa1 = "";
                string lozinka1 = "";
                string ime1 = "";
                string prezime1 = "";
                string datumRodjenja1 = "";
                string email1 = "";
                string prijavljenIspit1 = "";
                string polozenIspit1 = "";
                string nepolozenIspit1 = "";


                while ((line1 = reader.ReadLine()) != null)
                {

                    string[] values = line1.Split(',');

                    korisnickoIme1 = values[0];
                    brojIndeksa1 = values[1];
                    lozinka1 = values[2];
                    ime1 = values[3];
                    prezime1 = values[4];
                    datumRodjenja1 = values[5];
                    email1 = values[6];
                    prijavljenIspit1 = values[7];
                    polozenIspit1 = values[8];
                    nepolozenIspit1 = values[9];

                    Student s1 = new Student(korisnickoIme1, brojIndeksa1, lozinka1, ime1, prezime1, datumRodjenja1, email1, prijavljenIspit1, polozenIspit1, nepolozenIspit1);
                    studentiLista.Add(s1);
                }
            }

            foreach (Student s in studentiLista)
            {
                if (s.KorisnickoIme == korisnickoIme || s.BrojIndeksa == indeks || s.ElektronskaPosta == elektronskaPosta)
                {
                    return View("KreiranjeStudenta");
                }
            }

            using (StreamWriter sw = new StreamWriter(studenttemp, true))
                {
                    using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        List<Student> studenti = new List<Student>()
                    {
                        new Student(korisnickoIme, indeks, sifra, ime, prezime, datumRodjenja, elektronskaPosta, prijavljeniIspit, polozeniIspit, nepolozeniIspit)
                    };

                        foreach (Student student in studenti)
                        {
                            if (korisnickoIme != "" && indeks != "" && sifra != "" && ime != "" && prezime != "" && datumRodjenja != "" && elektronskaPosta != "" && prijavljeniIspit != "" && polozeniIspit != "" && nepolozeniIspit != "")
                            {
                                csvWriter.WriteField(student.KorisnickoIme);
                                csvWriter.WriteField(student.BrojIndeksa);
                                csvWriter.WriteField(student.Sifra);
                                csvWriter.WriteField(student.Ime);
                                csvWriter.WriteField(student.Prezime);
                                csvWriter.WriteField(student.DatumRodjenja);
                                csvWriter.WriteField(student.ElektronskaPosta);
                                csvWriter.WriteField(student.Nepolozen);
                                csvWriter.WriteField(student.Polozen);
                                csvWriter.WriteField(student.Nepolozen);
                                csvWriter.NextRecord();
                                //sw.WriteLine();
                            }

                        if (korisnickoIme == "" || indeks == "" || sifra == "" || ime == "" || prezime == "" || datumRodjenja == "" || elektronskaPosta == "" || prijavljeniIspit == "" || polozeniIspit == "" || nepolozeniIspit == "")
                        {
                            return View("KreiranjeStudenta");
                        }
                        }
                        //sw.WriteLine();
                    }
                }
            return RedirectToAction("Admin");
        }

        public ActionResult NoviIspit()
        {
            string ispitCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\ispit.csv";
            string prijavljen = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljen.csv";

            string ime, prezime;
            string profesor = "";

            var predmet = Request["predmet"];
            var datumOdrzavanja = Request["datumOdrzavanja"];
            var ucionica = Request["ucionica"];
            var ispitniRok = Request["ispitniRok"];

            using (StreamReader sr = new StreamReader(prijavljen))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    ime = values[0];
                    prezime = values[1];
                    profesor = ime + " " + prezime;
                }
            }

            using (StreamWriter sw = new StreamWriter(ispitCsv, true))
            {
                using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
                {
                    List<Ispit> ispiti = new List<Ispit>()
                    {
                        new Ispit(profesor, predmet, datumOdrzavanja, ucionica, ispitniRok)
                    };

                    foreach (Ispit ispit in ispiti)
                    {
                        if (predmet != "" && datumOdrzavanja != "" && ucionica != "" && ispitniRok != "")
                        {
                            csvWriter.WriteField(ispit.Profesor);
                            csvWriter.WriteField(ispit.Predmet);
                            csvWriter.WriteField(ispit.DatumIVremeOdrzavanja);
                            csvWriter.WriteField(ispit.Ucionica);
                            csvWriter.WriteField(ispit.IspitniRok);
                        }

                        if (predmet == "" || datumOdrzavanja == "" || ucionica == "" || ispitniRok == "")
                        {
                            return View("KreirajIspit");
                        }
                    }
                    sw.WriteLine();
                }
            }
            return RedirectToAction("Profesor");
        }

        public ActionResult PrikazStudenta()
        {
            string studentCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";

            using (StreamReader reader = new StreamReader(studentCsv))
            {
                string line;
                string korisnickoIme = "";
                string brojIndeksa = "";
                string lozinkaCsv = "";
                string ime = "";
                string prezime = "";
                string datumRodjenja = "";
                string email = "";
                string prijavljenIspit = "";
                string polozenIspit = "";
                string nepolozenIspit = "";
                List<string> prijavljeniIspiti = new List<string>();
                List<string> polozeniIspiti = new List<string>();
                List<string> nepolozeniIspiti = new List<string>();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    korisnickoIme = values[0];
                    brojIndeksa = values[1];
                    lozinkaCsv = values[2];
                    ime = values[3];
                    prezime = values[4];
                    datumRodjenja = values[5];
                    email = values[6];
                    prijavljenIspit = values[7];
                    polozenIspit = values[8];
                    nepolozenIspit = values[9];

                    Student s1 = new Student(korisnickoIme, brojIndeksa, lozinkaCsv, ime, prezime, datumRodjenja, email, prijavljenIspit, polozenIspit, nepolozenIspit);
                    studenti.Add(s1);
                }
            }
            var brojIndeksa1 = Request["brojIndeksa"];
            indeks = brojIndeksa1;
            Student temp = null;
            foreach (Student s in studenti)
            {
                if (s.BrojIndeksa.Contains(indeks))
                {
                    temp = s;
                }
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult IzmenaStudenta()
        {
            string studentCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";

            using (StreamReader reader = new StreamReader(studentCsv))
            {
                string line;
                string korisnickoIme = "";
                string brojIndeksa = "";
                string lozinkaCsv = "";
                string ime = "";
                string prezime = "";
                string datumRodjenja = "";
                string email = "";
                string prijavljenIspit = "";
                string polozenIspit = "";
                string nepolozenIspit = "";
                List<string> prijavljeniIspiti = new List<string>();
                List<string> polozeniIspiti = new List<string>();
                List<string> nepolozeniIspiti = new List<string>();

                while ((line = reader.ReadLine()) != null)
                {
                    
                    string[] values = line.Split(',');

                    korisnickoIme = values[0];
                    brojIndeksa = values[1];
                    lozinkaCsv = values[2];
                    ime = values[3];
                    prezime = values[4];
                    datumRodjenja = values[5];
                    email = values[6];
                    prijavljenIspit = values[7];
                    polozenIspit = values[8];
                    nepolozenIspit = values[9];

                    prijavljeniIspiti.Add(prijavljenIspit);
                    polozeniIspiti.Add(polozenIspit);
                    nepolozeniIspiti.Add(nepolozenIspit);

                    Student s1 = new Student(korisnickoIme, brojIndeksa, lozinkaCsv, ime, prezime, datumRodjenja, email, prijavljenIspit, polozenIspit, nepolozenIspit);
                    studenti.Add(s1);
                }
            }
            var brojIndeksa1 = Request["brojIndeksa"];
            indeks = brojIndeksa1;
            Student temp = null;
            foreach (Student s in studenti)
            {
                if (s.BrojIndeksa.Contains(indeks))
                {
                    temp = s;
                }
            }
            return View(temp);
        }

        public ActionResult IzmeniStudenta()
        {
            string studentnovitemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\studentnovitemp.csv";
            string studenttemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";

            string korisnickoIme = Request["korisnickoIme"];
            string brojIndeksa = Request["brojIndeksa"];
            string sifra = Request["sifra"];
            string ime = Request["ime"];
            string prezime = Request["prezime"];
            string datumRodjenja = Request["datumRodjenja"];
            string email = Request["email"];
            string prijavljen = Request["prijavljen"];
            string polozen = Request["polozen"];
            string nepolozen = Request["nepolozen"];


            string korisnickoImeCsv = "";
            string brojIndeksaCsv = "";
            string lozinkaCsv = "";
            string imeCsv = "";
            string prezimeCsv = "";
            string datumRodjenjaCsv = "";
            string emailCsv = "";
            string prijavljenCsv = "";
            string polozenCsv = "";
            string nepolozenCsv = "";

            List<Student> studentList = new List<Student>();
            using (StreamReader reader = new StreamReader(studenttemp))
            {
                reader.ReadLine(); //da bi preskocili zaglavlje sa nazivima kolona
                string line;


                while ((line = reader.ReadLine()) != null)
                {

                    string[] values = line.Split(',');

                    korisnickoImeCsv = values[0];
                    brojIndeksaCsv = values[1];
                    lozinkaCsv = values[2];
                    imeCsv = values[3];
                    prezimeCsv = values[4];
                    datumRodjenjaCsv = values[5];
                    emailCsv = values[6];
                    prijavljenCsv = values[7];
                    polozenCsv = values[8];
                    nepolozenCsv = values[9];

                    Student s1 = new Student(korisnickoImeCsv, brojIndeksaCsv, lozinkaCsv, imeCsv, prezimeCsv, datumRodjenjaCsv, emailCsv, prijavljenCsv, polozenCsv, nepolozenCsv);
                    studentList.Add(s1);
                }
            }





            foreach (Student s in studentList)
            {
                if (s.BrojIndeksa == brojIndeksa)
                {
                    s.KorisnickoIme = korisnickoIme;
                    s.BrojIndeksa = brojIndeksa;
                    s.Sifra = sifra;
                    s.Ime = ime;
                    s.Prezime = prezime;
                    s.DatumRodjenja = datumRodjenja;
                    s.ElektronskaPosta = email;
                    s.Prijavljen = prijavljen;
                    s.Polozen = polozen;
                    s.Nepolozen = nepolozen;
                }
            }

            using (StreamWriter sw = new StreamWriter(studenttemp, false))
            {
                using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
                {
                    foreach (Student ss in studentList)
                    {
                        if (ss.BrojIndeksa == brojIndeksa)
                        {
                            csvWriter.WriteRecords(studentList);
                            ////csvWriter.WriteField(s.KorisnickoIme);
                            ////csvWriter.WriteField(s.BrojIndeksa);
                            ////csvWriter.WriteField(s.Sifra);
                            ////csvWriter.WriteField(s.Ime);
                            ////csvWriter.WriteField(s.Prezime);
                            ////csvWriter.WriteField(s.DatumRodjenja);
                            ////csvWriter.WriteField(s.ElektronskaPosta);
                            ////csvWriter.WriteField(s.Prijavljen);
                            ////csvWriter.WriteField(s.Polozen);
                            ////csvWriter.WriteField(s.Nepolozen);
                            //csvWriter.NextRecord();  //novi red
                            //break;
                        }
                    }
                    //sw.WriteLine();
                }
            }
            return RedirectToAction("Admin");
        }

        public ActionResult RezultatiIspita()
        {
            return View();
        }

        public ActionResult RezultatiIspitaProfesor()
        {
            return View();
        }

        public ActionResult PrijavaIspita()
        {
            return View();
        }

        public ActionResult OceniIspite()
        {
            return View();
        }

        public ActionResult Ocena()
        {
            string ispitrezultati = "C:\\Users\\Lenovo\\Desktop\\WEB\\ispitrezultati.csv";
            string prijavljeniIspiti = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljeniIspiti.csv";

            string ime = Request["ime"];
            string prezime = Request["prezime"];
            string nazivPredmeta = Request["nazivPredmeta"];
            string brojBodova = Request["brojBodova"];
            string ispitniRok = Request["ispitniRok"];

            string profesor = "";
            string predmet = "";
            string datum = "";
            string ucionica = "";
            string rok = "";
            string imeStudenta = "";
            string prezimeStudenta = "";
            string studenttemp = ime + " " + prezime;
            string student = "";

            List<RezultatIspita> ispiti = new List<RezultatIspita>();
            List<Ispit> prijavljeniIspitiLista = new List<Ispit>();

            using (StreamReader sr = new StreamReader(prijavljeniIspiti))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    profesor = values[0];
                    predmet = values[1];
                    datum = values[2];
                    ucionica = values[3];
                    rok = values[4];
                    imeStudenta = values[5];
                    prezimeStudenta = values[6];
                    student = imeStudenta + " " + prezimeStudenta;

                    RezultatIspita ri = new RezultatIspita(predmet, student, brojBodova);
                    ispiti.Add(ri);

                    Ispit i = new Ispit(profesor, predmet, datum, ucionica, rok, imeStudenta, prezimeStudenta);
                    prijavljeniIspitiLista.Add(i);
                }
            }

            //if (int.Parse(brojBodova) < 5 && int.Parse(brojBodova) > 10)
            //{
            //    return View("OceniIspite");
            //}

            foreach (RezultatIspita r in ispiti)
            {
                if (int.Parse(r.Ocena) > 10 || int.Parse(r.Ocena) < 5)
                {
                    return View("OceniIspite");
                }
            }

            foreach (Ispit i in prijavljeniIspitiLista)
            {
                if (i.IspitniRok == ispitniRok && i.Ime == ime && i.Prezime == prezime && i.Predmet == nazivPredmeta)
                {
                    
                    using (StreamWriter sw = new StreamWriter(ispitrezultati, true))
                    {
                        using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            csvWriter.WriteField(student);
                            csvWriter.WriteField(predmet);
                            csvWriter.WriteField(brojBodova);
                            csvWriter.WriteField(ispitniRok);

                            sw.WriteLine();
                        }
                    }
                }
            }
            return View("Profesor");
        }

        //    foreach (RezultatIspita ispit in ispiti)
        //    {
        //        if (ispit.Ispit == nazivPredmeta && ispit.Student == studenttemp)
        //        {
        //            using (StreamWriter sw = new StreamWriter(ispitrezultati, true))
        //            {
        //                using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
        //                {
        //                    csvWriter.WriteField(ispit.Student);
        //                    csvWriter.WriteField(ispit.Ispit);
        //                    csvWriter.WriteField(ispit.Ocena);

        //                    sw.WriteLine();
        //                }
        //            }
        //        }
        //    }
        //    return View("Profesor");
        //}

        public ActionResult PrijaviIspit()
        {
            var nazivIspita = Request["nazivIspita"];
            var ispitniRok = Request["ispitniRok"];

            string prijavljeniIspiti = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljeniIspiti.csv";
            string ispitCsv = "C:\\Users\\Lenovo\\Desktop\\WEB\\ispit.csv";
            string prijavljen = "C:\\Users\\Lenovo\\Desktop\\WEB\\prijavljen.csv";

            string profesor = "";
            string predmet = "";
            string datum = "";
            string ucionica = "";
            string rok = "";

            string ime = "";
            string prezime = "";

            List<Ispit> ispiti = new List<Ispit>();

            Global g = new Global();

            using (StreamReader sr = new StreamReader(prijavljen))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    ime = values[0];
                    prezime = values[1];
                }
            }

            using (StreamReader sr = new StreamReader(ispitCsv))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    profesor = values[0];
                    predmet = values[1];
                    datum = values[2];
                    ucionica = values[3];
                    rok = values[4];

                    Ispit i = new Ispit(profesor, predmet, datum, ucionica, rok);
                    ispiti.Add(i);
                }
            }

            foreach (Ispit ispit in ispiti)
            {
                if (ispit.Predmet == nazivIspita && ispit.IspitniRok == ispitniRok)
                {
                    using (StreamWriter sw = new StreamWriter(prijavljeniIspiti, true))
                    {
                        using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            
                                csvWriter.WriteField(ispit.Profesor);
                                csvWriter.WriteField(ispit.Predmet);
                                csvWriter.WriteField(ispit.DatumIVremeOdrzavanja);
                                csvWriter.WriteField(ispit.Ucionica);
                                csvWriter.WriteField(ispit.IspitniRok);
                                csvWriter.WriteField(ime);
                                csvWriter.WriteField(prezime);

                                sw.WriteLine();
                        }  
                    }
                }
            }
            return View("Student");
        }

        public ActionResult ObrisiStudenta()
        {
            string studentrezerva = "C:\\Users\\Lenovo\\Desktop\\WEB\\studentrezerva.csv";
            string studenttemp = "C:\\Users\\Lenovo\\Desktop\\WEB\\studenttemp.csv";

            var brIndeksa = Request["brojIndeksa"];

            using (var reader = new StreamReader(studenttemp))
            {
                using (var writer = new StreamWriter(studentrezerva))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.Contains(brIndeksa))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            using (var reader = new StreamReader(studentrezerva))
            {
                using (var writer = new StreamWriter(studenttemp))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            return View("Admin");
        }
    }
}

