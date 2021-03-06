///////////////////////////////////////////////////////////
//  DodajBiografija.cs
//  Implementation of the Class DodajBiografija
//  Generated by Enterprise Architect
//  Created on:      06-okt-2021 14:41:29
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FamilyTree;
using PristupBazi;
using System.Linq;

namespace FamilyTree {
	public class DodajBiografija : TemplateDodaj {

		private PristupBazi.BiografijaT obj; 

		public DodajBiografija(){}

		~DodajBiografija(){}

		protected override void Dodaj()
		{
			obj.id = this.NextId();
			using (var db = new DataBase())
			{
				if (obj != null)
				{
					db.BiografijaT.Add(obj);
					db.SaveChanges();
				}
			}
		}

		protected override void KonverzijaObjekatuModel(){

			konverzija = new StrategyKonverzijaBiografija();

			try
			{
				obj = (PristupBazi.BiografijaT)konverzija.objekatuModel(base.listaObjekata[0]); //ovaj dodajem objekat
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
				ret = db.BiografijaT.Max(x => x.id) + 1;
			}

			return ret;
		}
	}//end DodajBiografija

}//end namespace FamilyTree