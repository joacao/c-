// Screen Sound
using System.ComponentModel.DataAnnotations;

string mensagemBoasVindas = "Boas vindas ao Screen Sound";
//List<string> ListaDasBandas = new List<string>{"U2", "The Beatles", "Calypso"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int>{10,10,8,5});
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
    
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica){
        case 1 : RegistrarBanda();
            break;
        case 2 : MostrarBandasRegistradas();
            break;
        case 3 : AvaliarUmaBanda();
            break;
        case 4 : ExibirMediaBanda();
            break;
        case -1 : Console.WriteLine("Bye bye");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void VerificaExistenciaDaBanda(string banda)
{
    if (bandasRegistradas.ContainsKey(banda))
    {
        Console.WriteLine($"A banda {banda} foi encontrada");
    } else
    {
        Console.WriteLine($"A banda {banda} não foi encontrada");
        Console.Write("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    VerificaExistenciaDaBanda(nomeDaBanda);
    Console.Write("Digite a nota para essa banda: ");
    int notaDaBanda = int.Parse(Console.ReadLine()!);
    bandasRegistradas[nomeDaBanda].Add(notaDaBanda);
    Console.WriteLine($"\nA nota {notaDaBanda} foi registrada com sucesso para a banda {nomeDaBanda}");
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Verificar média das bandas");
    Console.Write("Qual banda deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    VerificaExistenciaDaBanda(nomeDaBanda);

    if (bandasRegistradas[nomeDaBanda].Count == 0)
    {
        Console.WriteLine($"A banda {nomeDaBanda} não possuí avaliações! Você será redirecionado ao menu de escolhas");
        Thread.Sleep(5000);
        ExibirOpcoesDoMenu();
    }

    Console.Write($"A banda {nomeDaBanda} possui média de {bandasRegistradas[nomeDaBanda].Average()}");
    Thread.Sleep(5000);
    Console.Clear();
    ExibirOpcoesDoMenu();

}

ExibirOpcoesDoMenu();
