using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteKeeper
{
    internal class Note
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
