using System;

namespace MyApp
{
    internal class Program
    {
        #region fibonacci
        public void FibonacciPrime(int n)
        {
            if(n <= 0) return;

            int a = 0;
            int b = 1;
            int i = 0;
            while ( i < n)
            {
                int c = a;
                a = b;
                b = c + b;
                
                if(isPrime(a))
                {
                    
                    Console.WriteLine(a);
                    i++;
               
                }
            }
        }

        public bool isPrime(int n)
        {
            if(n <= 1) return false;
            if(n == 2) return true;
            if(n%2  == 0) return false;
            
            for(int i = 3;  i <= Math.Sqrt(n); i+= 2)
            {
                if(n%i == 0) return false;
                
            }
            return true;
        }
        #endregion 

        #region formato hh:mm:ss

        public void SecondsToFormat(int n)
        {

            if(n<=0) return;

            int hours = n/3600 % 60;
            int minutes = n/60 % 60;
            int seconds = n % 60;

            Console.WriteLine($"{hours}:{minutes}:{seconds}");
        }

        #endregion

        #region loteria
        public int Loteria(int n, int apuesta) //seguramente hay una mejor forma de escribir esto
        {
            if (n < 1000 || n > 9999 || apuesta < 0)
            {
                Console.WriteLine("Ingresa un número válido");
                return 0;
            }     

            //generador
            int[] guess = numberToArray(n);
            Random random = new Random();
            int[] _guess = numberToArray(1234); //numberToArray(random.Next(1000, 10000));

            if (Iguales(guess, _guess))
            {
                Console.WriteLine($"Ganaste {apuesta * 4500}");
                return apuesta * 4500;
            }

            if (guess[3] == _guess[3] && guess[2] == _guess[2] && guess[1] == _guess[1])
            {
                Console.WriteLine($"Ganaste {apuesta * 400}");
                return apuesta * 400;
            }

            if (guess[3] == _guess[3] && guess[2] == _guess[2])
            {
                Console.WriteLine($"Ganaste {apuesta * 50}");
                return apuesta * 50;
            }
            if (guess[3] == _guess[3])
            {
                Console.WriteLine($"Ganaste {apuesta * 5}");
                return apuesta * 5;
            }

            if (MismoDigitos(guess, _guess))
            {
                Console.WriteLine($"Ganaste {apuesta * 200}");
                return apuesta * 200;
            }

            Console.WriteLine("no ganaste :(");
            return 0;
        }

        public int[] numberToArray(int n)
        {
            List<int> digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            int[] digitos = digits.ToArray();
            return digitos.Reverse().ToArray();
        }

        public bool Iguales(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }


            return true;
        }

        public bool MismoDigitos(int[] a, int[] b)
        {
            int[] conteo = new int[10];

            for (int i = 0; i < 4; i++)
            {
                conteo[a[i]]++;
                conteo[b[i]]--;
            }

            for (int i = 0; i < 10; i++)
            {
                if (conteo[i] != 0)
                    return false;
            }

            return true;
        }


        #endregion

        #region no sé como ponerle a esta

        abstract class AbstractSample()
        {
            private string message;

            public abstract void PrintMessage(string message);
            public virtual void InvertMessage(string message)
            {
                char[] chars = message.ToCharArray();
                char[] reversedChars = new char[chars.Length];

                for(int i = 0; i < chars.Length; i++)
                {
                    reversedChars[i] = chars[chars.Length - 1 - i];
                }

                string newMessage = new string(reversedChars);

                Console.WriteLine(newMessage);
            }
        }

        class Class1 : AbstractSample
        {
            public override void PrintMessage(string message)
            {
                Console.WriteLine(message);
            }
        }

        class Class2 : AbstractSample
        {
            public override void PrintMessage(string message)
            {

                char[] chars = message.ToCharArray();
                char[] newChars = new char[chars.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    if (Char.IsLower(chars[i]))
                    {
                        newChars[i] = Char.ToUpper(chars[i]);
                    }
                    else
                    {
                        newChars[i] = Char.ToLower(chars[i]);
                    }
                }

                string newMessage = new string(newChars);

                Console.WriteLine(newMessage);
            }

            public override void InvertMessage(string message)
            {
                char[] chars = message.ToCharArray();
                char[] newChars = new char[chars.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    if (Char.IsLower(chars[chars.Length - 1 - i]))
                    {
                        newChars[i] = Char.ToUpper(chars[chars.Length - 1 - i]);
                    }
                    else
                    {
                        newChars[i] = Char.ToLower(chars[chars.Length - 1 - i]);
                    }
                }

                string newMessage = new string(newChars);
                Console.WriteLine(newMessage);
            }
        }

        class Class3 : AbstractSample //no sé leer perdón
        {
            public override void PrintMessage(string message)
            {

                char[] chars = message.ToCharArray();
                char[] newChars = new char[chars.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    if(i%2 == 0)
                    {
                        newChars[i] = Char.ToUpper(chars[i]);
                    }
                    else
                    {
                        newChars[i] = chars[i];
                    }
                }
            }

            public override void InvertMessage(string message)
            {
                char[] chars = message.ToCharArray();
                char[] newChars = new char[chars.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        newChars[i] = Char.ToUpper(chars[chars.Length - 1 - i]);
                    }
                    else
                    {
                        newChars[i] = chars[chars.Length - 1 - i];
                    }
                }
            }
        }

        public class MessageManager(string message)
        {
            AbstractSample class1 = new Class1();
            AbstractSample class2 = new Class2();
            public void PrintMessage()
            {
                class1.PrintMessage(message);
                class2.PrintMessage(message);
            }
            public void InvertMessage()
            {
                class1.InvertMessage(message);
                class2.InvertMessage(message);
            }
        }

        #endregion

        #region tareita
        public void Tarea()
        {
            string[] palabras = { "juan", "alejandro", "samuel", "sofia" };
            int[] numeros = {-18,422,37,90,43};

            for (int i = 0; i < palabras.Length; i++)
            {
                Console.WriteLine(palabras[i]);
            }

            Console.WriteLine("a que palabra del array quiere acceder?");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta <= palabras.Length && respuesta > 0)
            {
                Console.WriteLine(palabras[respuesta - 1]);
            }

        }
        #endregion


        static void Main(string[] args)
        {
            Program p = new Program();

            bool isOn = true;

            while (isOn)
            {
                Console.WriteLine("\n===== TALLER REPASO =====");
                Console.WriteLine("¿Que ejercicio desea hacer? \n 1.) Fibonacci \n 2.) Segundos a HH:MM::SS \n 3.) Lotería \n 4.) Message Manager");

                int n = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();

                switch (n)
                {
                    case 0:
                        Console.WriteLine("Ingrese un N mayor a 0");
                        n = int.Parse(Console.ReadLine());
                        p.FibonacciPrime(n);
                        break;
                    case 1:
                        Console.WriteLine("Ingrese un N mayor a 0");
                        n = int.Parse(Console.ReadLine());
                        p.SecondsToFormat(n);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese un número de 4 dígitos");
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("INGRESE SU APUESTA");
                        int apuesta = int.Parse(Console.ReadLine());
                        p.Loteria(n, apuesta);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese un mensaje");
                        string m = Console.ReadLine();
                        MessageManager msg = new MessageManager(m);

                        msg.PrintMessage();
                        msg.InvertMessage();

                        break;
                    default: isOn = false; break;
                }   

            }


        }
    }
}