var file = "S:/COM/Human_Resources/01.Engineering_Tech_School/02.Internal/10 - Aprendizes/14 - Desenvolvimento de sistemas 2022/01 - Arquivos a serem disponibilizados/csv-csharp-trevisan/LAB_PR_COV.csv"
    .Open()
    .Skip(1)
    .Take(10);

foreach (var line in file)
{
    Console.WriteLine(line);
}
