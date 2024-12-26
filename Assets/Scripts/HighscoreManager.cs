using System.IO;
using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    public string highscoreName = "";
    public string currentUsername = "";
    public int highscore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetScoreText()
    {
        return "Best Score: " + highscoreName + " : " + highscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.HighscoreName = highscoreName;
        data.Highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.Highscore;
            highscoreName = data.HighscoreName;
        } else
        {
            highscoreName = currentUsername;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string HighscoreName;
        public int Highscore;
    }
}
