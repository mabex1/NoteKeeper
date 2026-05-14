using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteKeeper
{
    internal class SQL
    {
        public string Create { get; private set; }
        public string Delete { get; private set; }
        public string Insert { get; private set;}
        public string Read { get; private set;}

        SqliteConnection connectionString = new SqliteConnection("Data Source=database.db");
        public void CreateTable()
        {
            Create = @"
                CREATE TABLE IF NOT EXISTS ""notes"" (
	                ""id""	INTEGER,
	                ""Title""	TEXT NOT NULL,
	                ""Content""	TEXT,
	                PRIMARY KEY(""id"" AUTOINCREMENT)
                )";
            connectionString.Open();
            var cmd = connectionString.CreateCommand();
            cmd.CommandText = Create;
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }
        public void DelNote(int id)
        {
            Delete = @"DELETE FROM notes WHERE id = @id";
            connectionString.Open();
            var cmd = connectionString.CreateCommand();
            cmd.CommandText = Delete;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }

        public void InsertNote(Note note)
        {
            Insert = @"INSERT INTO notes (Title, Content) VALUES(@Title, @Content);";
            connectionString.Open();
            var cmd = connectionString.CreateCommand();
            cmd.CommandText = Insert;
            cmd.Parameters.AddWithValue("@Title", note.Title);
            cmd.Parameters.AddWithValue("@Content", note.Content);
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }

        public void ReadNotes(UI ui)
        {
            Read = @"SELECT * FROM notes;";
            connectionString.Open();
            var cmd = connectionString.CreateCommand();
            cmd.CommandText = Read;
            using (var reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    ui.ShowNotes(reader["id"], reader["Title"], reader["Content"]);
                }
            }
            connectionString.Close();
        }

        public void ResetDatabase()
        {
            connectionString.Open();

            var cmd = connectionString.CreateCommand();
            cmd.CommandText = "DELETE FROM notes";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM sqlite_sequence WHERE name = 'notes'";
            cmd.ExecuteNonQuery();

            connectionString.Close();
        }
    }
}
