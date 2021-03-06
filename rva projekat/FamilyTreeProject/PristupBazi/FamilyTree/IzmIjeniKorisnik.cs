///////////////////////////////////////////////////////////
//  IzmIjeniKorisnik.cs
//  Implementation of the Class IzmIjeniKorisnik
//  Generated by Enterprise Architect
//  Created on:      06-okt-2021 14:41:29
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FamilyTree;
using System.Linq;

namespace FamilyTree {
	public class IzmIjeniKorisnik : TemplateIzmijeni {

		PristupBazi.KorisnikT obj;

		public IzmIjeniKorisnik(){}

		~IzmIjeniKorisnik(){}

		protected override void Izmijeni()
		{
			using(var db = new PristupBazi.DataBase())
			{
				if(obj!= null)
				{
					db.KorisnikT.Remove(db.KorisnikT.Where(x => x.id == obj.id).FirstOrDefault());
					db.KorisnikT.Add(obj);
					db.SaveChanges();
				}
			}
		}

		protected override void KonverzijaObjekatuModel()
		{
			konverzija = new StrategyKonverzijaKorisnik();

			try
			{
				obj = (PristupBazi.KorisnikT)konverzija.objekatuModel(listaObjekata[0]);
			}
			catch
			{
				obj = null;
			}
		}

	}//end IzmIjeniKorisnik

}//end namespace FamilyTree