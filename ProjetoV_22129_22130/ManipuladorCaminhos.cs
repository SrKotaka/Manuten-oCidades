using System.IO;

namespace ProjetoV_22129_22130
{
    public static class ManipuladorCaminhos
    {
        private const string CaminhoArquivoCaminhos = "CaminhosEntreCidadesMarte.dat";

        // Leitura do arquivo binário de caminhos
        public static void CarregarCaminhos(ArvoreBinaria arvore)
        {
            if (!File.Exists(CaminhoArquivoCaminhos))
                return;

            using (var stream = new FileStream(CaminhoArquivoCaminhos, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                while (stream.Position < stream.Length)
                {
                    string origem = new string(reader.ReadChars(15)).Trim();
                    string destino = new string(reader.ReadChars(15)).Trim();
                    int distancia = reader.ReadInt32();
                    int tempo = reader.ReadInt32();
                    int custo = reader.ReadInt32();

                    var cidadeOrigem = arvore.Buscar(origem);
                    var cidadeDestino = arvore.Buscar(destino);

                    if (cidadeOrigem != null && cidadeDestino != null)
                    {
                        var caminho = new Caminho(cidadeDestino, distancia, tempo, custo);
                        cidadeOrigem.Caminhos.Add(caminho);
                    }
                }
            }
        }

        // Escrita no arquivo binário de caminhos
        public static void SalvarCaminhos(ArvoreBinaria arvore)
        {
            using (var stream = new FileStream(CaminhoArquivoCaminhos, FileMode.Create))
            using (var writer = new BinaryWriter(stream))
            {
                var cidades = arvore.ListarEmOrdem();

                foreach (var cidade in cidades)
                {
                    foreach (var caminho in cidade.Caminhos)
                    {
                        writer.Write(cidade.Nome.PadRight(15).ToCharArray());
                        writer.Write(caminho.Destino.Nome.PadRight(15).ToCharArray());
                        writer.Write(caminho.Distancia);
                        writer.Write(caminho.Tempo);
                        writer.Write(caminho.Custo);
                    }
                }
            }
        }
    }
}
