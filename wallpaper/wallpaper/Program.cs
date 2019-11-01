using System;
using static System.Math;

namespace wallpaper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const double gravity = -9.8;
            const double v0 = 490;
            double time, v, vx, vy, x, y;

            try
            {
                //input
                INPUT:
                    Console.Write("time is...");
                    time = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("");
                goto INPUT;
            }
            finally
            {
                //solve
                x = v0 * time;
                y = ((double)1 / (double)2) * gravity * Pow(time, 2);
                vx = v0;
                vy = gravity * time;
                v = Sqrt(Pow(vx, 2) + Pow(vy, 2));

                //output
                Console.WriteLine("After {0}second... ", time);
                Console.WriteLine("x = {0}[m]", x);
                Console.WriteLine("y = {0}[m]", y);
                Console.WriteLine("v = {0}[m/s]", v);
            }
        }
    }
}
