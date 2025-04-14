using System;
using System.Diagnostics.Tracing;
using System.Dynamic;

namespace UnhackedBank;

public class Conta
{
    public string Agencia { get; }
    public string NumConta { get; }
    public decimal Saldo { get; private set; }

    public Cliente Cliente { get; set; }

    // construtor setando valores ao instanciar Conta
    public Conta(string agencia, string numconta, Cliente cliente)
    {
        Agencia = agencia;
        NumConta = numconta;
        Cliente = cliente;
    }

}

public class Agencia
{
    private List<Conta> _contas = new List<Conta>();
    private const int numContaMaxima = 10;

    public bool AdicionarConta(Conta conta)
    {
        if (_contas.Count < 10)
        {
            _contas.Add(conta);
            return true;
        }
        return false;
    }

}

public class Cliente
{
    public string Nome { get; }
    public string Endereco { get; }
    public string Documento { get; }

    public Cliente(string nome, string endereco, string documento)
    {
        Nome = nome;
        Endereco = endereco;
        Documento = documento;
    }
}