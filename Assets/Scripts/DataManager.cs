using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int highScore;
    public string highScorePlayerName;
    private string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void setName(string name)
    {
        playerName = name;
    }

    public void setHighScore(int score)
    {
        highScore = score;
        highScorePlayerName = playerName;
        SaveScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string PlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = highScore;
        data.PlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.HighScore;
            highScorePlayerName = data.PlayerName;
        }        
    }
}
