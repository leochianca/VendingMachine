using static System.Console;

namespace ProjetoOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while(true)
            {
                menu.ExibirMenu();
                int opcao = int.Parse(ReadLine());
                bool invalid = false;

                Clear();

                switch(opcao)
                {
                    case 0: invalid = true;
                            break;
                    
                    case 1: menu.ExibirMenu1();
                            break;

                    case 2: menu.ExibirMenu2();
                            break;

                    case 3: menu.ExibirMenu3();
                            break;

                    default: WriteLine("Opção inválida!\nVolte ao Menu e tente novamente\n");
                             break;
                }

                if(invalid) return;
                
                menu.VoltarMenu();
            }
        }
    }
}
