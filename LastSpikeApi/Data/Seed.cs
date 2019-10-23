using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using LastSpikeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LastSpikeApi.Data
{
    public class Seed
    {
        // public void Initialize ()
        // {
        // using (LastSpikeContext context = new LastSpikeContext ())
        // {
        // context.Database.EnsureCreated ();

        // var users = LoadJson ();

        // foreach (var user in users)
        // {
        //     context.Users.Add (user);
        // }
        // context.SaveChanges ();

        // }
        // }

        // public List<User> LoadJson ()
        // {
        //     using (StreamReader r = new StreamReader ("Data/data.json"))
        //     {
        //         string json = r.ReadToEnd ();
        //         List<User> items = JsonConvert.DeserializeObject<List<User>> (json);
        //         return items;
        //     }
        // }
    }
}