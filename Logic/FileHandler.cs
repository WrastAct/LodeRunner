using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LodeRunner.Logic
{
    class FileHandler
    {
        public static string Save(GameField field)
        {
            string json = JsonConvert.SerializeObject(field, Formatting.Indented);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(Path.Combine(path, "LodeRunner.fields.json")))
            {
                File.Delete(Path.Combine(path, "LodeRunner.fields.json"));
            }
            using (StreamWriter sw = File.CreateText(Path.Combine(path, "LodeRunner.fields.json")))
            {
                sw.WriteLine(json);
                sw.Close();
            }


            return json;
        }

        public static string Save(ScoreItem sc)
        {
            string json = JsonConvert.SerializeObject(sc, Formatting.Indented);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamWriter sw = File.AppendText(Path.Combine(path, "LodeRunner.score.json")))
            {
                sw.WriteLine(json);
                sw.Close();
            }

            return json;
        }

        public static GameField Open()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string json;
            if (File.Exists(Path.Combine(path, "LodeRunner.fields.json")))
            {
                using (StreamReader sw = new StreamReader(Path.Combine(path, "LodeRunner.fields.json")))
                {
                    json = sw.ReadToEnd();
                    sw.Close();
                }

                GameField field = JsonConvert.DeserializeObject<GameField>(json);
                return field;
            }

            return null;
        }

        public static GameField Open(string pathAdd)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string json;
            if (File.Exists(Path.Combine(path, pathAdd)))
            {
                using (StreamReader sw = new StreamReader(Path.Combine(path, pathAdd)))
                {
                    json = sw.ReadToEnd();
                    sw.Close();
                }

                GameField field = JsonConvert.DeserializeObject<GameField>(json);
                return field;
            }

            return null;
        }

        public static ScoreItem OpenScore()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string json;
            if (File.Exists(Path.Combine(path, "LodeRunner.score.json")))
            {
                using (StreamReader sw = new StreamReader(Path.Combine(path, "LodeRunner.score.json")))
                {
                    json = sw.ReadToEnd();
                    sw.Close();
                }

                ScoreItem sc = JsonConvert.DeserializeObject<ScoreItem>(json);
                return sc;
            }

            return null;
        }
    }
}
