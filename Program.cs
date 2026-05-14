using Microsoft.Data.Sqlite;
using System.Data;


namespace NoteKeeper
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            SQL sql = new SQL();

            ui.Hello();

            while (true)
            {
                ui.ShowAct();
                switch (ui.Insert())
                {
                    case 1:
                        sql.InsertNote(ui.InputNote());
                        break;
                    case 2:
                        sql.DelNote(ui.DelNote());
                        break;
                    case 3:
                        ui.BlankSpace();
                        sql.ReadNotes(ui);
                        break;
                    case 4:
                        return;
                    case 5:
                        sql.ResetDatabase();
                        break;
                }
            }
        }
    }
}