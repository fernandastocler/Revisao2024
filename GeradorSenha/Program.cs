// See https://aka.ms/new-console-template for more information
Console.WriteLine("GeradorSenhas!");

using System;
using System.IO;
using System.Text;

class GeradorDeSenhas
{
    // Função para gerar senha
    static string GerarSenha(int tamanho, string tipo)
    {
        string caracteres = "0123456789"; // Apenas números

        if (tipo == "letras")
        {
            caracteres += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Números + Letras
        }
        else if (tipo == "especiais")
        {
            caracteres += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()-_=+[]{}|;:',.<>?/"; // Números + Letras + Caracteres especiais
        }

        Random random = new Random();
        StringBuilder senha = new StringBuilder();
        for (int i = 0; i < tamanho; i++)
        {
            senha.Append(caracteres[random.Next(caracteres.Length)]);
        }

        return senha.ToString();
    }

    // Função para salvar a senha no arquivo de backup
    static void SalvarBackup(string senha)
    {
        string caminhoArquivo = "bkp.txt";
        File.AppendAllText(caminhoArquivo, senha + Environment.NewLine);
    }

    // Função para recuperar senhas do backup
    static void RecuperarBackup()
    {
        string caminhoArquivo = "bkp.txt";

        if (File.Exists(caminhoArquivo))
        {
            string[] senhas = File.ReadAllLines(caminhoArquivo);
            Console.WriteLine("\nSenhas Salvas:");
            foreach (var senha in senhas)
            {
                Console.WriteLine(senha);
            }
        }
        else
        {
            Console.WriteLine("Nenhuma senha salva no backup.");
        }
    }

    // Função principal
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=======================");
            Console.WriteLine("Gerador de Senhas");
            Console.WriteLine("=======================");
            Console.WriteLine("1. Gerar Senha");
            Console.WriteLine("2. Salvar Senha em Backup");
            Console.WriteLine("3. Recuperar Senhas Salvas");
            Console.WriteLine("4. Sair");
            Console.WriteLine("=======================");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Write("Digite o tamanho da senha: ");
                int tamanho = int.Parse(Console.ReadLine());

                Console.Write("Digite o tipo de senha (numeros, letras, especiais): ");
                string tipo = Console.ReadLine().ToLower();

                string senha = GerarSenha(tamanho, tipo);
                Console.WriteLine($"Senha Gerada: {senha}");
            }
            else if (opcao == "2")
            {
                Console.Write("Deseja salvar a senha atual em backup? (s/n): ");
                string salvar = Console.ReadLine().ToLower();

                if (salvar == "s")
                {
                    Console.WriteLine("Senha salva no backup.");
                    SalvarBackup(senha);
                }
                else
                {
                    Console.WriteLine("Nenhuma senha foi salva.");
                }
            }
            else if (opcao == "3")
            {
                RecuperarBackup();
            }
            else if (opcao == "4")
            {
                Console.WriteLine("Saindo...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente.");
            }
        }
    }
}
