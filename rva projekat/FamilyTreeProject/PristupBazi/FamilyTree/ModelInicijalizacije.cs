using FamilyTree;
using PristupBazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class ModelInicijalizacije
    {
        private Person p1, r, s;
        private Biography b1, b2, b3;
        private Korisnik k;
        public ModelInicijalizacije()
        {
            p1 = new Person();
            r = new Person();
            s = new Person();

            b1 = new Biography();
            b2 = new Biography();
            b3 = new Biography();

            k = new Korisnik();

            p1.Ime = "Aleksandar";
            p1.Prezime = "Matic";
            p1.Adresa = "Tolstojeva 11";
            p1.BrojTelefona = "0655176671";
            p1.Email = "alm@gmail.com";


            r.Ime = "Nikola";
            r.Prezime = "Matic";
            r.Adresa = "Tolstojeva 11";
            r.BrojTelefona = "046123123";
            r.Email = "nm@gmail.com";


            s.Ime = "Nastasija";
            s.Prezime = "Matic";
            s.Adresa = "Tolstojeva 11";
            s.BrojTelefona = "03122221";
            s.Email = "Nm@gmail.com";


            b1.Obrazovanje = "Dipl.inz.";
            b1.RadnoIskustvo = "10god.";
            b1.Vjestine = "rad u wordu";

            b2.Obrazovanje = "Maturant gimnazije";
            b2.RadnoIskustvo = "1 mjesec";
            b2.Vjestine = "brzo citanje";

            b3.Obrazovanje = "Srednja strucna sprema";
            b3.RadnoIskustvo = "3god.";
            b3.Vjestine = "ples";

            k.Ime = "Marko";
            k.Prezime = "Nastic";
            k.Lozinka = "admin";
            k.Email = "admin";
            k.Tip = TipKorisnika.Admin;


            p1.Parent.IdP = r.IdP;
            p1.m_Biography.IdB = b1.IdB;
            p1.Spouse.IdP = s.IdP;

            r.Child.IdP = p1.IdP;
            r.m_Biography.IdB = b2.IdB;

            s.Spouse.IdP = p1.IdP;
            s.m_Biography.IdB = b3.IdB;


        }



        public void Inicijalizacija()
        {
            ProcitajKorisnik procitajKorisnik = new ProcitajKorisnik();
            DodajKorisnik dodaj = new DodajKorisnik();
            List<Korisnik> korisnici = new List<Korisnik>();
            StrategyKonverzijaKorisnik konverzijaKorisnik = new StrategyKonverzijaKorisnik();
            
            
            procitajKorisnik.Akcija();

            for(int i = 0; i < procitajKorisnik.listaObjekata.Count(); i++)
            {
                if (!(korisnici[i].Ime == k.Ime && korisnici[i].Prezime == k.Prezime && korisnici[i].Lozinka == k.Lozinka && korisnici[i].Email == k.Email && korisnici[i].Tip == k.Tip)) 
                {
                    dodaj.listaObjekata.Add(korisnici[i]);
                    dodaj.Akcija();
                }
            }
        }
    }
}
