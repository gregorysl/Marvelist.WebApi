using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using MarvelAPI;
using Marvelist.Entities;
using Newtonsoft.Json;
using Comic = Marvelist.Entities.Comic;
using Series = Marvelist.Entities.Series;

namespace JsonToSqlInsertParser
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void doStuff()
        {
            var dataType = "1";
            string[] skiplist = { };
            var marvelType = ParseEnum<MarvelType>(dataType);
            IEnumerable<MarvelistModel> datass = new List<MarvelistModel>();
            switch (marvelType)
            {
                case MarvelType.Series:
                    var seriesData = ReadFromFile<MarvelAPI.Series>(@"C:\Marvel\Series.txt");
                    skiplist = new[] { "Comics", "UserSeries" };
                    datass = Mapper.Map<List<Series>>(seriesData);
                    break;
                case MarvelType.Comics:
                    var comicData = ReadFromFile<MarvelAPI.Comic>(@"C:\Marvel\Comics.txt");
                    datass = Mapper.Map<List<Comic>>(comicData);
                    skiplist = new[] { "Series", "UserComic", "ComicCreator" };
                    break;
            }
            var insertList = datass.Select(x => ParseData.CreateSqlInserts(skiplist, x));
            var sb = new StringBuilder();
            foreach (var c in insertList)
            {
                sb.Append(c);
            }
            var asd = sb.ToString();
        }
        public static TEnum ParseEnum<TEnum>(string sEnumValue) where TEnum : struct
        {
            TEnum eTemp;
            TEnum? eReturn = null;
            if (Enum.TryParse(sEnumValue, out eTemp))
                eReturn = eTemp;
            return eReturn.GetValueOrDefault();
        }
        public static List<T> ReadFromFile<T>(string path)
        {
            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<T>>(json);
                return data;
            }
        }
    }
}