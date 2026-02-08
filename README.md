# Taller-Repaso
##taller de repaso - scripting 202601 - Miguel Valencia

Quise hacer los ejercicios con un poquito más de interacción, entonces no me fui tanto por los casos literales de los ejercicios propuestos sino que añadí la opción de que el usuario pueda ingresar las variables con las que iba a trabajar el programa.

1.) Fibonacci

En este se me olvidó añadir la parte de que solo mostrara los primos, pero fue un accidente bastante útil por que me permitió escribir esa lógica de los primos en otro método y en últimas quedó más organizado. Lo único fue cambiar de un for a un while para tener más control sobre la cantidad de primos que iba a mostrar. Otra cosa que pude mejorar despues de acabar fue el for de isPrime(), que lo tenía chequeando hasta el número como tal, pero leí que solo era necesario hasta su raíz cosa q no se me había ocurrido.

```c#
public void FibonacciPrime(int n)
{
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
```
2.) formato hh:mm:ss

Este ya lo habiamos hecho en clase entonces si tenía una idea más concreta de como hacerlo, por lo que realmente no había mucho que hacer acá aparte de repetir la solución que el profe ya le había dado. Se me ocurrieron otras formas de hacer pero realmente ninguna tan compacta y eficiente como esta entonces lo dejé así.

```c#
public void SecondsToFormat(int n)
{
    int horas = n/3600 % 60;
    int minutos = n/60 % 60;
    int segundos = n % 60;

    Console.WriteLine($"{horas}:{minutos}:{segundos}");
}
```
3.) loteria

Yo diría que este es el que más feo me quedó, en el sentido en el que hay orden en unas partes y otras no, pienso que la lógica de chequeo se puede hacer mucho mas compacta sin embargo no se me ocurrió una mejor forma que esta. igual hasta ahora este tiene algo que no tienen los demás y es que chequea los atributos de usuario para evitar que haya errores y q no saque al usuario del programa, apenas terminé de escribir el README voy a añadir eso en los demás pero aquí dejo las versiones sin eso. Otro tema con este fue pasar el número al array, que no tenía ni idea de como hacerlo hasta que recordé que esa es exactamente la misma lógica que el profe usó para el de los segundos. YO SÉ que hay una función en C# que hace literal hace eso pero creo que le escuché al profe decir que debiamos evitar utilizar bibliotecas y tales entonces lo hice así. Tiene un error, bastante grande, y es que si el número tiene un 0 lo ignora, pero no sé como solucionarlo y no lo quiero hacer pq en un caso ideal usaría la función.

```c#
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
```

3.) no sé como ponerle a esta

Este me gustó bastante hacerlo, siento que todo tiene su orden y encima finalmente usar POO es como que garantiza que va a quedar bonito. Leí mal y esa es la razón de la 3ra clase, que lo que hace es intercalar entre mayúsculas y mínusculas, la dejé pq igual es práctica pero no la llamo pues no la instancio en MessageManager. Este no tuvo mayor complicación, más allá de los que invierten el mensaje que tuve un error con los tamaños del array, pero la solución fue añadir un "-1" a cada uno para tener en cuenta el caso en el que i=0.

```c#
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
```
