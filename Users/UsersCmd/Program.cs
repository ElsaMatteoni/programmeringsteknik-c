using System;

namespace Users.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // Med testdriven utvecklingsmetodik.
            // Skriv ett program som:
            // 1. Loggar in en användare.
            // 2. Om användaren inte existerar, registrerar användaren via inmatning och 
            //    låter användaren ange in ett lösenord,
            //    alt. genererar ett lösenord.
            // 3. Direkt efter ny användare registrerats, skall användaren kunna logga in (inloggning får ej ske automatiskt).
            // 4. Om lösenord lagras i fil får detta ej ske i klartext.

            // Tilläggsvis är detta ett grovt förenklat sätt att jobba med användare.
            // Det är inte representativt för verkligheten, men innehåller delar som är jämförbara.

            // I verkligheten gäller:
            // Lösenord måste krypteras och får ej lagras i fritextform.
            // Lösenord får inte visas på skärm.
            // Lösenord har vanligtvis löjliga/svåra lösenordsregelkrav pga brute force-algoritmer.
            // Normalt skickar man en epost med länk till användaren som registrerats.
            // Användaren får efter klick på verifieringslänk ange ett lösenord i en maskad inmatning.
        }
    }
}
