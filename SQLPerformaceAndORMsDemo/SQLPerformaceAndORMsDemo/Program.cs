using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SQLPerformaceAndORMsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ChinookContext())
            {
                //SelectNPlus1(context);
                //UpdateRows(context);
                //LotsOfEntities(context);
            }
        }

        private static void SelectNPlus1(ChinookContext context)
        {
            var artists = context.Artists.Where(x => x.Name.StartsWith("Iron"))
                .ToList();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine($"album: {album.Title}, tracks: {album.Tracks.Count}");
                }
            }
        }

        private static void UpdateRows(ChinookContext context)
        {
            foreach (var artist in context.Artists)
            {
                if (artist.Name.EndsWith("+"))
                {
                    artist.Name = artist.Name.Substring(0, artist.Name.Length - 1);
                }
                else
                {
                    artist.Name += "+";
                }
            }

            context.SaveChanges();
        }

        private static void LotsOfEntities(ChinookContext context)
        {
            context.PlaylistTracks.ToArray(); // 180k rows


            var stopwatch = new Stopwatch();
            stopwatch.Start();

            context.SaveChanges();

            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
