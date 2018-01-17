using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boite
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase1 = "Les deux boites sont identiques";
            string phrase2 = "Les deux boites sont differentes";

            Boite a = new Boite(50, 10, 60);
            Boite b = new Boite(40, 10, 50);
            Boite c = new Boite(40, 10, 50);

            var d = new Boite(40, 10, 50, Matieres.bois);
            var e = new Boite(40, 10, 50, Matieres.métal);
            var f = new Boite(40, 10, 50, Matieres.métal);

            var g = new Boite(20, 50, 50, Matieres.plastique);

            g.Etiqueter("Un destinataire", true);

            var h = new Boite(30, 40, 50, Matieres.plastique);
            var i = new Etiquette { Couleur = Couleurs.blanc, Format = Formats.l, Texte = "Un destinataire" };
            var j = new Etiquette { Couleur = Couleurs.rouge, Format = Formats.s, Texte = "FRAGILE" };

            h.Etiqueter(i, j);
            Console.WriteLine(h);

            Console.WriteLine(a);

            if (a.Compare(b))
            {
                Console.WriteLine(phrase1);
            }
            else
            {
                Console.WriteLine(phrase2);
            }


            if (b.Compare(c))
            {
                Console.WriteLine(phrase1);
            }
            else
            {
                Console.WriteLine(phrase2);
            }

            if (d.Compare(e))
            {
                Console.WriteLine(phrase1);
            }
            else
            {
                Console.WriteLine(phrase2);
            }

            Article MonArticle1 = new Article("Une basse", 64, 2);

            Article MonArticle2 = new Article("Une guitare", 2, 1);

            Article MonArticle3 = new Article("Une autre gratte", 22, 1);


            List<Article> MaListeA = new List<Article>();
            MaListeA.Add(MonArticle1);
            MaListeA.Add(MonArticle2);
            MaListeA.Add(MonArticle3);

            Console.WriteLine("");
            Console.WriteLine("");

            foreach (Article article in MaListeA)
            {
                //Console.WriteLine(article);
            }

            Console.WriteLine("");
            Console.WriteLine("");

            /*
            MaListeA.Clear();

            Article MonArticle4 = new Article("Nom modifié", 125, 7);
            Article MonArticle5 = new Article("Une autre gratte", 226, 11);

            MaListeA.Add(MonArticle4);
            MaListeA.Add(MonArticle5);
            
            foreach (Article article in MaListeA)
            {
                Console.WriteLine(article);
            }
            */




            Boite MaBoite1 = new Boite(40, 10, 50, Matieres.métal);

            try
            {

                
                MaBoite1.AjouterArticle(MonArticle1);
                MaBoite1.AjouterArticle(MonArticle2);
                MaBoite1.AjouterArticle(MonArticle3);



            }
            catch (InvalidOperationException except)
            {

                Console.WriteLine(except.Message);
            }


            Console.WriteLine(MaBoite1.ToString());

            MaBoite1.RetirerArticle(MonArticle1);
            Console.WriteLine("Et après :");
            Console.WriteLine(MaBoite1.ToString());
            Console.WriteLine("Et à la fin");

            Boite MaBoite2 = new Boite(40, 10, 50, Matieres.plastique);
            MaBoite1.Transferer(MaBoite2);
            Console.WriteLine(MaBoite1.ToString());
            
            Console.ReadKey();
        }
    }
}