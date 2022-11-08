public static class MyExtensionMethods
{
    public static IEnumerable<string> Open(this string arq)
    {
        var stream = new StreamReader(arq); // Criando o streamreader
        while (!stream.EndOfStream) // Lendo até o fim do arquivo
        {
            var line = stream.ReadLine(); // Lendo uma linha por vez
            yield return line; // retornando uma linha por vez, para conseguirmos processar.
        }
        stream.Close(); // Fechando o arquivo
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++) ; // MoveNext a quantidade de elementos N
        
        while(it.MoveNext())
            yield return it.Current;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();

        for (int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
        
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            list.Add(it.Current);
        
        return list;
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return it.Current;
        yield return item;
    }

    public static T? LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count ++;
        
        return count == 0 ? default(T) : it.Current;
    }
}