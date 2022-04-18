using System;
//solo se pueden insertar 7 carros en cada tanda, y cada insert es equivalente a un minuto
namespace TrabajoFinalParqueos
{
    class Program
    {
        public static void resta (int[,] a)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 1 || j == 3)
                    {
                        if (a[i, j] == 0)
                        {
                            if (i == 2 && j == 4)
                            {
                                continue;
                            }
                            Console.Write(a[i, j] + "   ");
                        }
                        else
                        {
                            if (i == 2 && j == 4)
                            {
                                continue;
                            }
                            a[i, j]--;
                            Console.Write(a[i, j] + "   ");
                        }
                    }
                    else
                    {
                        if (a[i, j] == 0)
                        {
                            if (i == 2 && j == 4)
                            {
                                continue;
                            }
                            Console.Write(a[i, j] + " ");
                        }
                        else
                        {
                            if (i == 2 && j == 4)
                            {
                                continue;
                            }
                            a[i, j]--;
                            Console.Write(a[i, j] + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public static int suma (int[,] arreglo)
        {
            int sumar = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 4)
                    {
                        continue;
                    }
                    sumar += arreglo[i, j];
                }
            }
            return sumar;
        }

        public static void Print (int[,] arr)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 4)
                    {
                        continue;
                    }

                    if (j == 1 || j == 3) // las primeras dos columnas los carros que se quedan 3min, las otras dos 2min, y la ultima columna 1min.
                    {                        
                        Console.Write(arr[i, j] + "   ");
                    }
                    else
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        
        public static void Llenar(int[,] arr)
        {
            Random aleatorio = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int aux = aleatorio.Next(0, 2);

                    if (j == 4 && i != 2)
                    {
                        if (aux == 1)
                        {
                            arr[i, j] = 2;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                    }
                    else if (j == 3 || j == 2) 
                    {
                        if (aux == 1)
                        {
                            arr[i, j] = 3;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                    }else if(j == 0 || j == 1) 
                    {
                        if (aux == 1)
                        {
                            arr[i, j] = 4;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                    }
                }                    
            }

        }
    
        public static int Insertar(int n, int[,] ar)
        {       
            if(n==2)
            {               
                for (int i = 0; i < 5; i++)
                {
                    if(ar[i, 4] == 0)
                    {
                        ar[i, 4]  =  2;
                        return ar[i, 4];
                    }
                }
            }            
            else if(n == 3)
            {
                for(int i = 0; i < 5; i++)
                {
                    for(int j = 2; j < 4; j++)
                    {
                        if(ar[i,j]==0)
                        {
                            ar[i,  j]  =  3;
                            return ar[i,j];
                        }                   
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ar[i, j] == 0)
                        {
                            ar[i, j] = 4;
                            return ar[i, j];
                        }
                    }
                }
            }
            return 0;
        }
    
        static void Main(string[] args)
        {
            int tanda = 7, ii = 0, flujo = 0, flujot = 0;
        
            int [,]arr = new int[5, 5];
            int[] m = new int[7];
            int[] t = new int[7];
            int[] n = new int[7];
            
            Console.WriteLine("* * * *Tanda de la Madrugada* * * * ");
            Llenar(arr);
            Print(arr);
            flujot = suma(arr);

            while (tanda != 0) //solo entraran 7 carros por tanda (mañana, tarde y noche)
            {
                Console.WriteLine("\nCuantos minutos se va a quedar: (Solo carros que se queden 4, 3 o 2 minutos en este parqueo)");
                int time = int.Parse(Console.ReadLine());
                Console.WriteLine();

                m[ii] = time; 
                Insertar(time, arr);
                Print(arr);
                Console.WriteLine("\nYa ha pasado un minuto:");
                m[ii] = time; 
                resta(arr);

                tanda--;
                ii++;
            }
            for (int i = 0; i < m.Length; i++)
            {
                flujo += m[i];
            }            
            flujo += flujot;
            Console.WriteLine("Tiempo trabajado: " + flujo + " mins\n");

            tanda = 7;
            ii = 0;
            flujo = 0;
            flujot = 0;
            Console.WriteLine("* * * *Tanda de la Tarde* * * * ");
            Llenar(arr);
            Print(arr);
            flujot = suma(arr);

            while (tanda != 0) //solo entraran 7 carros por tanda (mañana, tarde y noche)
            {
                Console.WriteLine("\nCuantos minutos se va a quedar: (Solo carros que se queden 4, 3 o 2 minutos en este parqueo)");
                int time = int.Parse(Console.ReadLine());
                Console.WriteLine();

                t[ii] = time; 
                Insertar(time, arr);
                Print(arr);
                Console.WriteLine("\nYa ha pasado un minuto:");
                t[ii] = time; 
                resta(arr);

                tanda--;
                ii++;
            }
            for (int i = 0; i < m.Length; i++)
            {
                flujo += t[i];
            }
            flujo += flujot;
            Console.WriteLine("Tiempo trabajado: " + flujo + " mins\n");

            tanda = 7;
            ii = 0;
            flujo = 0;
            flujot = 0;
            Console.WriteLine("* * * *Tanda de la Noche* * * * ");
            Llenar(arr);
            Print(arr);
            flujot = suma(arr);

            while (tanda != 0) //solo entraran 7 carros por tanda (mañana, tarde y noche)
            {
                Console.WriteLine("\nCuantos minutos se va a quedar: (Solo carros que se queden 4, 3 o 2 minutos en este parqueo)");
                int time = int.Parse(Console.ReadLine());
                Console.WriteLine();

                n[ii] = time; 
                Insertar(time, arr);
                Print(arr);
                Console.WriteLine("\nYa ha pasado un minuto:");
                n[ii] = time; 
                resta(arr);

                tanda--;
                ii++;
            }
            for (int i = 0; i < m.Length; i++)
            {
                flujo += n[i];
            }
            flujo += flujot;
            Console.WriteLine("Tiempo trabajado: " + flujo + " mins\n");
        }
    }
}
