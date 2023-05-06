using Assets.Scripts.Models;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private const string _SAVEFILE_PATH = "/savefile.json";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    public void SaveColor()
    {
        SaveData data = new SaveData
        {
            TeamColor = TeamColor
        };

        File.WriteAllText(Application.persistentDataPath + _SAVEFILE_PATH, JsonUtility.ToJson(data));
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + _SAVEFILE_PATH;
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}