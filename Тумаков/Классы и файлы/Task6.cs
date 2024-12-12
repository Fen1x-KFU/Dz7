using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Song
    {
        public string name;
        public string author;
        private Song prev;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        // Метод для печати названия песни и ее исполнителя
        public void Print(string song)
        {
            Console.WriteLine($"Песня: {song}");
        }

        public string Title(string name, string author)
        {
            string song = $"{name} -- {author}";
            return song;
        }

        // Метод для сравнения двух объектов-песен
        public override bool Equals(object obj)
        {
            Song other = obj as Song;
            if (other == null)
                return false;

            return (this.name == other.name || this.author == other.author);
        }
    }
}
