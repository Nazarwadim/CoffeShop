using System.IO;
using UnityEngine;

public class JsonSaver<T> where T : class
{
    private static readonly string DataPath = Application.persistentDataPath;

    public static void Save(T data, string fileName)
    {
        string path = Path.Combine(DataPath, typeof(T).Name + fileName + ".json");
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static bool TryLoad(string fileName, out T data)
    {
        string path = Path.Combine(DataPath, typeof(T).Name + fileName + ".json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<T>(json);
            return true;
        }
        else
        {
            data = null;
            return false;
        }
    }
}
