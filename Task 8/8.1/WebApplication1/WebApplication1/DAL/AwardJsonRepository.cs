using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.DAL.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.DAL
{
    public class AwardJsonRepository : IAwardRepository
    {
        private const string PATH_TO_USERS = @"C:\Users\srs10\edu\epam-xt-2021\Task 8\8.1\WebApplication1\WebApplication1\localstorage\users\";
        private const string PATH_TO_AWARDS = @"C:\Users\srs10\edu\epam-xt-2021\Task 8\8.1\WebApplication1\WebApplication1\localstorage\awards\";

        public void AddAward(Award award)
        {
            string json = JsonConvert.SerializeObject(award);
            File.WriteAllText(GetPathToAwardsStore(award.ID), json);
        }

        public List<Award> GetAllAward()
        {
            var awards = new List<Award>();
            var files = Directory.GetFiles(PATH_TO_AWARDS, "*.json");
            foreach (var file in files)
            {
                var str = File.ReadAllText(file);
                Award award = JsonConvert.DeserializeObject<Award>(str);
                awards.Add(award);
            }
            return awards;
        }

        public Award GetAward(Guid id)
        {
            if (!File.Exists(GetPathToAwardsStore(id)))
            {
                throw new FileNotFoundException("Award with ID - " + id + " not found!");
            }
            var str = File.ReadAllText(GetPathToAwardsStore(id));
            Award award = JsonConvert.DeserializeObject<Award>(str);
            return award;
        }
        private string GetPathToAwardsStore(Guid id) => PATH_TO_AWARDS + id + ".json";

        private string GetPathToUserStore(Guid id) => PATH_TO_USERS + id + ".json";
    }
}