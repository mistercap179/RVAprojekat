///////////////////////////////////////////////////////////
//  KomandaObrisi.cs
//  Implementation of the Class KomandaObrisi
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
	public class KomandaObrisi : OsobaKomanda {

		public ObjekatSistema objekatSistema = new ObjekatSistema();
		IKonverzijaObjekta konverzija = new StrategyKonverzijaOsoba();
		public KomandaObrisi(){}

		~KomandaObrisi(){}

		public override void Execute()
		{
			using(var db = new PristupBazi.DataBase())
			{
				PristupBazi.OsobaT obj = (PristupBazi.OsobaT)konverzija.objekatuModel(objekatSistema);
				PristupBazi.OsobaT pomocniobjekat = db.OsobaT.Where(x => x.id == obj.id).FirstOrDefault();
				db.OsobaT.Remove(pomocniobjekat);
				db.SaveChanges();
			}
		}

		public override void UnExecute()
		{
			using(var db = new PristupBazi.DataBase())
			{
				db.OsobaT.Add((PristupBazi.OsobaT)konverzija.objekatuModel(objekatSistema));
				db.SaveChanges();
			}
		}

	}//end KomandaObrisi

}//end namespace FamilyTree