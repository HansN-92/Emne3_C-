
namespace moodle1
{
    internal class Program
    {
        //  private int test = 1;           //  integer lagrer heltall
        //  private long test1 = 2;         //  samme som int men høyere kapasitet
        //  private float test3 = 3F;       //  komma med en eller fler desimaltall, lavere memory og presisjon. 32-bit. bruk F etter tall ellerså blir double auto assigned. float er anbefalt for spill og store mengder data
        //  private decimal test4 = 4;      //  komma med en eller fler desimaltall, veldig høy presisjon, ofte brukt for penger og avansert matte. 128-bit
        //  private double test5 = 5;       //  komma med en eller fler desimaltall, høy presisjon, mer krevende. 64-bit
        //  private string test6 = "6";     //  tekst, bruker ""
        //  private char test7 = '7';       //  en bokstav eller tall, bruker ''
        //  private bool test8 = true;      //  boolean true; || false;

        // int a = 5;
        // decimal b = 3;
        // decimal sum = a + b;             // når man legger sammen variabler vil alltid den mest presise måtte brukes i sum


        int number = 5;
        int number2 = 10;
        private bool isEqual;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            
        }
        public void Run()
        {
            while (!isEqual)
            {

                if (number == number2)
                {
                    isEqual = true;
                    Console.WriteLine("Numbers are equal");
                }
                else
                {
                    isEqual = false;
                    Console.WriteLine("Numbers are not equal");
                }

                if (isEqual)
                {
                    Console.WriteLine($"{isEqual}");
                }
                else
                {
                    number++;
                    Console.WriteLine("number = " + number);
                    Console.WriteLine("number2 = " + number2);
                }
            }
        }
    }
}
