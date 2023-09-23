using System.Collections;
using EFTeste.Models;

int opcao;

do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1) Inserir");
    Console.WriteLine("2) Alterar");
    Console.WriteLine("3) Excluir");
    Console.WriteLine("4) Consultar");
    Console.WriteLine("0) Sair");
    Console.Write("Opção: ");
    opcao = Convert.ToInt32(Console.ReadLine());

    switch(opcao)
    {
        case 0: break;
        case 1: Inserir(); break;
        case 2: Alterar(); break;
        case 3: Excluir(); break;
        case 4: Consultar(); break;
        default: Console.WriteLine("Opção inválida!"); break;
    }

} while (opcao != 0);

void Inserir()
{
    var obj = new Aluno { Id = Guid.NewGuid().ToString() };

    Console.WriteLine("Novo aluno:");
    
    Console.Write("  Matrícula: ");
    obj.Matricula = Convert.ToInt32(Console.ReadLine());

    Console.Write("  Nome: ");
    obj.Nome = Console.ReadLine() ?? "";

    var db = new ModelContext();
    db.Alunos.Add(obj);
    db.SaveChanges();
}

void Alterar()
{
    Console.Write("Matrícula do aluno a ser alterado: ");
    var matricula = Convert.ToInt32(Console.ReadLine());

    var db = new ModelContext();

    var obj = db.Alunos.FirstOrDefault(x => x.Matricula == matricula);

    if (obj == null)
    {
        Console.WriteLine("Aluno não encontrado.");
        return;
    }

    Console.Write("  Novo Nome: ");
    obj.Nome = Console.ReadLine() ?? "";

    db.Alunos.Update(obj);
    db.SaveChanges();
}

void Excluir()
{
    Console.Write("Matrícula do aluno a ser excluído(a): ");
    var matricula = Convert.ToInt32(Console.ReadLine());

    var db = new ModelContext();

    var obj = db.Alunos.FirstOrDefault(x => x.Matricula == matricula);

    if (obj == null)
    {
        Console.WriteLine("Aluno não encontrado.");
        return;
    }

    db.Alunos.Remove(obj);
    db.SaveChanges();
}

void Consultar()
{
    var db = new ModelContext();
    
    var objetos = db.Alunos;

    Console.WriteLine("Lista de Alunos:");

    foreach (var obj in objetos)
        Console.WriteLine($"  {obj.Matricula} - {obj.Nome}");

    Console.WriteLine();
}