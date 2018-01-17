using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boite
{
    public enum Couleurs
    {
        blanc, bleu, vert, jaune, orange, rouge, marron
    }

    public enum Matieres
    {
        carton, plastique, bois, métal
    }

    public enum Formats
    {
        xs, s, m, l, xl
    }


    public class Boite
    {
        #region Proprietes


        private double _hauteur = 30.0;
        private double _largeur = 30.0;
        private double _longueur = 30.0;
        private double _volume;
        private double _poids;
        private double _poidsDispo;
        public int nbAticlesDansBoite = 0;


        private static int _nbInstancesCrees = 0;

        private Etiquette _etiquetteDest;

        private Etiquette _etiquetteFragile;

        public const double PoidsMax = 10;

        public const double VolumeMax = 200;

        private List<Article> _articles;

        public double Poids
        {
            get { return _poids; }
            set { _poids = value; }
        }

        public double PoidsDispo
        {
            get { return _poidsDispo; }
            set { _poidsDispo = value; }
        }

        

        public static int NbInstancesCrees
        {
            get { return _nbInstancesCrees; }

        }


        public double Hauteur
        {
            get { return _hauteur; }
            //set { _hauteur = value; }
        }
        public double Largeur
        {
            get { return _largeur; }
            //set { _largeur = value; }
        }

        public double Longueur
        {
            get { return _longueur; }
            //set { _longueur = value; }
        }




        public Couleurs MaCouleur { get; set; }
        public Matieres MaMatiere { get; } = Matieres.carton;


        public Etiquette EtiquetteDest
        {
            get { return _etiquetteDest; }
            set { _etiquetteDest = value; }
        }
        public Etiquette EtiquetteFragile
        {
            get { return _etiquetteFragile; }
            set { _etiquetteFragile = value; }
        }


        #endregion

        #region Constructeurs


        public Boite(double h, double la, double lo)
        {
            _hauteur = h;
            _largeur = la;
            _longueur = lo;

            _nbInstancesCrees++;

            _articles = new List<Article>();
        }

        public Boite(double h, double la, double lo, Matieres m) : this(h, la, lo)
        {
            MaMatiere = m;
        }
        #endregion

        public double Volume
        {
            get { return _volume = _hauteur * _largeur * _longueur; }
        }




        public void Etiqueter(string destinataire)
        {
            _etiquetteDest = new Etiquette { Couleur = Couleurs.blanc, Format = Formats.l, Texte = destinataire };
        }

        public void Etiqueter(string destinataire, bool fragile)
        {


            if (fragile)
            {
                _etiquetteFragile = new Etiquette { Couleur = Couleurs.rouge, Format = Formats.s, Texte = "FRAGILE" };
            }

        }

        public void Etiqueter(Etiquette etiquDest, Etiquette etiqFragilite)
        {
            _etiquetteDest = etiquDest;
            _etiquetteFragile = etiqFragilite;
        }

        public bool Compare(Boite a)
        {

            return ((a.Hauteur == Hauteur) && (a.Largeur == Largeur) && (a.Longueur == Longueur) && (a.MaMatiere == MaMatiere));

        }

        public void AjouterArticle(Article art)
        {

            _articles.Add(art);
            nbAticlesDansBoite++;

            _volume += art.Volume;
            _poids += art.Poids;

            if (_poids > PoidsMax) throw new InvalidOperationException("Le poids ne doit pas dépasser le poids maximum");

            if (_volume > VolumeMax) throw new InvalidOperationException("Le volume ne doit pas dépasser le volume maximum");

        }

        

        public void RetirerArticle(Article art)
        {
            _articles.Remove(art);
            _volume -= art.Volume;
            _poids -= art.Poids;
            nbAticlesDansBoite--;
        }

        public void Transferer(Boite b)
        {
          
            foreach (Article a in _articles)
            {
                b.RetirerArticle(a);
                
            }
            
            for (int i = _articles.Count - 1; i >= 0; i--)
            {
                RetirerArticle(_articles[i]);
                
            }
            

        }

        public override string ToString()
        {
            return $"hauteur : {_hauteur}, largeur : {_largeur}, longueur : {_longueur}, nombre d'articles dans la boite : {nbAticlesDansBoite}";
        }
    }
}