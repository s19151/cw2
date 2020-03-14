using Cwiczenia2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cwiczenia2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                String dataPath = (args.Length < 1 ? @"Data\dane.csv" : args[0]);
                String resPath = (args.Length < 2 ? @"żesult.xml" : args[1]);
                String format = (args.Length < 3 ? "xml" : args[2]);

                List<Student> list = ReadFile(dataPath);

                switch (format)
                {
                    case "xml":
                        XmlSerialize(list, resPath);
                        break;

                    case "json":
                        JsonSerialize(list, resPath);
                        break;
                    default:
                        CreateErrorLog("Nieobsługiwany format\n");
                        break;
                }
            }
            catch (ArgumentException)
            {
                CreateErrorLog("Podana ścieżka jest niepoprawna\n");
            }
            catch (FileNotFoundException e)
            {
                CreateErrorLog("Plik " + e.FileName + " nie istnieje\n");
            }
            catch (Exception e)
            {
                CreateErrorLog(e.Message + "\n");
            }
        }
        public static List<Student> ReadFile(String path)
        {
            List<Student> students = new List<Student>();
            StringBuilder sb = new StringBuilder();

            FileInfo fi = new FileInfo(path);
            using (StreamReader stream = new StreamReader(fi.OpenRead()))
            {  //wywola .dispose() na koniec
                String line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    String[] tmp = line.Split(",");

                    if (tmp.Length == 9)
                    {
                        int i = 0;
                        do
                        {
                            if (String.IsNullOrEmpty(tmp[i]))
                                sb.Append("Pusta wartość w kolumnie" + line + "\n");
                            else
                                ++i;
                        }
                        while (i < tmp.Length && !String.IsNullOrEmpty(tmp[i]));

                        if (i == tmp.Length)
                        {
                            Student s = new Student(tmp[0], tmp[1], tmp[2], tmp[3], tmp[4], tmp[5], tmp[6], tmp[7], tmp[8]);
                            if (!students.Contains(s))
                                students.Add(s);
                            else
                                sb.Append("duplikat: " + line + "\n");
                        }
                    }
                    else
                        sb.Append("Niepoprawna ilość danych: " + line + "\n");
                }
            }

            CreateErrorLog(sb.ToString());

            return students;
        }

        public static void XmlSerialize(List<Student> students, String path)
        {
            FileStream writer = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                new XmlRootAttribute("uczelnia"));

            serializer.Serialize(writer, students);
        }

        public static void JsonSerialize(List<Student> students, String path)
        {
            String jsonString = JsonSerializer.Serialize(students);
            File.WriteAllText(path, jsonString);
        }

        public static void CreateErrorLog(String errors)
        {
            File.WriteAllText(@"łog.txt", errors);
        }
    }
}
