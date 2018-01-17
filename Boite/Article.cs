using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boite
{
    public class Article
    {
        #region Proprietes
        private Guid _id;
        private string _libelle;
        private double _volume;
        private double _poids;



        public Guid Id
        {
            get { return _id; }
        }
        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }


        public double Volume
        {
            get { return _volume; }
        }
        public double Poids
        {
            get { return _poids; }
        }
        #endregion

        public Article()
        {

        }

        public Article(string lib, double vol, double po)
        {

            _id = Guid.NewGuid();
            _libelle = lib;
            _volume = vol;
            _poids = po;
        }

        public override string ToString()
        {
            return $"Code : {_id}, libellé : {_libelle}, volume : {_volume} cm3, poids : {_poids} kg";
        }
    }
}