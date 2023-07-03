using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gusanito
{
    internal class laCulebrita
    {
        //posicion de la culebra
        public List<(int x, int y)> Cuerpo { get; set; } = new List<(int x, int y)>();
        //dirrecion de la culebra
        public Direction Dirrecion { get; set; }
        public int Crecimiento { get; set; }

        public laCulebrita()
        {
            //posicion inical de la culebra
            Dirrecion = Direction.Right;
            Crecimiento = 0;
            Cuerpo.Add((Console.WindowWidth / 2, Console.WindowHeight / 2));
        }
        public void Mover()
        {
            (int x, int y) Cabeza = Cuerpo[0];
            switch (Dirrecion)
            {
                case Direction.Up:
                    Cabeza.y--;
                    break;

                case Direction.Down:
                    Cabeza.y++;
                    break;

                case Direction.Left:
                    Cabeza.x--;
                    break;
                case Direction.Right:
                    Cabeza.x++;
                    break;
            }

            Cuerpo.Insert(0, Cabeza);
            int Cuenta = Cuerpo.Count;
            Console.SetCursorPosition(Cuerpo[Cuenta - 1].x, Cuerpo[Cuenta - 1].y);
            Console.Write(" ");
            if (Crecimiento == 0)
            {
                Cuerpo.RemoveAt(Cuenta-1);
            }
            else
            {
                Crecimiento--;
            }
        } 

        public void Crecer()
        {
            Crecimiento++;
            (int x, int y) Cola = Cuerpo[Cuerpo.Count - 1];
            Cuerpo.Add(Cola);
        }
        public enum Direction
        {
            Up,//arriba
            Down,//abajo
            Left,//izquierda
            Right,//derecha
        }
    }
}
