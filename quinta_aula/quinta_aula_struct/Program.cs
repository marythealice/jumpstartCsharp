using System.Net.WebSockets;

Cliente[] clientes = new Cliente[10];
bool sair = false;
int ultimaPosicao = 0;


return Menu();

int Menu()
{
    do
    {
        Console.WriteLine("Digite a opção desejada:");
        Console.WriteLine("1 - Criar conta");
        Console.WriteLine("2 - Depositar");
        Console.WriteLine("3 - Checar saldo");
        Console.WriteLine("4 - Fazer transferência entre contas Unhacked");
        Console.WriteLine("5 - Sair");
        string operacao = Console.ReadLine();
        if (operacao == "1")
        {
            CadastrarCliente();
        }
        else if (operacao == "2")
        {
            Depositar();
        }
        else if (operacao == "3")
        {
            ChecarSaldo();
        }
        else if (operacao == "4")
        {
            Transferir();
        }
        else if (operacao == "5")
        {
            sair = true;
        }
    } while (sair == false);

    return 0;

}



void CadastrarCliente()
{
    Cliente cliente = new Cliente();
    Console.WriteLine("Informe seu nome completo.");
    cliente.Nome = Console.ReadLine();
    Console.WriteLine("Digite seu cpf");
    cliente.Cpf = Console.ReadLine();
    cliente.numConta = (ultimaPosicao + 1).ToString();
    Console.WriteLine("Insira sua data de nascimento");
    cliente.DataNascimento = DateTime.Parse(Console.ReadLine());
    cliente.dataAberturaConta = DateTime.Now.Date;
    clientes[ultimaPosicao] = cliente;
    ultimaPosicao += 1;
    Console.WriteLine("Deseja fazer um depósito? Ele começa em 50 reais");
    Console.WriteLine("Se sim, digite 1. Caso queira voltar ao menu, digite 2.");
    Console.WriteLine("Mas, se deseja sair, digite 3.");
    string operacao = Console.ReadLine();

    if (operacao == "1")
    {
        Depositar();
    }
    else if (operacao == "2")
    {
        Menu();
    }
    else if (operacao == "3")
    {
        sair = true;
    }


}


void Depositar()
{
    Console.WriteLine("Digite o valor a ser depositado");
    decimal deposito = decimal.Parse(Console.ReadLine());
    clientes[ultimaPosicao - 1].Saldo += deposito;
    Console.WriteLine($"Seu saldo é de {clientes[ultimaPosicao - 1].Saldo}");
    Console.Write("Caso queira voltar ao menu, digite 1. ");
    Console.WriteLine("Mas, se deseja sair, digite 2");
    string operacao = Console.ReadLine();

    if (operacao == "1")
    {
        Menu();
    }
    else if (operacao == "2")
    {
        sair = true;
    }

}

void Transferir()
{
    Console.Write("Digite valor que deseja transferir. Caso seja menor que o seu saldo atual, ");
    Console.WriteLine("a operação será invalidada");
    decimal valorTransferencia = decimal.Parse(Console.ReadLine());
    if (valorTransferencia > clientes[ultimaPosicao - 1].Saldo)
    {
        while (valorTransferencia > clientes[ultimaPosicao - 1].Saldo)
        {
            Console.WriteLine("Valor inválido. Digite um novo valor");
            valorTransferencia = decimal.Parse(Console.ReadLine());
        }
    }
    Console.WriteLine("Agora, digite o cpf da conta para a qual deseja fazer a transferência.");
    string cpfChecagem = Console.ReadLine();
    for (int i = 0; i < ultimaPosicao; i++)
    {
        if (clientes[i].Cpf == cpfChecagem)
        {

            clientes[ultimaPosicao - 1].Saldo -= valorTransferencia;
            clientes[i].Saldo += valorTransferencia;
            Console.WriteLine($"Seu saldo atual é de {clientes[ultimaPosicao - 1].Saldo}");

            /* Console.WriteLine($"{saldo[i]}"); */
        }
    }

}

void ChecarSaldo()
{
    Console.WriteLine("Olá! Digite o cpf da conta que deseja checar o saldo.");
    string cpfChecagem = Console.ReadLine();
    for (int i = 0; i < ultimaPosicao; i++)
    {
        if (clientes[i].Cpf == cpfChecagem)
        {
            Console.WriteLine($"O saldo do cpf digitado é {clientes[i].Saldo}");
        }
    }
}

class Cliente
{
    public string Nome;
    public string numConta;
    public string Cpf;
    public DateTime DataNascimento;
    public decimal Saldo;
    public DateTime dataAberturaConta;
}