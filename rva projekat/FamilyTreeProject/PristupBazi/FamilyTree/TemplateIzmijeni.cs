///////////////////////////////////////////////////////////
//  TemplateIzmijeni.cs
//  Implementation of the Class TemplateIzmijeni
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
	public abstract class TemplateIzmijeni : IBaza {

		public TemplateIzmijeni()
		{
			listaObjekata = new List<ObjekatSistema>();
		}

		~TemplateIzmijeni(){}

		public void Akcija()
		{
			KonverzijaObjekatuModel();
			Izmijeni();
		}

		protected abstract void Izmijeni();

		protected abstract void KonverzijaObjekatuModel();

		public List<ObjekatSistema> listaObjekata
		{
			get; set;
		}

		public IKonverzijaObjekta konverzija { get; set; }

	}//end TemplateIzmijeni

}//end namespace FamilyTree