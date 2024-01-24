using System;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.Write("Digite o tamanho da memória a ser alocada (em bytes): ");
        int tamanhoMemoria;

        while (!int.TryParse(Console.ReadLine(), out tamanhoMemoria) || tamanhoMemoria <= 0)
        {
            Console.WriteLine("Por favor, digite um número válido e positivo.");
            Console.Write("Digite o tamanho da memória a ser alocada (em bytes): ");
        }

        // Alocando espaço na memória
        IntPtr ponteiro = Marshal.AllocHGlobal(tamanhoMemoria);

        Console.WriteLine($"Memória alocada com sucesso! Endereço: 0x{ponteiro.ToInt64():X}");

        // Criando e salvando dados simulados
        byte[] dados = { 65, 66, 67, 68, 69 }; // ASCII para 'ABCDE'
        Marshal.Copy(dados, 0, ponteiro, dados.Length);

        Console.WriteLine("Dados salvos na memória.");

        // Lendo dados da memória
        byte[] dadosLidos = new byte[dados.Length];
        Marshal.Copy(ponteiro, dadosLidos, 0, dadosLidos.Length);

        Console.Write("Dados lidos da memória: ");
        foreach (byte b in dadosLidos)
        {
            Console.Write((char)b);
        }
        Console.WriteLine();

        // Liberando a memória
        Marshal.FreeHGlobal(ponteiro);

        Console.WriteLine("Memória liberada. Até a próxima aventura!");
    }
}
