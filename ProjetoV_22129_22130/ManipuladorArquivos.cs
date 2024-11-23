using System.IO;

namespace ProjetoV_22129_22130
{
    public class ManipuladorArquivos
    {
        private const string CaminhoArquivoCidades = "CidadesMarte.dat";

        // Leitura do arquivo binário de cidades
        public static ArvoreBinaria CarregarCidades()
        {
            var arvore = new ArvoreBinaria();

            if (!File.Exists(CaminhoArquivoCidades))
                return arvore;

            using (var stream = new FileStream(CaminhoArquivoCidades, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                while (stream.Position < stream.Length)
                {
                    string nome = new string(reader.ReadChars(15)).Trim();
                    int x = reader.ReadInt32();
                    int y = reader.ReadInt32();

                    var cidade = new Cidade(nome, x, y);
                    arvore.Inserir(cidade);
                }
            }

            return arvore;
        }

        // Escrita no arquivo binário de cidades
        public static void SalvarCidades(ArvoreBinaria arvore)
        {
            using (var stream = new FileStream(CaminhoArquivoCidades, FileMode.Create))
            using (var writer = new BinaryWriter(stream))
            {
                var cidades = arvore.ListarEmOrdem();

                foreach (var cidade in cidades)
                {
                    writer.Write(cidade.Nome.PadRight(15).ToCharArray());
                    writer.Write(cidade.X);
                    writer.Write(cidade.Y);
                }
            }
        }
    }
}
