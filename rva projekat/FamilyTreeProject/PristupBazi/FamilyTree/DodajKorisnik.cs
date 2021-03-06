///////////////////////////////////////////////////////////
//  DodajKorisnik.cs
//  Implementation of the Class DodajKorisnik
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
	public class DodajKorisnik : TemplateDodaj {

		PristupBazi.KorisnikT obj;

		public DodajKorisnik(){}

		~DodajKorisnik(){}

		protected override void Dodaj()
		{
			obj.id = this.NextId();

			using(var db = new PristupBazi.DataBase())
			{
				if( obj != null)
				{
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

		protected override int NextId()
		{
			int ret = -1;

			using (var db = new PristupBazi.DataBase())
			{
				ret = db.KorisnikT.Max(x => x.id) + 1;
			}

			return ret;
		}
	}//end DodajKorisnik

}//end namespace FamilyTree