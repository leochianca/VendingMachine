using static System.Console;
using System.Collections.Generic;
using System.Globalization;

class Machine
{
    //Atributos da Vending Machine (uma lista de Produtos, um atributo para o valor total e um para o total de produtos vendidos)
    private List<Product> estoque = new List<Product>(){ new Product("Coca-Cola", "A1", 6.50, 15), 
                                                         new Product("Sprite", "A2", 6.50, 20),
                                                         new Product("Guaraná Antarctica", "A3", 6.00, 35), 
                                                         new Product("Fanta Uva", "A4", 6.00, 10),
                                                         new Product("Fanta Laranja", "A5", 6.00, 10)};
    private double vendasTotais;
    private int produtosVendidos;

    //Métodos da classe Machine
    public Machine()
    {
        vendasTotais = 0;
        produtosVendidos = 0;
    }
    public List<Product> getEstoque() {return estoque;}
    
    //Contabiliza a quantidade de produto vendidos e o valor total arrecadado
    public void ContabilizaVendas(double vendas, int produtos) 
    {
        vendasTotais += vendas;
        produtosVendidos += produtos;
    }
    public double getVendasTotais() {return vendasTotais;}
    public int getProdutosVendidos() { return produtosVendidos; }
    
    //Exibe o estoque da Vending Machine com todos os atributos
    public void ExibirEstoque()
    {
        foreach(Product p in estoque)
            WriteLine($"Nome: {p.getNome()}\nID: {p.getId()}\nValor: {p.getValor().ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}\nQuantidade: {p.getQuantidade()}\n");
    }
    
    //Verifica o produto com o ID passado como parametro para realizar a venda
    public void RealizarVenda(string id, int quant, double valor)
    {
        foreach(Product p in estoque)
        {
            if(p.getId() == id)
            {
                p.setQuantidade(p.getQuantidade() - quant);
                ContabilizaVendas(valor, quant);
                return;
            }
        }
    }
}