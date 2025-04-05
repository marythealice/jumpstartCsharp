/* criar um programa que cadastra até 10 clientes e recebe:
    - Nome
    - CPF
    - Data de Nascimento
    - Data Abertura da Conta
    - Conta é criada (número da conta gerado automaticamente)

 - Na aberturada conta, o cliente que depositar um valor, o mesmo será adicionado ao saldo da conta
   - Valor Mínimo de depósito: R$ 50,00
 
 - Funcionalidade de Transferência
   - O cliente pode transferir valores entre contas

- Não preciso cadastrar todos os clientes de uma só vez

  Menu
   - Abrir Conta (Cadastro do Cliente)
   - Depositar
   - Transferência
   - listar saldo com cpf
   - Sair
*/

using System.Runtime.Serialization;
using System.Timers;

string[] cliente = new string[10];
string[] n_conta = new string[10];
string[] cpf = new string[10];
DateTime[] data_nascimento = new DateTime[10];
DateTime[] data_abertura_conta = new DateTime[10];
decimal[] saldo = new decimal[10];
bool sair = false;
int ultima_posicao = 0;

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
  Console.WriteLine("Informe seu nome completo.");
  cliente[ultima_posicao] = Console.ReadLine();
  Console.WriteLine("Digite seu cpf");
  cpf[ultima_posicao] = Console.ReadLine();
  n_conta[ultima_posicao] = (ultima_posicao + 1).ToString();
  Console.WriteLine("Insira sua data de nascimento");
  data_nascimento[ultima_posicao] = DateTime.Parse(Console.ReadLine());
  data_abertura_conta[ultima_posicao] = DateTime.Now.Date;
  ultima_posicao += 1;
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
  saldo[ultima_posicao] += deposito;
  Console.WriteLine($"Seu saldo é de {saldo[ultima_posicao]}");
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
  decimal valor_transferencia = decimal.Parse(Console.ReadLine());
  if (valor_transferencia > saldo[ultima_posicao])
  {
    while (valor_transferencia > saldo[ultima_posicao])
    {
      Console.WriteLine("Valor inválido. Digite um novo valor");
      valor_transferencia = decimal.Parse(Console.ReadLine());
    }
  }
  Console.WriteLine("Agora, digite o cpf da conta para a qual deseja fazer a transferência.");
  string cpf_checagem = Console.ReadLine();
  for (int i = 0; i < 10; i++)
  {
    if (cpf[i] == cpf_checagem)
    {
      saldo[ultima_posicao] -= valor_transferencia;
      saldo[i] += valor_transferencia;
      Console.WriteLine($"{saldo[i]}");
    }
  }


}

void ChecarSaldo()
{
  Console.WriteLine("Olá! Digite o cpf da conta que deseja checar o saldo.");
  string cpf_checagem = Console.ReadLine();
  for (int i = 0; i < 10; i++)
  {
    if (cpf[i] == cpf_checagem)
    {
      Console.WriteLine($"O saldo do cpf digitado é {saldo[i]}");
    }
  }
}