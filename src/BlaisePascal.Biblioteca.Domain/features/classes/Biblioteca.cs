using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Biblioteca.Domain.features.classes
{
    public class Biblioteca
    {
        public string Nome { set; get; }
        public string Indirizzo { set; get; }
        public string OrarioApertura { set; get; }
        public string OrarioChiusura { set; get; }
        public List<Libro> Libri { set; get; }

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
            foreach (Libro l in Libri)
            {
                if (l.Titolo.Equals(titolo, StringComparison.OrdinalIgnoreCase))
                    return l;
            }
            return null;
        }


        public List<Libro> RicercaPerAutore(string autore)
        {
            List<Libro> risultati = new List<Libro>();
            foreach (Libro l in Libri)
            {
                if (l.Autore.Equals(autore, StringComparison.OrdinalIgnoreCase))
                    risultati.Add(l);
            }
            return risultati;
        }


    }
}
