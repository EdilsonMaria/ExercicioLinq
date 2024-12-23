namespace ExercicioLinq
{
    public class ExercicioLinqTests
    {
        private readonly List<Produto> produtos =
            [
                new Produto { Nome = "Sabão", Valor = 1.1m, Quantidade = 10 },
                new Produto { Nome = "Detergente de prato", Valor = 10, Quantidade = 9 },
                new Produto { Nome = "Água", Valor = (decimal)8.2f, Quantidade = 8 },
                new Produto { Nome = "Esponja", Valor = (decimal)5.5, Quantidade = 7 },
                new Produto { Nome = "Água sanitária", Valor = (decimal)30.30d, Quantidade = 6 },
                new Produto { Nome = "Vassoura", Valor = 3.3m, Quantidade = 5 },
                new Produto { Nome = "Desinfetante", Valor = 4.4m, Quantidade = 4 },
                new Produto { Nome = "Pano de chão", Valor = 5.5m, Quantidade = 3 },
                new Produto { Nome = "Purificador de água", Valor = 6.6m, Quantidade = 2 },
                new Produto { Nome = "Balde", Valor = 10.1m, Quantidade = 1 },
            ];

        [Fact(DisplayName = "Quantidade de produtos que possuem a palavra 'água' no nome.")]
        public void Test1()
        {
            int quantidade = produtos.Count(a => a.Nome.Contains("água", StringComparison.CurrentCultureIgnoreCase));

            Assert.Equal(3, quantidade);
        }

        [Fact(DisplayName = "Produtos ordenados por nome.")]
        public void Test2()
        {
            IEnumerable<Produto> produtosOrdenados = produtos.OrderBy(a => a.Nome);

            Assert.Equal("Água", produtosOrdenados.First().Nome);
            Assert.Equal("Vassoura", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produtos ordenados do mais caro para o mais barato.")]
        public void Test3()
        {
            IEnumerable<Produto> produtosOrdenados = produtos.OrderByDescending(a => a.Valor);

            Assert.Equal("Água sanitária", produtosOrdenados.First().Nome);
            Assert.Equal("Sabão", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produto mais caro")]
        public void Test4()
        {
            Produto produto = produtos.MaxBy(a => a.Valor);


            Assert.Equal("Água sanitária", produto.Nome);
        }

        [Fact(DisplayName = "Produto mais barato")]
        public void Test5()
        {
            Produto produto = produtos.OrderBy(a => a.Valor).First();

            Assert.Equal("Sabão", produto.Nome);
        }

        [Fact(DisplayName = "Lista dos nomes dos produtoss")]
        public void Test6()
        {
            IEnumerable<string> nomeDosProdutos = produtos.OrderBy(a => a.Nome).Select(a => a.Nome);

            Assert.Contains("Água", nomeDosProdutos);
        }

        [Fact(DisplayName = "Quantidade total de todos dos produtos")]
        public void Test7()
        {
            int quantidade = produtos.Sum(a => a.Quantidade);

            Assert.Equal(55, quantidade);
        }

        [Fact(DisplayName = "Nome dos produtos com valor até 10.0")]
        public void Test8()
        {
            IEnumerable<string> nomeDosProdutos = produtos.Where(a => a.Valor <= 10m).Select(a => a.Nome);

            Assert.Contains("Detergente de prato", nomeDosProdutos);
            Assert.Contains("Sabão", nomeDosProdutos);
        }

        [Fact(DisplayName = "Nome dos produtos com valor maior 10.0")]
        public void Test9()
        {
            IEnumerable<string> nomeDosProdutos = produtos.Where(a => a.Valor > 10m).Select(a => a.Nome);

            Assert.Contains("Balde", nomeDosProdutos);
            Assert.Contains("Água sanitária", nomeDosProdutos);
        }

        [Fact(DisplayName = "Verifica se o produto 'pão' está na lista")]
        public void Test10()
        {
            bool existe = produtos.Any(a => a.Nome == "pão");

            Assert.False(existe);
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}