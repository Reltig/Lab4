using Lab4;

//Все перестановки букв a, b, c
var t = Helper.Permute("abc".ToCharArray());
foreach (var l in t)
{
    foreach (var el in l)
    {
        Console.Write($"{el} ");
    }

    Console.WriteLine();
}

//Решение задачи коммивояжора (пример - https://thecode.media/path-js)
var towns = new[,]{
    { 0, 5, 6, 14, 15 },
    { 5, 0, 7, 10, 6 },
    { 6, 7, 0, 8, 7 },
    { 14, 10, 8, 0, 9 },
    { 15, 6, 7, 9, 0 }
};
Console.Write(new CommStruct(towns).Resolve());