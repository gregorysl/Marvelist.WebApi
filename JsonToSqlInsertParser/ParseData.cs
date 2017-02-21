using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Marvelist.Entities;

namespace JsonToSqlInsertParser
{
    public static class ParseData
    {
        public static string CreateSqlInserts(string[] skipList, MarvelistModel data)
        {
            var type = data.GetType();
            var props = type.GetProperties().Where(x => !skipList.Contains(x.Name));
            var leftSqlSide = new StringBuilder($"Insert {type.Name} (");
            var rightSqlSide = new StringBuilder(") values (");
            foreach (var prop in props)
            {
                var value = prop.GetValue(data, null);
                if (prop.PropertyType == typeof(float))
                {
                    leftSqlSide.AppendFormat("[{0}],", prop.Name);
                    rightSqlSide.AppendFormat("{0},", ((float)value).ToString("F", CultureInfo.InvariantCulture));
                }
                else if (prop.PropertyType == typeof(Marvelous.MarvelImage))
                {
                    leftSqlSide.AppendFormat("[{0}_Path],[{0}_Extension]", prop.Name);
                    var thumbnail = (Marvelous.MarvelImage)value;
                    rightSqlSide.AppendFormat("'{0}','{1}'", thumbnail.Path, thumbnail.Extension);

                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    leftSqlSide.AppendFormat("[{0}],", prop.Name);
                    var date = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    rightSqlSide.AppendFormat("'{0}',", date);
                }
                else
                {
                    leftSqlSide.AppendFormat("[{0}],", prop.Name);
                    var newVal = value?.ToString().Replace("'", "''").Replace("\n", "").Replace("\r", "");
                    rightSqlSide.AppendFormat("'{0}',", newVal);
                }
            }
            leftSqlSide.Append(rightSqlSide);
            leftSqlSide.Append(")\n");

            return leftSqlSide.ToString();
        }
    }
}
