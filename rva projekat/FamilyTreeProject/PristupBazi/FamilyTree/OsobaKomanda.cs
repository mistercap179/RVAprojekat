///////////////////////////////////////////////////////////
//  OsobaKomanda.cs
//  Implementation of the Class OsobaKomanda
//  Generated by Enterprise Architect
//  Created on:      06-okt-2021 14:41:29
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FamilyTree {
	public abstract class OsobaKomanda {

		public OsobaKomanda(){}

		~OsobaKomanda(){}

		public abstract void Execute();
		public abstract void UnExecute();

	}//end OsobaKomanda

}//end namespace FamilyTree