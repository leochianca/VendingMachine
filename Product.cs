class Product
{
    //Atributos de cada Produto
    private string nome;
    private string id;
    private double valor;
    private int quantidade;

    //Métodos Get's e Set's e um Construtor que inicia todos os atributos
    public Product(){}
    public Product(string name, string idProduct, double value, int quant)
    {
        nome = name;
        id = idProduct;
        valor = value;
        quantidade = quant;
    }

    public void setNome(string name) {nome = name;}

    public void setId(string idProduct) {id = idProduct;}

    public void setValor(double value) {valor = value;}

    public void setQuantidade(int quant) {quantidade = quant;}

    public string getNome() {return nome;}

    public string getId() {return id;}

    public double getValor() {return valor;}

    public int getQuantidade() {return quantidade;}
}