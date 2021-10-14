///////////////////////////////////////////////////////////
//  IKonverzijaObjekta.cs
//  Implementation of the Interface IKonverzijaObjekta
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

namespace FamilyTree {
	public interface IKonverzijaObjekta  {

		ObjekatSistema modeluObjekat(Model model);

		Model objekatuModel(ObjekatSistema obj);
	}//end IKonverzijaObjekta

}//end namespace FamilyTree