using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Classes
{
    internal class Conta
    {
        public class ContaBancariaa
        {
            public int NumeroConta { get; set; }
            public int Agencia { get; set; }
            public string TitularConta { get; set; }
            public decimal SaldoConta { get; set; }

            public ContaBancariaa(int numeroConta, int agencia, string titularConta)
            {
                NumeroConta = numeroConta;
                Agencia = agencia;
                TitularConta = titularConta;
                SaldoConta = 0;
            }

            public virtual void Depositar(decimal valor)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor} realizado com sucesso. Novo saldo: R$ {Saldo}");
            }

            public virtual void Sacar(decimal valor)
            {
                if (Saldo >= valor)
                {
                    Saldo -= valor;
                    Console.WriteLine($"Saque de R$ {valor} realizado com sucesso. Novo saldo: R$ {Saldo}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para saque.");
                }
            }
        }
    }
}
