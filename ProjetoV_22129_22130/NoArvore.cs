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
}
