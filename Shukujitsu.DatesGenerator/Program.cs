using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shukujitsu.DatesGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start generating code.");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var stringBuilder = new StringBuilder();
            WriteFirstPartOfCode(stringBuilder);

            using (var stream = await DownloadShukujitsuCsv())
            using (var sr = new StreamReader(stream, Encoding.GetEncoding("shift_jis")))
            {
                // 1行目はヘッダ行なので読み飛ばす
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var rec = sr.ReadLine().Split(',');
                    stringBuilder.AppendLine(Format(rec[0], rec[1]));
                }
            }
            WriteEndPartOfCode(stringBuilder);
            Output(stringBuilder, "./Shukujitsu/Dates.cs");
        }

        static void Output(StringBuilder stringBuilder, string path)
        {
            File.WriteAllText(path, stringBuilder.ToString());
        }

        static async Task<Stream> DownloadShukujitsuCsv()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://www8.cao.go.jp/chosei/shukujitsu/syukujitsu.csv");
                return await response.Content.ReadAsStreamAsync();
            }
        }

        static void WriteFirstPartOfCode(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;

namespace Shukujitsu
{
    internal class Dates
    {
        internal static Dictionary<DateTime, string> dict = new[]
        {");
        }

        static void WriteEndPartOfCode(StringBuilder stringBuilder)
        {
            stringBuilder.Append(@"        }.ToDictionary(x => DateTime.Parse(x.Item1), x => x.Item2);
    }
}");
        }

        public static string Format(string shukujitsuDate, string shukujitsuName)
        {
            return $"{string.Empty, 12}(\"{shukujitsuDate}\", \"{shukujitsuName}\"),";
        }

    }
}
