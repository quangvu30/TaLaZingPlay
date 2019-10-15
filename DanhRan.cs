using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhRan
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------mảng tổng bài đã biết---------------//
            int[,] AllPlayer = new int[13, 4];

            //--------------mảng bài người cần đánh rắn ---------------//
            int[,] player = new int[13, 4];

            Nhap(AllPlayer, 13,4);
            Console.WriteLine("-----");
            Nhap(player,13,4);
            Console.WriteLine("---AllPlayer--");
            Xuat(AllPlayer, 13, 4);
            Console.WriteLine("---player--");
            Xuat(player,13,4);


            //------------------------------------------//
            for (int i = 12; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (player[i, j] == 1)
                    {
                        if (XetQuanRan(AllPlayer, i, j) == 1)
                        {
                            Console.WriteLine(i + " " + j);
                        }
                    }
                }
            }
            Console.ReadKey();
        } 
        /* * * * * * * * * * * * * * * * * * * * * * *
         *              Hàm xét quân rắn             *
         * * * * * * * * * * * * * * * * * * * * * * */
        static int XetQuanRan(int [,] AllPlayer, int i , int j)
        {
            int dem=0;
            for(int k = 0; k < 4; k++)
            {
                if(AllPlayer[i, k] == 0)
                {
                    dem++;
                }
            }
            if(dem >= 2) return (0);

            if (i==0)
            {
                if(AllPlayer[i+1, j]==0 && AllPlayer[i + 2, j]==0) return (0);
            }

            if(i==12)
            {
                if (AllPlayer[i - 1, j] == 0 && AllPlayer[i - 2, j] == 0) return (0);
            }

            if (i == 1 || i == 11)
            {
                if (AllPlayer[i - 1, j] == 0 && AllPlayer[i + 1, j] == 0) return (0);
                if (i == 1)
                {
                    if (AllPlayer[i + 1, j] == 0 && AllPlayer[i + 2, j] == 0) return (0);
                }
                else
                {
                    if (AllPlayer[i - 1, j] == 0 && AllPlayer[i - 2, j] == 0) return (0);
                }
            }
            if(i!= 0 && i!= 1 && i!= 11 & i!= 12)
            {
                if (AllPlayer[i - 1, j] == 0 && AllPlayer[i - 2, j] == 0) return (0);
                if (AllPlayer[i - 1, j] == 0 && AllPlayer[i + 1, j] == 0) return (0);
                if (AllPlayer[i + 1, j] == 0 && AllPlayer[i + 2, j] == 0) return (0);
            }
            return (1);
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
