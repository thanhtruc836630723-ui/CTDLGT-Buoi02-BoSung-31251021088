using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021088
{
    internal class Bài_02
    {
        //Hàm kiểm tra mảng có null hay không
        static void CheckNotNull(int[] data, int count)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Mảng data không được phép null.");
            }
            if (count < 0 || count > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Giá trị count không hợp lệ.");
            }
        }

        //Chèn phần tử vào vị trí index
        static void Insert(int[] data, ref int count, int index, int value)
        {
            // Kiểm tra mảng null trước tiên
            CheckNotNull(data, count);

            // Insert chấp nhận index từ 0 đến count
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index khi Insert phải nằm trong đoạn [0, count].");
            }

            // Mảng đầy khi Insert phải phát sinh InvalidOperationException
            if (count >= data.Length)
            {
                throw new InvalidOperationException("Mảng đã đầy, không còn ô trống để Insert.");
            }

            // Dịch (count - index) phần tử từ phải sang trái
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            // Chèn giá trị mới vào index và tăng count
            data[index] = value;
            count++;
        }

        //Xóa phần tử tại vị trí index
        static void RemoveAt(int[] data, ref int count, int index)
        {
            // Kiểm tra mảng null trước tiên
            CheckNotNull(data, count);

            // RemoveAt chỉ chấp nhận index từ 0 đến count - 1
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index khi RemoveAt phải nằm trong đoạn [0, count - 1].");
            }

            // Dịch (count - index - 1) phần tử từ trái sang phải
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            // Giảm count sau khi đã dịch dữ liệu
            count--;
            data[count] = 0;
        }

        // Hàm in các phần tử hợp lệ trong mảng
        static void InMang(int[] data, int count)
        {
            Console.Write("-> Mảng hiện tại: [ ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine($"] (count = {count}, data.Length = {data.Length}, còn {data.Length - count} ô trống)");
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Nhập mảng
            Console.Write("Nhập mảng ban đầu: ");
            string mang = Console.ReadLine()!;
            string[] chuoi = mang.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Số phần tử hợp lệ 
            int count = chuoi.Length; 

            int[] data = new int[count + 3];
            for (int i = 0; i < count; i++)
            {
                data[i] = int.Parse(chuoi[i]);
            }

            InMang(data, count);

            // Vòng lặp để tự nhập thao tác Insert / RemoveAt
            while (true)
            {
                Console.WriteLine("Chọn (1: Insert | 2: RemoveAt | 0: Thoát): ");
                Console.Write("Nhập lựa chọn: ");
                string chon = Console.ReadLine()!;

                if (chon == "0") break;

                try
                {
                    if (chon == "1")
                    {
                        Console.Write("Nhập vị trí index cần chèn: ");
                        int index = int.Parse(Console.ReadLine()!);
                        Console.Write("Nhập giá trị value cần chèn: ");
                        int value = int.Parse(Console.ReadLine()!);

                        Insert(data, ref count, index, value);
                        InMang(data, count);
                    }
                    else if (chon == "2")
                    {
                        Console.Write("Nhập vị trí index cần xóa: ");
                        int index = int.Parse(Console.ReadLine()!);

                        RemoveAt(data, ref count, index);
                        InMang(data, count);
                    }
                }
                catch (Exception ex)
                {
                    // In lỗi ra màn hình
                    Console.WriteLine($"[BÁO LỖI - {ex.GetType().Name}]: {ex.Message}");
                }
            }
        }
    }
}
    
