using FamilyTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testiranje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProcitajKorisnik procitajK = new ProcitajKorisnik();
            ProcitajBiografija procitajB = new ProcitajBiografija();

            List<TemplateProcitaj> templateProcitajs = new List<TemplateProcitaj>(2) { procitajK, procitajB };

            templateProcitajs.ForEach(procitaj =>
            {
                procitaj.Akcija();
                Console.WriteLine();
            });

           

            Console.ReadKey();
        }
    }
}
