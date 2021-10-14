///////////////////////////////////////////////////////////
//  TemplateProcitaj.cs
//  Implementation of the Class TemplateProcitaj
//  Generated by Enterprise Architect
//  Created on:      06-okt-2021 14:41:30
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FamilyTree;
namespace FamilyTree {
	public abstract class TemplateProcitaj : IBaza {

		public TemplateProcitaj()
		{
			listaObjekata = new List<ObjekatSistema>();
		}

		~TemplateProcitaj(){}

		public void Akcija()
		{
			Citanje();
			KonverzijaModeluObjekat();
		}

		protected abstract void Citanje();

		protected abstract void KonverzijaModeluObjekat();

		public IKonverzijaObjekta konverzija { get; set; }

		public List<ObjekatSistema> listaObjekata{ get;set;	}

	}//end TemplateProcitaj

}//end namespace FamilyTree