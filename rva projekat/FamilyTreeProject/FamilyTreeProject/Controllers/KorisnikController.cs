using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FamilyTree;

namespace FamilyTreeProject.Controllers
{
    public class KorisnikController : ApiController
    {
        // GET: api/Korisnik
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Korisnik/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("api/Korisnik/Login")]
        public IHttpActionResult Login([FromBody]object value) 
            // za get: [FromUri]tipProm jsonKljuc
        {
            try
            {
                var k = JsonConvert.DeserializeObject<Korisnik>(value.ToString());

                ProcitajKorisnik procitaj = new ProcitajKorisnik();

                List<TemplateProcitaj> templateProcitaj = new List<TemplateProcitaj>(1) { procitaj};

                Korisnik korisnik = new Korisnik();

                templateProcitaj.ForEach(citaj =>
                {
                    citaj.Akcija();
                    for (int i = 0; i < citaj.listaObjekata.Count; i++)
                    {
                        korisnik = (Korisnik)citaj.listaObjekata.Where(x => ((Korisnik)x).Email == k.Email).Where(x => ((Korisnik)x).Lozinka == k.Lozinka).First();

                    }
                });
                
                return Ok(korisnik);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Korisnik/Register")]
        public IHttpActionResult Register([FromBody]object value)
        {
            try
            {
                var korisnik = JsonConvert.DeserializeObject<Korisnik>(value.ToString());
                IBaza baza = new DodajKorisnik();
                baza.listaObjekata.Add(korisnik);
                baza.Akcija();
                return Ok(korisnik);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Korisnik/Izmjena")]
        public IHttpActionResult Izmjena([FromBody]object value)
        {
            try
            {
                var korisnik = JsonConvert.DeserializeObject<Korisnik>(value.ToString());
                IBaza baza = new IzmIjeniKorisnik();
                baza.listaObjekata.Add(korisnik);
                baza.Akcija();
                return Ok(baza.listaObjekata[0]);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Korisnik/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Korisnik/5
        public void Delete(int id)
        {
        }
    }
}
