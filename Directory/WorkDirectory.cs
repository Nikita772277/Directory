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
        private string _namefile;
        private string _nameuser;
        public void SetNameUser()
        {
            Console.WriteLine($"Введите имя учётной записи Windows( Для упрощёния ввода пути если директория на рабочем столе)");
            _nameuser = Console.ReadLine();
        }
        public void SetWay()
        {
            Console.WriteLine($"Введите путь к директории");
            string way = Console.ReadLine();
            _directory = $@"{way}";
        }
        public void CreateOnTheDesktop()
        {
            Console.WriteLine($"Введите название директории");
            _namefile = Console.ReadLine();
            _directory = $@"C:\Users\{_nameuser}\Desktop\{_namefile}";
        }
        private void UserSelection()
        {
            while (true)
            {
                Console.WriteLine($"Директория на робочем столе 1) да. 2) нет.");
                string chek = Console.ReadLine();
                bool che = int.TryParse(chek, out int result);
                if (result == 1)
                {
                    CreateOnTheDesktop();
                    break;
                }
                else if (result == 2)
                {
                    SetWay();
                    break;
                }
                else { Console.WriteLine($"Выберите вариант из предложенных"); }
            }
        }
        public void CreateDirectory()
        {
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (!dirinfo.Exists)
            {
                try
                {
                    dirinfo.Create();
                    Console.WriteLine($"Вы создали директорию: {_namefile}");
                }
                catch
                {
                    Console.WriteLine($"Не удалось создать директорию по указанному адресу");
                }

            }
            else { Console.WriteLine($"Директория с таким названием уже существует"); }
        }
        public void DeleteDirectory()
        {
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                try
                {
                    dirinfo.Delete();
                    Console.WriteLine($"Вы удалили директорию {_namefile}");
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
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            Console.WriteLine();
            FileInfo[] files = dirinfo.GetFiles();
            if (files == null)
            {
                Console.WriteLine($"Нет файлов");
            }
            else
            {
                Console.WriteLine("Файлы:");
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                }
            }
        }
        public void DeleteFile()
        {
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                Console.WriteLine($"Введите название файла который нужно удалить");
                string enter = Console.ReadLine();
                string file = $@"{_directory}\{enter}.txt";
                FileInfo finfo = new FileInfo(file);
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
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                Console.WriteLine($"Введите название файла который хотите создать");
                string enter = Console.ReadLine();
                string file = $@"{_directory}\{enter}.txt";
                FileInfo finfo = new FileInfo(file);
                if (!finfo.Exists)
                {
                    finfo.Create();
                    Console.WriteLine($"Файл {enter} создан");
                }
                else { Console.WriteLine($"Файл не создан"); }
            }
            else { Console.WriteLine($"Директория не найдена"); }
        }
        public async void ReadFile()
        {
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                Console.WriteLine($"Введите название файла который хотите считать");
                string enter = Console.ReadLine();
                string file = $@"{_directory}\{enter}.txt";
                FileInfo finfo = new FileInfo(file);
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
            UserSelection();
            DirectoryInfo dirinfo = new DirectoryInfo(_directory);
            if (dirinfo.Exists)
            {
                Console.WriteLine($"Введите название файла в который хотите записать данные");
                string enter = Console.ReadLine();
                string file = $@"{_directory}\{enter}.txt";
                FileInfo finfo = new FileInfo(file);
                if (finfo.Exists)
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Хотите ли вы полностью перезаписать файл (введите 1)да. 2)нет)");
                        Console.WriteLine();
                        string number = Console.ReadLine();
                        bool numbe = int.TryParse(number, out int check);

                        if (numbe == true)
                        {
                            Console.WriteLine($"Введите то что хотите записать в файл");
                            string text = Console.ReadLine();
                            if (check == 1)
                            {
                                using (StreamWriter writer = new StreamWriter(file, false))
                                {
                                    await writer.WriteLineAsync(text);
                                    Console.WriteLine($"Введённый текст записан в файл");
                                    break;
                                }
                            }
                            else if (check == 2)
                            {
                                using (StreamWriter writer = new StreamWriter(file, true))
                                {
                                    await writer.WriteLineAsync(text);
                                    Console.WriteLine($"Введённый текст записан в файл");
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
