using System.Text;

namespace CodeEncode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Зашифроват файл в base64:");
            Console.WriteLine("2 - Расшифровать base64 в файл");

            int InputChoice = int.Parse(Console.ReadLine());

            switch(InputChoice)
            {
                case 1:
                    EncodeFileToBase();
                    break;
                case 2:
                    DecodeBaseToFile();
                    break;
               
                default: Console.WriteLine("Некоректный ввод");
                    break;

            }

            static void EncodeFileToBase()
            {
                Console.Write("Введите полный путь к файлу для кодирования");
                string InputFilePatch = Console.ReadLine();

                if(!File.Exists(InputFilePatch))
                {
                    Console.WriteLine("файл не найден...");
                }
                byte[] bytes = File.ReadAllBytes(InputFilePatch);
                string base64string = Convert.ToBase64String(bytes);

                string outputFilePath = Path.ChangeExtension(InputFilePatch, "Base64.txt");
                File.WriteAllText(outputFilePath, base64string);
                Console.WriteLine($"Строка сохранена в {outputFilePath} ");
            }

            static void DecodeBaseToFile()
            {
                Console.WriteLine("Введите путь куда сохранить файл");
                string outputFilePatch = Console.ReadLine();

                Console.WriteLine("Введите base64 строку");
                string? inputBasePatch = Console.ReadLine();

                try
                {
                    byte[] fileBytes = Convert.FromBase64String(inputBasePatch);
                    File.WriteAllBytes(outputFilePatch, fileBytes);
                    Console.WriteLine($"Файл успешно восстановлен - {outputFilePatch} ");
                }
                catch 
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }





        }
    }
}
