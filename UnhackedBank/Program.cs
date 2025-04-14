/*
 O Banco UB é pequeno e tem a capacidade de gerenciar apenas 10 Clientes.
 No sistema que vamos construir o Gerente deverá ser capaz de:

  - Abrir Conta
  - Depositar valores
  - Sacar valores
  - Transferir valores entre contas da UB
  - Alterar o Endereço do Cliente
    
*/


using System.Runtime.CompilerServices;
using UnhackedBank;

Agencia AgenciaUB = new Agencia();
bool sair = false;

do
{
  Console.WriteLine("1 - Criar conta. ");
  Console.WriteLine("2 - Depositar. ");
  Console.WriteLine("3 - Fazer transferencia. ");
  Console.WriteLine("4 - Alterar endereco do cliente. ");
  Console.WriteLine("5 - Sair. ");
  var operacao = Console.ReadLine();

  if (operacao == "1")
  {
    CriarConta();
  }

} while (sair == false);

void CriarConta()
{
  Console.WriteLine("Digite seu nome. ");
  string nome = Console.ReadLine();
  Console.WriteLine("Digite seu endereço. ");
  string endereco = Console.ReadLine();
  Console.WriteLine("Digite o numero documento. ");
  string documento = Console.ReadLine();
  Console.WriteLine("Digite o numero da agencia. ");
  string agencia = Console.ReadLine();
  Console.WriteLine("Digite o numero da conta. ");
  string numconta = Console.ReadLine();

  Cliente cliente = new Cliente(nome, endereco, documento);
  Conta contaUnhacked = new Conta(agencia, numconta, cliente);
  var foiAdicionado = AgenciaUB.AdicionarConta(contaUnhacked);
  if (foiAdicionado)
  {
    Console.WriteLine("A conta foi adicionada com sucesso");
  }
  else
  {
    Console.WriteLine("Não pudemos criar a conta - numero maximo de clientes foi atingido. ");
  }
}



