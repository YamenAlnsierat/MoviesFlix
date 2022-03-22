using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movieflix_api.Models;

namespace movieflix_api.Data
{
    public class LoadData
    {

        public static async Task LoadMovies(DataContext context)
        {
            if(await context.Movies.AnyAsync()){
                return;
            }

            var options = new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            };

            var data = await File.ReadAllTextAsync("Data/movies.json");
            var movies = JsonSerializer.Deserialize<List<Movie>>(data, options);
            
            if(movies is not null) 
            {
                // foreach(var m in movies){
                //     context.Movies.Add(m);
                //     await context.SaveChangesAsync();
                // }
                await context.AddRangeAsync(movies);
                await context.SaveChangesAsync();
            };
        }
    }
}