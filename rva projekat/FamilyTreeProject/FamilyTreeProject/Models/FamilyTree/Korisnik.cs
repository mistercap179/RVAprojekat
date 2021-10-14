///////////////////////////////////////////////////////////
//  Korisnik.cs
//  Implementation of the Class Korisnik
//  Generated by Enterprise Architect
//  Created on:      05-okt-2021 21:42:29
//  Original author: AB
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FamilyTree;
namespace FamilyTree {
	public class Korisnik : ObjekatSistema {

		private string email;
		private int idK;
		private string ime;
		private string lozinka;
		private string prezime;
		private TipKorisnika tip;

		public Korisnik(){

		}

		~Korisnik(){

		}

		public string Email{
			get{
				return email;
			}
			set{
				email = value;
			}
		}

		public int IdK{
			get{
				return idK;
			}
			set{
				idK = value;
			}
		}

		public string Ime{
			get{
				return ime;
			}
			set{
				ime = value;
			}
		}

		public string Lozinka{
			get{
				return lozinka;
			}
			set{
				lozinka = value;
			}
		}

		public string Prezime{
			get{
				return prezime;
			}
			set{
				prezime = value;
			}
		}

		public TipKorisnika Tip{
			get{
				return tip;
			}
			set{
				tip = value;
			}
		}

	}//end Korisnik

}//end namespace FamilyTree