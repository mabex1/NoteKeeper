using System;
using System.Collections.Generic;
using System.Text;

namespace NoteKeeper
{
    internal class UI
    {
        public void Hello()
        {
            Console.WriteLine();
            Console.WriteLine("Добро пожаловать в хранитель заметок!");
        }

        public void BlankSpace()
        {
            Console.WriteLine();
        }

        public void ShowNotes(object id, object title, object content)
        {
            Console.WriteLine($"{id}. {title}: {content}");
        }

        public void ShowAct()
        {
            Console.WriteLine();
            Console.WriteLine("=== ХРАНИТЕЛЬ ЗАМЕТОК ===");
            Console.WriteLine("1.Добавить заметку");
            Console.WriteLine("2.Удалить заметку");
            Console.WriteLine("3.Показать заметки");
            Console.WriteLine("4.Выйти");
            Console.WriteLine("5.Очистить базу данных");
        }

        public int Insert()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите дейтсвие 1-5");
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
                {
                    Console.WriteLine("Выберите дейтсвие 1-5");
                }
                else
                {
                    return int.Parse(input);
                }
            }
        }

        public Note InputNote()
        {
            Note note = new Note();
            Console.WriteLine();
            Console.WriteLine("Введите название заметки:");
            string Title = Console.ReadLine();
            Console.WriteLine("Введите cодержимое заметки");
            string Content = Console.ReadLine();
            note.Title = Title;
            note.Content = Content;
            return note;
        }
        
        public int DelNote()
        {
            Console.WriteLine();
            Console.WriteLine("Введите номер заметки который нужно удалить:");
            while (true)
            {
                string inputDel = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputDel))
                {
                    Console.WriteLine("Введите номер заметки который нужно удалить:");
                }
                else
                {
                    if (int.TryParse(inputDel, out int result))
                    {
                        return result;
                    }
                }
            }
        }
    }
}
