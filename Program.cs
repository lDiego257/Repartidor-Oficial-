using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Repartidor
{
    class Program
    {
        static void Main(string[] args)
        {
            //estructuras de datos
           Queue<string> estudiantes = new Queue<string>();
           Queue<string> temas = new Queue<string>();
           Queue<Grupo> grupos = new Queue<Grupo>();

           //Llenado de estructuras
           LlenarCola(estudiantes, args[0]);
           LlenarCola(temas, args[1]);
           for (int i = 0; i < int.Parse(args[2]); i++)
           {
               Grupo g1 = new Grupo();
               g1.Id = 1 + i;
               grupos.Enqueue(g1);
           }

           //repartidor
           string x=EsPosible(estudiantes.Count, temas.Count, grupos.Count);
           if(x=="s")
           {
               //Asignar estudiantes
               grupos = Shuffle(grupos);
               while(estudiantes.Count != 0)
               {
                   foreach (var item in grupos)
                   {
                       if(estudiantes.Count != 0){
                       string s = estudiantes.Dequeue();
                       item.Estudiantes.Enqueue(s);
                       }
                   }
               }
               //Asignar temas
                grupos = Shuffle(grupos);
               while(temas.Count != 0)
               {
                   foreach (var item in grupos)
                   {
                       if(temas.Count !=0){
                       string s = temas.Dequeue();
                       item.Temas.Enqueue(s);
                       }
                    
                   }
               }
               grupos = new Queue<Grupo>(grupos.OrderBy(x=> x.Id));
                //mostrar datos
                foreach (var item in grupos)
                {
                    int i = 0;
                    Console.WriteLine($"Grupo {item.Id}, integrantes({item.Estudiantes.Count}): ");
                    foreach (var est in item.Estudiantes)
                    {
                        i++;
                        Console.WriteLine($"{i}. {est}");
                    }
                    foreach (var tem in item.Temas)
                    {
                        Console.Write($"{tem}|");
                    }
                    Console.WriteLine("\n----------------------------------------------\n");
                }
           }
           else
           Console.WriteLine(x);
        }

        public static void LlenarCola(Queue<string> cola, string direccion)
        {
            using(StreamReader SR = new StreamReader(direccion)){
                string line;
                while((line = SR.ReadLine())!= null)
                {
                    cola.Enqueue(line);
                }
            }
        }
        public static string EsPosible(int estudiantes, int temas, int grupos){
            if(grupos > estudiantes)
            return "ERROR, Hay mas grupos que estudiantes";
            if (grupos > temas)
            return "ERROR, Hay mas grupos que temas";
            return "s";
        }
        public static Queue<T> Shuffle<T>(Queue<T> Cola)
        {
            var rnd = new Random();
            return new Queue<T>(Cola.OrderBy(x => rnd.Next()));
        }
    }
}
