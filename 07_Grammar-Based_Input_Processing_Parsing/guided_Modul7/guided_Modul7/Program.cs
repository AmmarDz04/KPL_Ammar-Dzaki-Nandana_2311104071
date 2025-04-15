using System.Text.Json.Serialization;
using System.Text.Json;

namespace modul7
{
    class Article
    {
        [JsonPropertyName("title")]
        public string judul { get; set; }
        public String author { get; set; }
    }

    internal class Jurnal
    {
        public String journal_name { get; set; }
        public List<Article> articles { get; set; }
        public int volume { get; set; }
        public int tahun_terbit { get; set; }

        public static void ReadJson()
        {
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "jurnal.json");
            if (File.Exists(pathFile))
            {
                string jsonData = File.ReadAllText(pathFile);
                Jurnal jurnal = JsonSerializer.Deserialize<Jurnal>(jsonData);

                Console.WriteLine($"Judul jurnal: {jurnal.journal_name}");
                Console.WriteLine("List artikel: ");
                int index = 1;
                foreach (var artikel in jurnal.articles)
                {
                    Console.WriteLine($"Judul artikel {index}: {artikel.judul}");
                    Console.WriteLine($"Author artikel {index}: {artikel.author}");
                    index++;
                }

                Console.WriteLine($"Volume: {jurnal.volume}");
                Console.WriteLine($"Tahun terbit: {jurnal.tahun_terbit}");
            }
            else
            {
                Console.WriteLine("File tidak ditemukan");
                Console.WriteLine(pathFile);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Jurnal.ReadJson();
            Console.ReadKey();
        }
    }
}