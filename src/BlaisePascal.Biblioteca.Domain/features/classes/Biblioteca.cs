using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Biblioteca.Domain.features.classes
{
    public class Biblioteca
    {
        private string Nome { set; get; }
        private string Indirizzo { set; get; }
        private string OrarioApertura { set; get; }
        private string OrarioChiusura { set; get; }
        private List<Libro> Libri { set; get; }

        public Biblioteca(string nome, string indirizzo, string orarioApertura, string orarioChiusura)
        {
            Nome = nome;
            Indirizzo = indirizzo;
            OrarioApertura = orarioApertura;
            OrarioChiusura = orarioChiusura;
            Libri = new List<Libro>();
        }

        public int NumeroLibri()
        {
            return Libri.Count;
        }

        public Libro RicercaPerTitolo(string titolo)
        {
            foreach (Libro l in libri)
            {
                if (l.Titolo.Equals(titolo, StringComparison.OrdinalIgnoreCase))
                    return l;
            }
            return null;
        }


        public List<Libro> RicercaPerAutore(string autore)
        {
            List<Libro> risultati = new List<Libro>();
            foreach (Libro l in libri)
            {
                if (l.Autore.Equals(autore, StringComparison.OrdinalIgnoreCase))
                    risultati.Add(l);
            }
            return risultati;
        }


    }
}
