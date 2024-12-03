using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoV_22129_22130
{
    
    public class NoArvore
    {
        public Cidade Cidade { get; set; }
        public NoArvore Esquerda { get; set; }
        public NoArvore Direita { get; set; }

        public NoArvore(Cidade cidade)
        {
            Cidade = cidade;
            Esquerda = null;
            Direita = null;
        }
    }
    


    /*
    public class NoArvore<Dado> : IComparable<NoArvore<Dado>>
                              where Dado : IComparable<Dado>
    {
        Dado info;
        NoArvore<Dado> esq;
        NoArvore<Dado> dir;

        public Dado Info { get => info; set => info = value; }
        public NoArvore<Dado> Esq { get => esq; set => esq = value; }
        public NoArvore<Dado> Dir { get => dir; set => dir = value; }

        public NoArvore(Dado info, NoArvore<Dado> esq,
                        NoArvore<Dado> dir)
        {
            this.info = info;
            this.esq = esq;
            this.dir = dir;
        }

        public NoArvore(Dado info)
        {
            this.info = info;
            this.esq = this.dir = null; // importantíssimo!!!
        }

        public int CompareTo(NoArvore<Dado> outro)
        {
            return info.CompareTo(outro.info);
        }

        public bool Equals(NoArvore<Dado> outro)
        {
            return info.Equals(outro.info);
        }
    }
    */

    
}
