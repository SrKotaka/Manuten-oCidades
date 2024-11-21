namespace ProjetoV_22129_22130
{
    public class Caminho
    {
        public Cidade Destino { get; set; }
        public int Distancia { get; set; }
        public int Tempo { get; set; }
        public int Custo { get; set; }

        public Caminho(Cidade destino, int distancia, int tempo, int custo)
        {
            Destino = destino;
            Distancia = distancia;
            Tempo = tempo;
            Custo = custo;
        }
    }

}
