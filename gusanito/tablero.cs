using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gusanito
{
    internal class tablero
    {
        public List<(int x, int y, int value)> Posicion { get; set; }
        public int puntuacion { get; set; }
        public tablero()
        {
            Posicion = new List<(int x, int y, int value)>();
            puntuacion = 0;
        }
        public void GenerarComida()
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(1, Console.WindowWidth);
                y = random.Next(1, Console.WindowHeight);
            }
            while (Posicion.Any(p => p.x == x && p.y == y && p.value != 0));
            Posicion.Add((x, y, 1));
        }
        public bool VerificarColision(laCulebrita laCulebrita)
        {
            int ancho = Console.WindowWidth;
            int alto = Console.WindowHeight;
            //pared
            (int x, int y) Cabeza = laCulebrita.Cuerpo[0];
            if (Cabeza.x == 0 || Cabeza.x== ancho || Cabeza.y==0||Cabeza.y==alto-1)
            {
                return true;
            }
            //consigo mismo
            for(int i=1;i < laCulebrita.Cuerpo.Count; i++)
            {
                if (Cabeza.x == laCulebrita.Cuerpo[i].x && Cabeza.y == laCulebrita.Cuerpo[i].y)
                {
                    return true;
                }
            }
            return false;
               
        }
        public void Dibujar(laCulebrita laCulebrita)
        {
            int index = 0;
            foreach((int x, int y)in laCulebrita.Cuerpo)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                if (index == 0)
                {
                    Console.Write("0");
                }
                else
                {
                    Console.Write("-");
                }
                index++;
                Console.ResetColor();
            }
            foreach ((int x, int y,int value) in Posicion)
            {
                if (value == 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+");
                    Console.ResetColor();
                }
 
            }
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, Console.WindowHeight-1);
                Console.Write("_");
            }
            Console.SetCursorPosition(1, Console.WindowHeight);
            Console.Write("Score: "+puntuacion);
        }

    }
}
