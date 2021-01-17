using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutomationStation.Store
{
    public class JsonStore : IStore
    {
        public async void LoadCollection<T>(List<T> collection,string path)
        {
            if(!File.Exists(path)) return;
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            collection.Add(await JsonSerializer.DeserializeAsync<T>(fs));
        }

        public async void SaveCollection<T>(List<T> collection,string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            var options = new JsonSerializerOptions {WriteIndented = true, IgnoreReadOnlyProperties = false};
            await JsonSerializer.SerializeAsync(fs, collection, options);
        }
    }
}