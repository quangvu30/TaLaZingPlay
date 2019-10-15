using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//static void XetPhom(int[,] player, int dem, int j, int i);
//static int XetBala(int[,] player, int i);
//static int XetBala(int[,] player, int i);
//static void Xuat(int[,] player, int j, int i);

namespace Phom
{
    class Program
    {
        static void Main(string[] args)
        {
            int dem = 0;
            int[,] player = new int[13, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    player[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Xuat(player, 13, 4);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (player[i, j] == 1)
                    {
                        dem++;
                        if(i==12)
                        {
                            i++;
                            XetSanh(player, dem, j, i - dem);
                            dem = 0;
                        }
                    }
                    else
                    {
                        if (dem >= 3)
                        {
                            XetSanh(player, dem, j, i - dem);
                        }
                        dem = 0;
                    }
                }
            }
            for(int i = 0; i < 13; i++)
            {
                XetBala(player, i);
            }
            Console.Write("\n");
            Xuat(player, 13, 4);
            return;
        }

        static void XetSanh(int[,] player, int dem, int j, int i)
        {
            //-------------------- xét trường hợp sảnh 3 -----------------------------// 
            int temp = 0;
            if (dem == 3)
            {
                MarkSanh(player, j, i, i + 2);
                return;
            }
            //-------------------- xét trường hợp sảnh 4 -----------------------------// 
            if (dem == 4)
            {
                if (XetBala(player, i) == 1)
                {
                    MarkSanh(player, j, i + 1, i + 3);
                    return;
                }
                if(XetBala(player, i + 3) == 1)
                {
                    MarkSanh(player, j, i, i + 2);
                    return;
                }
                else
                {
                    MarkSanh(player, j, i, i + 3);
                    return;
                }

            }
            //-------------------- xét trường hợp sảnh 5 -----------------------------// 
            if (dem == 5)
            {
                if (XetBala(player, i) == 1)
                {
                    MarkSanh(player, j, i + 1, i + 4);
                    return;
                }
                if (XetBala(player, i + 1) == 1)
                {
                    MarkSanh(player, j, i + 2, i + 4);
                    return;
                }
                if (XetBala(player, i + 3) == 1)
                {
                    MarkSanh(player, j, i, i + 2);
                    return;
                }
                if (XetBala(player, i + 4) == 1)
                {
                    MarkSanh(player, j, i, i + 3);
                    return;
                }
                else
                {
                    MarkSanh(player, j, i, i + 4);
                    return;
                }
            }
            //-------------------- xét trường hợp sảnh > 5-----------------------------//
            if(dem > 5)
            {
                MarkSanh(player, j, i, i+dem-1);
                return;
            }
        }

        /* * * * * * * * * *  * * * * * * * * *
         *     hàm xét có phỏm 3 lá không     *
         * * * * * * * * * *  * * * * * * * * */
        static int XetBala(int[,] player, int i)
        {
            int temp = 0;
            for (int k = 0; k < 4; k++)
            {
                if (player[i, k] == 1)
                {
                    temp++;
                }
            }
            if (temp >= 3)
            {
                for (int k = 0; k < 4; k++)
                {
                    player[i, k] = 0;
                }
                return (1);
            }
            return (0);
        }

        /* * * * * * * * * *  * * * * *
         *    hàm đánh dấu là sảnh    *
         * * * * * * * * * *  * * * * */
        static void MarkSanh(int[,] player, int j, int i, int end)
        {
            for (int k = i; k <= end; k++)
            {
                player[k, j] = 0;
            }
        }

        //in màn hình
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
    }
}
