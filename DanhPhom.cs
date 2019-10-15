using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhPhom
{
    class Program
    {
        static void Main()
        {
            {
                //----------------------mảng mà người muốn đc chọn ưu tiên---------------//
                int[,] PlayerWin = new int[13, 4];

                //--------------mảng bài người cần hiến cho người ưu tiên ---------------//
                int[,] PlayerLost = new int[13, 4];

                Nhap(PlayerWin, 13, 4);
                Console.WriteLine("-----");
                Nhap(PlayerLost, 13, 4);
                Console.WriteLine("---PlayerLost--");
                Xuat(PlayerLost, 13, 4);
                Console.WriteLine("---PlayerWin--");
                Xuat(PlayerWin, 13, 4);

                //------------------------------------------//

                for (int j = 0; j < 4; j++)
                {
                    for (int i = 12; i >= 0; i--)
                    {
                        if (PlayerLost[i, j] == 1)
                        {
                            if (XetQuanPhom(PlayerWin, i, j) == 1)
                            {
                                Console.WriteLine(i + " " + j);
                            }
                        }
                    }
                }
                Console.ReadKey();
            }
        }
        static int XetQuanPhom(int[,] PlayerWin, int i,int j)
        {
            int dem = 0;
            for (int k = 0; k < 4; k++)
            {
                if (PlayerWin[i, k] == 1)
                {
                    dem++;
                }
            }
            if (dem >= 2) return (1);

            if (i == 0)
            {
                if (PlayerWin[i + 1, j] == 1 && PlayerWin[i + 2, j] == 1) return (1);
            }

            if (i == 12)
            {
                if (PlayerWin[i - 1, j] == 1 && PlayerWin[i - 2, j] == 1) return (1);
            }

            if (i == 1 || i == 11)
            {
                if (PlayerWin[i - 1, j] == 1 && PlayerWin[i + 1, j] == 1) return (1);
                if (i == 1)
                {
                    if (PlayerWin[i + 1, j] == 1 && PlayerWin[i + 2, j] == 1) return (1);
                }
                else
                {
                    if (PlayerWin[i - 1, j] == 1 && PlayerWin[i - 2, j] == 1) return (1);
                }
            }
            if(i != 1 && i!= 11)
            {
                if (PlayerWin[i - 1, j] == 1 && PlayerWin[i - 2, j] == 1) return (1);
                if (PlayerWin[i - 1, j] == 1 && PlayerWin[i + 1, j] == 1) return (1);
                if (PlayerWin[i + 1, j] == 1 && PlayerWin[i + 2, j] == 1) return (1);
            }
            return (0);
        }
        static void Xuat(int[,] player, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", player[i, j]);
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
        static void Nhap(int[,] player, int i, int j)
        {
            for (j = 0; j < 4; j++)
            {
                for (i = 0; i < 13; i++)
                {
                    player[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
