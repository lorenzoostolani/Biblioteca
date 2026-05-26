using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Biblioteca.Domain
{
    using System;
    using System.Collections.Generic;

    namespace Biblioteca
    {
        class Program
        {
            static Biblioteca biblioteca = null;

            static void Main(string[] args)
            {
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║       GESTIONE BIBLIOTECA            ║");
                Console.WriteLine("╚══════════════════════════════════════╝\n");

                bool esci = false;

                while (!esci)
                {
                    MostraMenuPrincipale();
                    string scelta = Console.ReadLine();

                    switch (scelta)
                    {
                        case "1": CreaBiblioteca(); break;
                        case "2": AggiungiLibro(); break;
                        case "3": RicercaPerTitolo(); break;
                        case "4": RicercaPerAutore(); break;
                        case "5": MostraNumeroLibri(); break;
                        case "6": TestLibro(); break;
                        case "7": MostraInfoBiblioteca(); break;
                        case "0":
                            esci = true;
                            Console.WriteLine("\nArrivederci!");
                            break;
                        default:
                            Console.WriteLine("\n⚠ Scelta non valida. Riprova.");
                            Pausa();
                            break;
                    }
                }
            }

            // ── Menu principale ────────────────────────────────────────────
            static void MostraMenuPrincipale()
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║       GESTIONE BIBLIOTECA            ║");
                Console.WriteLine("╠══════════════════════════════════════╣");

                if (biblioteca == null)
                    Console.WriteLine("║  ⚠ Nessuna biblioteca creata         ║");
                else
                    Console.WriteLine($"║  📚 {biblioteca.Nome,-34}║");

                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║  1. Crea biblioteca                  ║");
                Console.WriteLine("║  2. Aggiungi libro                   ║");
                Console.WriteLine("║  3. Cerca libro per titolo           ║");
                Console.WriteLine("║  4. Cerca libri per autore           ║");
                Console.WriteLine("║  5. Mostra numero libri              ║");
                Console.WriteLine("║  6. Test funzionalità oggetto Libro  ║");
                Console.WriteLine("║  7. Info biblioteca                  ║");
                Console.WriteLine("║  0. Esci                             ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("\nScelta: ");
            }

            // ── 1. Crea biblioteca ─────────────────────────────────────────
            static void CreaBiblioteca()
            {
                Console.Clear();
                Console.WriteLine("=== CREA BIBLIOTECA ===\n");

                Console.Write("Nome biblioteca: ");
                string nome = Console.ReadLine();

                Console.Write("Indirizzo: ");
                string indirizzo = Console.ReadLine();

                Console.Write("Orario apertura (es. 09:00): ");
                string apertura = Console.ReadLine();

                Console.Write("Orario chiusura (es. 18:00): ");
                string chiusura = Console.ReadLine();

                biblioteca = new Biblioteca(nome, indirizzo, apertura, chiusura);

                Console.WriteLine($"\n✅ Biblioteca \"{nome}\" creata con successo!");
                Pausa();
            }

            // ── 2. Aggiungi libro ──────────────────────────────────────────
            static void AggiungiLibro()
            {
                Console.Clear();
                Console.WriteLine("=== AGGIUNGI LIBRO ===\n");

                if (biblioteca == null)
                {
                    Console.WriteLine("⚠ Devi prima creare una biblioteca (opzione 1).");
                    Pausa();
                    return;
                }

                Console.Write("Autore: ");
                string autore = Console.ReadLine();

                Console.Write("Titolo: ");
                string titolo = Console.ReadLine();

                Console.Write("Anno di pubblicazione: ");
                int anno;
                while (!int.TryParse(Console.ReadLine(), out anno))
                {
                    Console.Write("⚠ Inserisci un anno valido: ");
                }

                Console.Write("Editore: ");
                string editore = Console.ReadLine();

                Console.Write("Numero pagine: ");
                int pagine;
                while (!int.TryParse(Console.ReadLine(), out pagine) || pagine <= 0)
                {
                    Console.Write("⚠ Inserisci un numero di pagine valido: ");
                }

                Libro libro = new Libro(autore, titolo, anno, editore, pagine);
                biblioteca.AggiungiLibro(libro);

                Console.WriteLine($"\n✅ Libro \"{titolo}\" aggiunto con successo!");
                Console.WriteLine(libro.ToString());
                Console.WriteLine(libro.ReadingTime());
                Pausa();
            }

            // ── 3. Ricerca per titolo ──────────────────────────────────────
            static void RicercaPerTitolo()
            {
                Console.Clear();
                Console.WriteLine("=== RICERCA PER TITOLO ===\n");

                if (biblioteca == null)
                {
                    Console.WriteLine("⚠ Devi prima creare una biblioteca (opzione 1).");
                    Pausa();
                    return;
                }

                Console.Write("Inserisci il titolo da cercare: ");
                string titolo = Console.ReadLine();

                Libro trovato = biblioteca.RicercaPerTitolo(titolo);

                if (trovato != null)
                {
                    Console.WriteLine("\n✅ Libro trovato:");
                    Console.WriteLine(trovato.ToString());
                    Console.WriteLine(trovato.ReadingTime());
                }
                else
                {
                    Console.WriteLine($"\n❌ Nessun libro trovato con titolo \"{titolo}\".");
                }

                Pausa();
            }

            // ── 4. Ricerca per autore ──────────────────────────────────────
            static void RicercaPerAutore()
            {
                Console.Clear();
                Console.WriteLine("=== RICERCA PER AUTORE ===\n");

                if (biblioteca == null)
                {
                    Console.WriteLine("⚠ Devi prima creare una biblioteca (opzione 1).");
                    Pausa();
                    return;
                }

                Console.Write("Inserisci il nome dell'autore: ");
                string autore = Console.ReadLine();

                List<Libro> risultati = biblioteca.RicercaPerAutore(autore);

                if (risultati.Count > 0)
                {
                    Console.WriteLine($"\n✅ Trovati {risultati.Count} libro/i di \"{autore}\":\n");
                    for (int i = 0; i < risultati.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}. {risultati[i].ToString()}");
                        Console.WriteLine($"     {risultati[i].ReadingTime()}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n❌ Nessun libro trovato per l'autore \"{autore}\".");
                }

                Pausa();
            }

            // ── 5. Numero libri ────────────────────────────────────────────
            static void MostraNumeroLibri()
            {
                Console.Clear();
                Console.WriteLine("=== NUMERO LIBRI ===\n");

                if (biblioteca == null)
                {
                    Console.WriteLine("⚠ Devi prima creare una biblioteca (opzione 1).");
                    Pausa();
                    return;
                }

                Console.WriteLine($"📚 La biblioteca \"{biblioteca.Nome}\" contiene {biblioteca.NumeroLibri()} libro/i.");
                Pausa();
            }

            // ── 6. Test oggetto Libro ──────────────────────────────────────
            static void TestLibro()
            {
                Console.Clear();
                Console.WriteLine("=== FUNZIONALITÀ OGGETTO LIBRO ===\n");

                bool tornaIndietro = false;

                while (!tornaIndietro)
                {
                    Console.WriteLine("Cosa vuoi fare?");
                    Console.WriteLine("  1. Crea un libro e mostra toString");
                    Console.WriteLine("  2. Testa readingTime su un libro");
                    Console.WriteLine("  3. Modifica i dati di un libro tramite proprietà");
                    Console.WriteLine("  0. Torna al menu principale");
                    Console.Write("\nScelta: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("--- Crea un libro ---\n");
                            Libro l = InserisciLibro();
                            Console.WriteLine("\n📖 ToString():");
                            Console.WriteLine(l.ToString());
                            Pausa();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("--- ReadingTime ---\n");
                            Libro l2 = InserisciLibro();
                            Console.WriteLine($"\n⏱ {l2.ReadingTime()}");
                            Pausa();
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("--- Modifica dati libro ---\n");
                            Libro l3 = InserisciLibro();
                            Console.WriteLine("\nLibro originale:");
                            Console.WriteLine(l3.ToString());

                            Console.Write("\nNuovo titolo: ");
                            l3.Titolo = Console.ReadLine();

                            Console.Write("Nuovo autore: ");
                            l3.Autore = Console.ReadLine();

                            Console.Write("Nuovo anno: ");
                            int anno;
                            while (!int.TryParse(Console.ReadLine(), out anno))
                                Console.Write("⚠ Anno non valido: ");
                            l3.AnnoPubblicazione = anno;

                            Console.Write("Nuovo editore: ");
                            l3.Editore = Console.ReadLine();

                            Console.Write("Nuovo numero pagine: ");
                            int pag;
                            while (!int.TryParse(Console.ReadLine(), out pag) || pag <= 0)
                                Console.Write("⚠ Pagine non valide: ");
                            l3.NumeroPagine = pag;

                            Console.WriteLine("\nLibro modificato:");
                            Console.WriteLine(l3.ToString());
                            Console.WriteLine(l3.ReadingTime());
                            Pausa();
                            break;

                        case "0":
                            tornaIndietro = true;
                            break;

                        default:
                            Console.WriteLine("⚠ Scelta non valida.");
                            Pausa();
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine("=== FUNZIONALITÀ OGGETTO LIBRO ===\n");
                }
            }

            

            // ── Helper: inserimento libro da console ───────────────────────
            static Libro InserisciLibro()
            {
                Console.Write("Autore: ");
                string autore = Console.ReadLine();

                Console.Write("Titolo: ");
                string titolo = Console.ReadLine();

                Console.Write("Anno: ");
                int anno;
                while (!int.TryParse(Console.ReadLine(), out anno))
                    Console.Write("⚠ Anno non valido: ");

                Console.Write("Editore: ");
                string editore = Console.ReadLine();

                Console.Write("Pagine: ");
                int pagine;
                while (!int.TryParse(Console.ReadLine(), out pagine) || pagine <= 0)
                    Console.Write("⚠ Pagine non valide: ");

                return new Libro(autore, titolo, anno, editore, pagine);
            }

            // ── Helper: attendi invio ──────────────────────────────────────
            static void Pausa()
            {
                Console.Write("\nPremi INVIO per continuare...");
                Console.ReadLine();
            }
        }
    }
}
