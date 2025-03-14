using System.IO;
using UnityEngine;

public class DataManager<T>
{
    private static readonly string DataPath = $"{Application.companyName}/{Application.productName}/";

    private static readonly string FileName = typeof(T).Name + ".json";

    private static readonly string SavePath = DataPath + FileName;

    public static void Save(T data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
    }

    public static T Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            T data = JsonUtility.FromJson<T>(json);
            return data;
        }
        else
        {
            throw new FileLoadException("Json file not found");
        }
    }

    public static bool CanLoad() 
    {
        return File.Exists(SavePath);
    }
}
