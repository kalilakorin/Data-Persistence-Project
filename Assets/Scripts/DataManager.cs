using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public Text HighScore;
    public string Name;

    [System.Serializable]
    class SaveData
    {
        public Text HighScore;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.Name = Name;

        /*int highScore = System.Convert.ToInt32(HighScore); //int.Parse(HighScore.ToString());

        if (m_Points > highScore)
        {
            HighScore.text = m_Points.ToString();
        }*/

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

            HighScore = data.HighScore;
            Name = data.Name;
        }

        //HighScore.text = "Best score: " + Instance.HighScore + "-" + Instance.HighScoreName;
    }
}
