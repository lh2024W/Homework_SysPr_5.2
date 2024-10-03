namespace Homework_SysPr_5._2
{
    public class Program
    {
        static Task task = new Task(Count);
        static bool stop = false;
        static void Main()
        {
            //2. Создайте оконное приложение, использующее механизм задач(класс Task).Пользователь вводит в текстовое поле некоторый текст. 
            //По нажатию на кнопку приложение должно проанализировать текст и вывести отчет.Отчёт содержит информацию о:

            //■ Количестве предложений; 
            //■ Количестве символов; 
            //■ Количестве слов; 
            //■ Количестве вопросительных предложений; 
            //■ Количестве восклицательных предложений.

            //Отчёт в зависимости от выбора пользователя отображается на экране или сохраняется в файл.


            task.Start();
            int cin = 0;
            do
            {
                Console.WriteLine("1. Ввести текст");
                Console.WriteLine("2. Выход");
                
                cin = Convert.ToInt32(Console.ReadLine());
                switch (cin)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите текст.");
                            string str = Convert.ToString(Console.ReadLine());
                            Task[] tasks =
                            {
                                Task.Run(() => {Console.WriteLine("Количество символов: {0}",str.Length); }),
                                Task.Run(() => {Console.WriteLine("Количество слов: {0}",CountWords(str)); }),
                                Task.Run(() => {Console.WriteLine("Количество предложений: {0}",CountSentences(str)); }),
                                Task.Run(() => {Console.WriteLine("Количество вопросительных предложений: {0}",CountInterrogativeSentences(str)); }),
                                Task.Run(() => {Console.WriteLine("Количество восклицательных предложений: {0}",CountExclamatorySentences(str)); })
                            };
                            Task.WaitAll(tasks);
                            break;
                        }
                    
                    case 2: { Environment.Exit(0); break; }
                    default: { Console.WriteLine("Not Valid!"); break; }
                }
                Console.ReadLine();
                Console.Clear();
            } while (cin != 2);
            Console.ReadLine();
        }

        static int CountWords(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    sum += 1;
                }
            }
            return sum;
        }

        static int CountSentences(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    sum += 1;
                }
            }
            return sum;
        }

        static int CountInterrogativeSentences(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                {
                    sum += 1;
                }
            }
            return sum;
        }

        static int CountExclamatorySentences(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '!')
                {
                    sum += 1;
                }
            }
            return sum;
        }

        static void Count()
        {
            while (true)
            {
                if (stop) break;
                Number.MyNumber++;
                Thread.Sleep(100);
            }
        }

        class Number
        {
            public static int MyNumber { get; set; }
        }
    }
}
   

