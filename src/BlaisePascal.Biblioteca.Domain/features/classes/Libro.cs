using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Biblioteca.Domain.features.classes
{
    public class Libro
    {
        private string Autore { set; get; }
        private string Titolo { set; get; }
        private int AnnoPubblicazione { set; get; }
        private string Editore { set; get; }
        private int NumeroPagine { set; get; }

        public Libro(string autore, string titolo, int annoPubblicazione, string editore, int numeroPagine)
        {
            Autore = autore;
            Titolo = titolo;
            AnnoPubblicazione = annoPubblicazione;
            Editore = editore;
            NumeroPagine = numeroPagine;
        }

        public override string ToString()
        {
            return $"Titolo: {Titolo} | Autore: {Autore} | Anno: {AnnoPubblicazione} | Editore: {Editore} | Pagine: {NumeroPagine}";
        }

        public string ReadingTime()
        {
            if (NumeroPagine < 100)
                return "Tempo di lettura stimato: 1h";
            else if (NumeroPagine >= 100 && NumeroPagine <= 200)
                return "Tempo di lettura stimato: 2h";
            else
                return "Tempo di lettura stimato: più di 2h";
        }


    }

}
