using System.Collections;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Engine
{
    public class Utils
    {
        public static T FromJsonText<T>(string json)
        {
           return JsonSerializer.Deserialize<T>(json);
        }

        public static string ToJsonText<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);           
        }


        //public static async Task<T> FromJsonTextAsync<T>(Stream json, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    return await JsonSerializer.DeserializeAsync<T>(json, cancellationToken: cancellationToken);
        //}

        //public static async Task<string> ToJsonTextAsync<T>(T obj, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    Encoding encoding = Encoding.UTF8;
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        ser.WriteObject(ms, obj);
        //        return encoding.GetString(ms.ToArray());
        //    }
        //    return JsonSerializer.SerializeAsync(obj, cancellationToken);
        //}

        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            StringBuilder rt = new StringBuilder();

            int i = 0;
            foreach (T value in values)
            {
                if (i++ > 0)
                {
                    rt.Append(separator);
                }
                rt.Append(Convert.ToString(value));
            }

            return rt.ToString();
        }

        public static IEnumerable<Y> ConvertAll<X, Y>(IEnumerable enumerable, Converter<X, Y> converter)
        {
            foreach (X x in enumerable)
            {
                yield return converter(x);
            }
        }

    }
}