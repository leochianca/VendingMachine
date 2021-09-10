using static System.Console;
using System.Globalization;

//Classe para controlar as exibições de mensagens e interação no console
class Menu
{
    private Machine machine;

    public Menu(){ machine = new Machine(); }
    public void VoltarMenu()
    {
        WriteLine("Pressione qualquer tecla para voltar ao Menu");
        ReadKey();
        Clear();
    }
    public void ExibirMenu()
    {
        WriteLine("Bem vindo!\nO que você gostaria de fazer?\n");
        WriteLine("[0] - Fechar Sistema\n[1] - Visualizar Estoque\n[2] - Comprar\n[3] - Ver Total de Vendas\n");
    }
    public void ExibirMenu1()
    {
        machine.ExibirEstoque();
    }
    public void ExibirMenu2()
    {
        WriteLine("-----Produtos disponíveis-----");
        machine.ExibirEstoque();
        
        Write("Digite o ID do produto: ");
        string id = ReadLine();

        bool achou = false;

        foreach(Product p in machine.getEstoque())
        {
            if(p.getId() == id)
            {
                achou = true;

                if(p.getQuantidade() == 0)
                {
                    WriteLine("\nProduto em falta\nVolte ao Menu e tente novamente\n");
                    return;
                }

                Write("Digite a quantidade desejada: ");
                int quant = int.Parse(ReadLine());

                if(p.getQuantidade() < quant)
                {
                    WriteLine("\nQuantidade indisponivel\nVolte ao Menu e tente novamente\n");
                    return;
                }

                double preco = p.getValor()*quant;
                WriteLine($"\nPreço: {preco.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
                Write("Insira o dinheiro: ");
                double valorInserido = double.Parse(ReadLine());

                while(valorInserido < preco)
                {
                    Write($"Por favor, insira o valor Restante ({(preco - valorInserido).ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}): ");
                    double valorRestante = double.Parse(ReadLine());
                    valorInserido += valorRestante;
                }

                if(valorInserido > preco) WriteLine($"Troco: {(valorInserido - preco).ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");

                machine.RealizarVenda(id, quant, preco);
                WriteLine("\nVenda Concluída!\nVolte Sempre!\n");
                return;
            }
        }

        if(!achou)
        {
            WriteLine("\nProduto não encontrado\nVolte ao Menu e tente novamente\n  ");
            return;
        }
    }
    public void ExibirMenu3()
    {
        WriteLine($"Quantidade total de produtos vendidos: {machine.getProdutosVendidos()}");
        WriteLine($"Valor total arrecadado: {machine.getVendasTotais().ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n");
    }

}
