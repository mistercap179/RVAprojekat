///////////////////////////////////////////////////////////
//  ProcitajBiografija.cs
//  Implementation of the Class ProcitajBiografija
//  Generated by Enterprise Architect
//  Created on:      06-okt-2021 14:41:29
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FamilyTree;
namespace FamilyTree {
	public class ProcitajBiografija : TemplateProcitaj
	{
		List<PristupBazi.BiografijaT> biografije = new List<PristupBazi.BiografijaT>(); 
		public ProcitajBiografija(){}

		~ProcitajBiografija(){}

		protected override void Citanje()
		{
			using(var db = new PristupBazi.DataBase())
			{
				foreach(var biografija in db.BiografijaT)
				{
					biografije.Add(biografija);
				}
			}
		}

		protected override void KonverzijaModeluObjekat()
		{
			konverzija = new StrategyKonverzijaBiografija();
			listaObjekata = new List<ObjekatSistema>();
			try
			{
				for(int i = 0; i < biografije.Count; i++)
				{
					ObjekatSistema obj = konverzija.modeluObjekat(biografije[i]);
					listaObjekata.Add(obj);
				}
			}
			catch
			{
				listaObjekata = null; 
			}
		}


	}//end ProcitajBiografija

}//end namespace FamilyTree