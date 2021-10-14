using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FamilyTree;
using Newtonsoft.Json;
using PristupBazi;

namespace FamilyTreeProject.Controllers
{
    public class OsobaController : ApiController
    {
        private FamilyTree.OsobaInvoker invoker;

        public OsobaController()
        {
            invoker = new FamilyTree.OsobaInvoker();
        }
        
        [HttpGet]
        [Route("api/Osoba/Prikaz")]
        public IHttpActionResult Prikaz() 
        {
            try
            {
                KomandaCitaj citaj = new KomandaCitaj();
                citaj.Execute();
                return Ok(citaj.lista);
            }
            catch(Exception e)
            {
                return InternalServerError();
            } 
        }

        [HttpPost]
        [Route("api/Osoba/Dodaj")]
        public IHttpActionResult Dodaj([FromBody]object value)
        {
            try
            {
                var osoba = JsonConvert.DeserializeObject<Person>(value.ToString());
                KomandaDodaj dodaj = new KomandaDodaj();
                dodaj.objekatSistema = osoba;
                invoker.AddAndExecute(dodaj);
                return Ok(dodaj.objekatSistema); ///dodaj ne treba nista da 
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }


        [HttpPost]
        [Route("api/Osoba/PrikazDjece")]
        public IHttpActionResult PrikazDjece([FromBody] object value)
        {
            try
            {
                var izabranaOsoba = JsonConvert.DeserializeObject<Person>(value.ToString());
                // ili person
                //string idRoditelja = vals["izabranaOsoba"];


                IKonverzijaObjekta konverzija = new StrategyKonverzijaOsoba();
                List<PristupBazi.OsobaT> osobe = new List<PristupBazi.OsobaT>();

                KomandaCitaj citaj = new KomandaCitaj();
                citaj.Execute();

                for (int i = 0; i < citaj.lista.Count; i++)
                {
                    OsobaT osoba = (PristupBazi.OsobaT)konverzija.objekatuModel(citaj.lista[i]);
                    osobe.Add(osoba);
                }
                for (int i = 0; i < osobe.Count; i++)
                {
                    
                    if (izabranaOsoba.IdP== osobe[i].idR) ///// zbog deserializacije
                    {
                        return Ok(osobe[i]);
                    }
                }

                return Ok(); ///////

            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpPost]
        [Route("api/Osoba/PrikazRoditelj")]
        public IHttpActionResult PrikazRoditelj([FromBody]object value)
        {
            try
            {
                var osoba = JsonConvert.DeserializeObject<Person>(value.ToString());

                IKonverzijaObjekta konverzija = new StrategyKonverzijaOsoba();
                List<PristupBazi.OsobaT> osobe = new List<OsobaT>();

                KomandaCitaj citajRoditelja = new KomandaCitaj();
                citajRoditelja.Execute();


                for (int i = 0; i < citajRoditelja.lista.Count; i++)
                {
                    osobe.Add((PristupBazi.OsobaT)konverzija.objekatuModel(citajRoditelja.lista[i]));
                }
                for(int i = 0; i < osobe.Count; i++)
                {
                    if(osobe[i].id == osoba.Parent.IdP)
                    {
                        return Ok(osobe[i]);
                    }
                }

                return Ok("Prikaz");
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }

        }

        [HttpPost]
        [Route("api/Osoba/PrikazSupruznik")]
        public IHttpActionResult PrikazSupruznik([FromBody]object value)
        {
            try
            {
                var osoba = JsonConvert.DeserializeObject<Person>(value.ToString());

                KomandaCitaj citaj = new KomandaCitaj();
                citaj.Execute();

                List<PristupBazi.OsobaT> osobe = new List<OsobaT>();
                IKonverzijaObjekta konverzija = new StrategyKonverzijaOsoba();

                for(int i = 0; i < citaj.lista.Count; i++) 
                {
                    osobe.Add((PristupBazi.OsobaT)konverzija.objekatuModel(citaj.lista[i])); 
                }

                for(int i = 0; i < osobe.Count; i++)
                {
                    if(osobe[i].id == osoba.Spouse.IdP)
                    {
                        return Ok(osobe[i]);
                    }
                }
                return Ok("Prikaz");
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }
        [HttpDelete]
        [Route("api/Osoba/Delete")]    
        public IHttpActionResult Delete([FromBody] object value)
        {
            try
            {
                var izabranaOsoba = JsonConvert.DeserializeObject<Person>(value.ToString());

                KomandaObrisi brisi = new KomandaObrisi();
                brisi.objekatSistema = izabranaOsoba;
                invoker.AddAndExecute(brisi);

                return Ok(brisi.objekatSistema);
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpPost]
        [Route("api/Osoba/Izmijeni")]
        public IHttpActionResult Izmijeni([FromBody] object value)
        {
            try
            {
                var izabranaOsoba = JsonConvert.DeserializeObject<Person>(value.ToString());

                KomandaIzmijeni izmijeni = new KomandaIzmijeni();
                izmijeni.objekatPosle = izabranaOsoba;
                invoker.AddAndExecute(izmijeni);

                return Ok("Modifikovan!");
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpPost]
        [Route("api/Osoba/DodajBio")]
        public IHttpActionResult DodajBio([FromBody] object value)
        {
            try
            {
                var bio = JsonConvert.DeserializeObject<Biography>(value.ToString());
                IBaza baza = new DodajBiografija();
                baza.listaObjekata.Add(bio);
                baza.Akcija();
                using(var db = new PristupBazi.DataBase())
                {
                    bio.IdB = db.BiografijaT.Max(x=>x.id);
                }
                return Ok(bio);
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpGet]
        [Route("api/Osoba/UndoCommand")]
        public IHttpActionResult UndoCommand()
        {
            try
            {
                invoker.Undo();
                return Ok("Uspjesan UNDO");
            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/Osoba/RedoCommand")]
        public IHttpActionResult RedoCommand()
        {
            try
            {
                invoker.Redo();
                return Ok("Uspjesan Redo");
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }



        /*
        [HttpPost]
        [Route("api/Osoba/Pretraga")]
        public IHttpActionResult Pretraga([FromBody]object value)
        {
            try
            {
                var osobaPretraga = JsonConvert.DeserializeObject<Person>(value.ToString());

                KomandaCitaj citaj = new KomandaCitaj();
                OsobaInvoker invoker = new OsobaInvoker();
                invoker.AddAndExecute(citaj);

                List<PristupBazi.OsobaT> osobe = new List<OsobaT>();

                List<PristupBazi.OsobaT> povratna = new List<OsobaT>();

                IKonverzijaObjekta konverzija = new StrategyKonverzijaOsoba();

                for (int i = 0; i < citaj.lista.Count; i++)
                {
                    osobe.Add((PristupBazi.OsobaT)konverzija.objekatuModel(citaj.lista[i]));
                }

                for (int i = 0; i < osobe.Count; i++)
                {
                    if (osobe[i].ime.Contains(osobaPretraga.Ime) && osobe[i].prezime.Contains(osobaPretraga.Prezime))
                    {
                        povratna.Add(osobe[i]);
                    }
                }

                return Ok(povratna);

            }
            catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

    */

        // GET: api/Home
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }
    }
}
