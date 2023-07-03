namespace gusanito;
class Program
{
    static void Main(string[] args)
    {
        tablero tablero = new tablero();
        laCulebrita laCulebrita = new laCulebrita();
        Console.Title = "Jueguito";
        Console.CursorVisible = false;
        tablero.GenerarComida();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        laCulebrita.Dirrecion = laCulebrita.Direction.Up;
                        break;
                    case ConsoleKey.S:
                        laCulebrita.Dirrecion = laCulebrita.Direction.Down;
                        break;
                    case ConsoleKey.D:
                        laCulebrita.Dirrecion = laCulebrita.Direction.Right;
                        break;
                    case ConsoleKey.A:
                        laCulebrita.Dirrecion = laCulebrita.Direction.Left;
                        break;
                }
            }
            laCulebrita.Mover();
            if (tablero.VerificarColision(laCulebrita))
            {
                Console.Clear();
                Console.Write("Perdiste PT");
                break;
            }
            if (tablero.Posicion.Any(p => p.x == laCulebrita.Cuerpo[0].x&&p.y== laCulebrita.Cuerpo[0].y && p.value==1))
            {
                tablero.Posicion.RemoveAll(p => p.x == laCulebrita.Cuerpo[0].x && p.y == laCulebrita.Cuerpo[0].y && p.value == 1);
                laCulebrita.Crecer();
                tablero.puntuacion += 1;
                tablero.GenerarComida();
            }
            tablero.Dibujar(laCulebrita);
            Thread.Sleep(100);
        }
    }
}