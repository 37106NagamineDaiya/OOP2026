
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***** 曲の登録 *****");
            var songs = new List<Song>();
            while (true) {
                Console.Write("曲名：");
                string? Title = Console.ReadLine();
                if (string.Equals(Title, "end",
                     StringComparison.OrdinalIgnoreCase)) {
                        break;
                    }
                Console.Write("アーティスト名：");
                string? ArtistName = Console.ReadLine();
                Console.Write("演奏時間(秒)：");
                int Length = int.Parse(Console.ReadLine()!);
                songs.Add(new Song(Title!, ArtistName!, Length));

            }
            PrintSongs(songs);
        }

        private static void PrintSongs(List<Song> songs) {
            foreach (var song in songs) {
                Console.WriteLine($"{song.Title},{song.ArtistName} {song.Length / 60}:{(song.Length % 60):D2}");

            }
        }
    }
}
