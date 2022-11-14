
using Directory;

WorkDirectory Wdirektory = new WorkDirectory();
void menu()
{
    Console.WriteLine();
    Console.WriteLine($"1) Создать директорию");
    Console.WriteLine($"2) Удалить директорию");
    Console.WriteLine($"3) Проверить наличие файлов в директории");
    Console.WriteLine($"4) Удалить какой-либо файл в директории");
    Console.WriteLine($"5) Создать текстовый файл");
    Console.WriteLine($"6) Прочитать информацию из какого-либо файла");
    Console.WriteLine($"7) Записать информацию в файл");
    Console.WriteLine($"8) Изменить имя пользователя");
    Console.WriteLine();
}
void GetMenu()
{
    Wdirektory.SetNameUser();
    while (true)
    {
        menu();
        string enter = Console.ReadLine();
        bool ent = int.TryParse(enter, out int number);
        if (ent == true)
        {
            if (number == 1)
            {
                Wdirektory.CreateDirectory();
            }
            else if (number == 2)
            {
                Wdirektory.DeleteDirectory();
            }
            else if (number == 3)
            {
                Wdirektory.GetFiles();
            }
            else if (number == 4)
            {
                Wdirektory.DeleteFile();
            }
            else if (number == 5)
            {
                Wdirektory.CreateFile();
            }
            else if (number == 6)
            {
                Wdirektory.ReadFile();
            }
            else if (number == 7)
            {
                Wdirektory.RecordInformation();
            }
            else if (number == 8)
            {
                Wdirektory.SetNameUser();
            }
            else { Console.WriteLine($"Выберети пункт из меню"); }
        }
        else { Console.WriteLine($"Выберети пункт из меню"); }
    }
}
GetMenu();
