using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Classes
{

    using System;

    public class ContaBancaria
    {
        public int NumeroConta { get; set; }
        public int Agencia { get; set; }
        public string TitularConta { get; set; }
        public decimal Saldo { get; set; }

        public ContaBancaria(int numeroConta, int agencia, string titularConta)
        {
            NumeroConta = numeroConta;
            Agencia = agencia;
            TitularConta = titularConta;
            Saldo = 0;
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

    public class ContaEmpresa : ContaBancaria
    {
        public decimal TaxaAnuidade { get; set; }
        public decimal LimiteEmprestimo { get; set; }
        public decimal TotalEmprestimo { get; set; }

        public ContaEmpresa(int numeroConta, int agencia, string titularConta, decimal taxaAnuidade, decimal limiteEmprestimo)
            : base(numeroConta, agencia, titularConta)
        {
            TaxaAnuidade = taxaAnuidade;
            LimiteEmprestimo = limiteEmprestimo;
            TotalEmprestimo = 0;
        }

        public void RealizarEmprestimo(decimal valor)
        {
            try
            {
                if (valor <= LimiteEmprestimo)
                {
                    Saldo += valor;
                    TotalEmprestimo += valor;
                    Console.WriteLine($"Empréstimo de R$ {valor} realizado com sucesso. Novo saldo: R$ {Saldo}");
                }
                else
                {
                    throw new Exception("Empréstimo não pode ser concedido devido ao limite excedido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public override void Sacar(decimal valor)
        {
            try
            {
                if (valor <= 5000)
                {
                    base.Sacar(valor);
                }
                else
                {
                    decimal taxaSaque = 5;
                    if (Saldo >= valor + taxaSaque)
                    {
                        Saldo -= valor + taxaSaque;
                        Console.WriteLine($"Saque de R$ {valor} realizado com sucesso. Taxa de saque de R$ {taxaSaque} aplicada. Novo saldo: R$ {Saldo}");
                    }
                    else
                    {
                        throw new Exception("Saldo insuficiente para saque com taxa.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }

    public class ContaEstudantee : ContaBancaria
    {
        public decimal LimiteChequeEspecial { get; set; }
        public string CPF { get; set; }

        public int numeroConta { get; set; }
        public int agencia { get; set; }
        string titularConta { get; set; }

        public string InstituicaoEnsino { get; set; }

        public ContaEstudantee(int numeroConta, int agencia, string titularConta, decimal limiteChequeEspecial, string cpf, string instituicaoEnsino)
            : base(numeroConta, agencia, titularConta)
        {
            titularConta = titularConta;
            agencia = agencia;
            titularConta = titularConta;
            LimiteChequeEspecial = limiteChequeEspecial;
            CPF = cpf;
            InstituicaoEnsino = instituicaoEnsino;
        }

        public void Sacar(decimal valor)
        {
            try
            {
                if (Saldo + LimiteChequeEspecial >= valor)
                {
                    Saldo -= valor;
                    Console.WriteLine($"Saque de R$ {valor} realizado com sucesso. Novo saldo: R$ {Saldo}");
                }
                else
                {
                    throw new Exception("Limite de cheque especial excedido. Saldo insuficiente para saque.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }

  