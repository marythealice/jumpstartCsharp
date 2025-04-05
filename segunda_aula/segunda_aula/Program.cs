/* Uma empresa precisa receber uma lista de clientes com nome, cpf, valor_assinatura e idade. 
Gerar um relatório com os valores abaixo:
Total de clientes
Valor total de assinaturas
média do valor das assinaturas
maior idade
média da idade
maior valor de assinatura
menor valor de assinatura

*/
char sair = 'c';
uint count_users = 0;
string nome;
string cpf;
float valor_assinatura;
uint idade;

while (sair == 'c')

{
    Console.WriteLine("Entre seu nome ");

    nome = Console.ReadLine();

    count_users += 1;

    Console.WriteLine("Entre seu cpf ");

    cpf = Console.ReadLine();

    Console.WriteLine("Entre seu valor de assinatura ");

    valor_assinatura = float.Parse(Console.ReadLine());

    Console.WriteLine("Entre sua idade ");

    idade = uint.Parse(Console.ReadLine());






    Console.WriteLine("Se deseja sair, digite 's'. Caso contrário, digite 'c'. ");

    sair = Convert.ToChar(Console.ReadLine());



}
