using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021088
{
    internal class Bài_01
    {
        public static void Main65(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Nhập mảng và ép kiểu
            Console.Write("Nhập mảng: ");
            string mang = Console.ReadLine();

            //Tách mảng ra thành từng phần tử để thống kê
            string[] chuoi = mang.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Chuyển tất cả phần tử từ kiểu string sang int
            int[] arr = Array.ConvertAll(chuoi, int.Parse);

            //Lấy số phần tử vừa nhập thành số lượng n nguyên tử để kiểm tra
            int n = arr.Length;

            //Kiểm tra ràng buộc 1 <= n <= 100000
            if (n< 1 || n > 100000 )
            {
                Console.WriteLine("Mảng không hợp lệ");
                return;
            }

            //Gán các giá trị 
            long tong = 0;
            int max = 0;
            int min = 0;
            int SoAm = 0;
            int SoDuong = 0;
            int Bang0 = 0;

            //Cho chương trình chạy từ phần tử đầu tiên tới phần tử cuối và tính toán 
            for (int i = 0; i < n; i++)
            {
                //Tính tổng
                tong += arr[i];
                //Điều kiện để tìm ra max
                if (max < arr[i]) 
                    max = arr[i];
                //Điều kiện để tìm ra min
                if (min > arr[i])
                    min = arr[i];
                //Đếm các phần tử là số dương
                if (arr[i] > 0)
                    SoDuong++;
                //Đếm các phần tử là số âm
                else if (arr[i] < 0)
                    SoAm++;
                //Đếm các phần tử bằng 0
                else
                    Bang0++;
            }

            //Tính giá trị trung bình
            double tb = (double)tong / n;

            //In kết quả thống kê
            Console.WriteLine($"Tổng: {tong}");
            Console.WriteLine($"Giá trị lớn nhất: {max}");
            Console.WriteLine($"Giá trị nhỏ nhất: {min}");
            Console.WriteLine($"Trung bình: {tb}");
            Console.WriteLine($"Số phần tử âm: {SoAm}");
            Console.WriteLine($"Số phần tử dương: {SoDuong}");
            Console.WriteLine($"Số phần tử bằng 0: {Bang0}");

            //Đảo mảng
            //Gán giá trị cho biến
            int left = 0;
            int right = n - 1;

            //Cho chương trình đảo mảng cho đến khi số phần tử bên trái lớn hơn số phần tử bên phải thì ngưng đảo
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }

            //In mảng sau khi đảo
            Console.WriteLine("Mảng sau khi đảo: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] );
            }
            Console.WriteLine( );

        }
    }
}
