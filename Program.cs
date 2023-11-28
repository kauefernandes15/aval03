using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string textoCifrado = "Lu0s z q0tm0uƒ€q~x ƒ40t ‚uy~t (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm † (u}0†é‚yqƒ(s ‚u{0u0„i}q~xwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz ~qƒ(q0uƒ|‚q~xwƒPSqz‚ ƒ0wƒƒ 0lyŠu~l 0ƒyuP_0ƒq~q|0o‚y„qvt 0~ë PTu~u0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Y~ykyq|PZuƒƒ…z‚uy÷ë";
        string textoDecifrado = DecifrarDeTeusPulos(textoCifrado);
        textoDecifrado = textoDecifrado.Replace("@", "\n");
        string[] palindromos = EncontrarPalindromos(textoDecifrado);
        foreach (var palavra in palindromos)
        {
            textoDecifrado = SubstituirPalindromo(textoDecifrado, palavra);
        }
        Console.WriteLine("Texto cifrado:");
        Console.WriteLine(textoCifrado);

        Console.WriteLine("\npalindromos:");
        foreach (var palavra in palindromos)
        {
            Console.WriteLine(palavra);
        }
        Console.WriteLine($"\nNmero de caracteres: {textoDecifrado.Length}");
        string[] palavras = textoDecifrado.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Numero de palavras: {palavras.Length}");
        Console.WriteLine("\nTexto decifrado maiusculo:");
        Console.WriteLine(textoDecifrado.ToUpper());
    }

    static string DecifrarDeTeusPulos(string textoCifrado)
    {
        StringBuilder textoDecifrado = new StringBuilder();
        int[] chave = { 16, 16, 16, 16, 8 };
        for (int i = 0; i < textoCifrado.Length; i++)
        {
            int indiceChave = i % chave.Length;
            int valorChave = chave[indiceChave];
            char caractereDecifrado = DecifrarCaractere(textoCifrado[i], valorChave);
            textoDecifrado.Append(caractereDecifrado);
        }

        return textoDecifrado.ToString();
    }

    static char DecifrarCaractere(char caractereCifrado, int chave)
    {
        int codigoASCII = caractereCifrado - chave;
        char caractereDecifrado = (char)codigoASCII;
        return caractereDecifrado;
    }

    static string[] EncontrarPalindromos(string texto)
    {
        string[] palavras = texto.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var palindromos = palavras.Where(palavra => IsPalindromo(palavra)).ToArray();
        return palindromos;
    }
    static bool IsPalindromo(string palavra)
    { string limpa = new string(palavra.ToLower().Where(c => Char.IsLetterOrDigit(c)).ToArray());
        return limpa == new string(limpa.Reverse().ToArray()); }
    static string SubstituirPalindromo(string texto, string palindromo)
    {
        int indice = texto.IndexOf(palindromo);
        if (indice != -1)
        {
            texto = texto.Remove(indice, palindromo.Length);
            texto = texto.Insert(indice, palindromo);
        }

        return texto;            //kaue varela fernandes
    }
}
