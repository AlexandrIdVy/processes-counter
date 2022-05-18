using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindProcess
{
    class ClassLastFolder
    {
        // функция для поиска последней созданной папки
        public string LastFolder(string path_1)
        {
            string lastFolder =
            (new DirectoryInfo(path_1))
            .GetDirectories()
            .OrderByDescending(di => di.CreationTime)
            .First()
            .Name;
            return lastFolder;
        }
    }

    class ClassCheckCount
    {
        // функция для проверки совподения текущей записи в файле 
        public int CheckCount(string path_2, string countFind)
        {
            int check;
            string search = File.ReadAllLines(path_2, Encoding.UTF8).Last(); // читаем последнюю строку из лог файла
            string[] subsSearch = search.Split(';');
            string[] subsCountFind = countFind.Split(';');

            if (subsSearch[0].Contains(subsCountFind[0])) // если дата совпадает, то
            {
                if (subsSearch[1].Contains(subsCountFind[1])) // если количество процессов совпадает, то ничего не делаем
                {
                    check = 112;
                }
                else // если количество процессов не совпадает
                {
                    string[] lines = File.ReadAllLines(path_2, Encoding.UTF8); // читаем CountProcessLog.txt
                    File.WriteAllLines(path_2, lines.Take(lines.Length - 1).ToArray()); // удаляем последнюю строку
                    File.AppendAllText(path_2, string.Format(countFind + Environment.NewLine)); // добавляем в CountProcessLog.txt новую строку с датой и количеством процессов
                    check = Convert.ToInt32(subsSearch[1]); // передаем количество процессов
                }
            }
            else // если запись не существует, то записываем в лог следующей строкой
            {
                File.AppendAllText(path_2, string.Format(countFind + Environment.NewLine));
                check = 111;
            }

            return check;
        }
    }

    class ClassCountProcess
    {
        // функция для суммирования числа процессов "ProcMade"
        public string CountProcess(string path_3, int number)
        {
            int countProcessToInt;
            string countProcess = File.ReadAllLines(path_3, Encoding.UTF8).First();
            countProcessToInt = Convert.ToInt32(countProcess) + number;
            File.WriteAllText(path_3, Convert.ToString(countProcessToInt));
            countProcess = File.ReadAllLines(path_3, Encoding.UTF8).First();
            return countProcess;
        }
    }

    class ClassCountProcessToClean
    {
        // функция для вычитания числа процессов "ProcToClean"
        public string CountProcessToClean(string path_3, int number)
        {
            int countProcessToInt;
            string countProcess = File.ReadAllLines(path_3, Encoding.UTF8).First();
            countProcessToInt = Convert.ToInt32(countProcess) - number;
            File.WriteAllText(path_3, Convert.ToString(countProcessToInt));
            countProcess = File.ReadAllLines(path_3, Encoding.UTF8).First();
            return countProcess;
        }
    }

    class ClassTimeTrue
    {
        // функция для проверки повторных запусков по времени
        public bool TimeTrue(string str)
        {
            string[] subsSearch = str.Split(';');
            return true;
        }

    }
}
