using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Directory
{
    internal class WorkDirectory
    {
        private string _directory;
        private string _name;
        public void SetWay()
        {
            //Console.WriteLine($"Введите путь по котрому хотите создать директорию");
            //string way = Console.ReadLine();
            Console.WriteLine($"Введите название директории");
            _name = Console.ReadLine();
            //string directory = $@"{way}{enter}";
            _directory = $@"C:\Users\Nikita77227\Desktop\{_name}";

        }
        public void CreateDirectory()
        {
            SetWay();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (!dirinfo.Exists)
            {
                try
                {
                    dirinfo.Create();
                    Console.WriteLine($"Вы создали директорию: {_name}");
                }
                catch
                {
                    Console.WriteLine($"Не удалось создать директорию по указанному адресу");
                }

            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public void DeleteDirectory()
        {
            SetWay();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                try
                {
                    dirinfo.Delete();
                    Console.WriteLine($"Вы удалили директорию {_name}");
                }
                catch
                {
                    Console.WriteLine($"Не удалось удалить директорию по указанному адресу");
                }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public void GetFiles()
        {
            SetWay();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                DirectoryInfo[] dirs = dirinfo.GetDirectories();
                if (dirs == null) { Console.WriteLine($"Нет подкаталогов"); }//не работает
                else
                {
                    Console.WriteLine("Подкаталоги:");
                    foreach (DirectoryInfo dir in dirs)
                    {
                        Console.WriteLine(dir.Name);
                    }
                }
                Console.WriteLine();
                FileInfo[] files = dirinfo.GetFiles();
                if (files == null) { Console.WriteLine($"Нет файлов"); }
                else
                {
                    Console.WriteLine("Файлы:");
                    foreach (FileInfo file in files)
                    {
                        Console.WriteLine(file.Name);
                    }
                }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public void DeleteFile()
        {
            SetWay();
            Console.WriteLine($"Введите название файла который нужно удалить");
            string enter = Console.ReadLine();
            string file = $@"{_directory}\{enter}.txt";
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            FileInfo finfo = new FileInfo(file);
            if (dirinfo.Exists)
            {
                if (finfo.Exists)
                {
                    finfo.Delete();
                    Console.WriteLine($"файл {enter} удалён");
                }
                else { Console.WriteLine($"Файл не найден"); }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public void CreateFile()
        {
            SetWay();
            Console.WriteLine($"Введите название файла который хотите создать");
            string enter = Console.ReadLine();
            string file = $@"{_directory}\{enter}.txt";
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            FileInfo finfo = new FileInfo(file);
            if (dirinfo.Exists)
            {
                if (finfo.Exists)
                {
                    finfo.Create();
                    Console.WriteLine($"Файл {enter} создан");
                }
                else { Console.WriteLine($"Файл не найден"); }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public async void ReadFile()
        {
            SetWay();
            Console.WriteLine($"Введите название файла который хотите считать");
            string enter = Console.ReadLine();
            string file = $@"{_directory}\{enter}.txt";
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            FileInfo finfo = new FileInfo(file);
            if (dirinfo.Exists)
            {
                if (finfo.Exists)
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        Console.WriteLine();
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
                else { Console.WriteLine($"Файл не найден"); }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public async void RecordInformation()
        {
            SetWay();
            Console.WriteLine($"Введите название файла в который хотите записать данные");
            string enter = Console.ReadLine();
            string file = $@"{_directory}\{enter}.txt";
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            FileInfo finfo = new FileInfo(file);
            if (dirinfo.Exists)
            {
                if (finfo.Exists)
                {
                    while (true)
                    {
                        Console.WriteLine($"Хотите ли вы полностью перезаписать файл (введите 1)да. 2)нет)");
                        string number = Console.ReadLine();
                        bool numbe = int.TryParse(number, out int check);
                        Console.WriteLine($"Введите то что хотите записать в файл");
                        string text = Console.ReadLine();
                        if (numbe == true)
                        {
                            if (check == 1)
                            {
                                using (StreamWriter writer = new StreamWriter(file, false))
                                {
                                    await writer.WriteLineAsync(text);
                                    break;
                                }
                            }
                            else if (check == 2)
                            {
                                using (StreamWriter writer = new StreamWriter(file, true))
                                {
                                    await writer.WriteLineAsync(text);
                                    break;
                                }
                            }
                            else { Console.WriteLine($"Выберите вариант из предложенных"); }
                        }
                        else { Console.WriteLine($"Выберите вариант из предложенных"); }
                    }
                }
                else { Console.WriteLine($"Файл не найден"); }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
    }
}
