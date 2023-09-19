using Banco.Classes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao Banco !");

        while (true)
        {
            Console.WriteLine("\nEscolha o tipo de conta:");
            Console.WriteLine("1 - Conta Normal");
            Console.WriteLine("2 - Conta Empresa");
            Console.WriteLine("3 - Conta Estudante");
            Console.WriteLine("4 - Sair");

            int escolha = Convert.ToInt32(Console.ReadLine());

            if (escolha == 4)
            {
                Console.WriteLine("Obrigado por utilizar nossos serviços. Adeus!");
                break;
            }

            Console.WriteLine("Digite o número da conta:");
            int numeroConta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o número da agência:");
            int agencia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome do titular da conta:");
            string titularConta = Console.ReadLine();

            switch (escolha)
            {
                case 1:
                    ContaBancaria contaNormal = new ContaBancaria(numeroConta, agencia, titularConta);
                    OperacoesConta(contaNormal);
                    break;
                case 2:
                    Console.WriteLine("Digite a taxa de anuidade:");
                    decimal taxaAnuidade = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Digite o limite de empréstimo:");
                    decimal limiteEmprestimo = Convert.ToDecimal(Console.ReadLine());
                    ContaEmpresa contaEmpresa = new ContaEmpresa(numeroConta, agencia, titularConta, taxaAnuidade, limiteEmprestimo);
                    OperacoesConta(contaEmpresa);
                    break;
                case 3:
                    Console.WriteLine("Digite o limite de cheque especial:");
                    decimal limiteChequeEspecial = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Digite o CPF:");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Digite a instituição de ensino:");
                    string instituicaoEnsino = Console.ReadLine();
                    ContaEstudante contaEstudante = new ContaEstudante(numeroConta, agencia, titularConta, limiteChequeEspecial, cpf, instituicaoEnsino);
                    OperacoesConta(contaEstudante);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void OperacoesConta(ContaBancaria conta)
    {
        while (true)
        {
            Console.WriteLine("\nEscolha a operação:");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Saldo");
            Console.WriteLine("4 - Voltar ao menu principal");

            int operacao = Convert.ToInt32(Console.ReadLine());

            switch (operacao)
            {
                case 1:
                    Console.WriteLine("Digite o valor a ser depositado:");
                    decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());
                    conta.Depositar(valorDeposito);
                    break;
                case 2:
                    Console.WriteLine("Digite o valor a ser sacado:");
                    decimal valorSaque = Convert.ToDecimal(Console.ReadLine());
                    conta.Sacar(valorSaque);
                    break;
                case 3:
                    Console.WriteLine($"Saldo da conta: R$ {conta.Saldo}");
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
    