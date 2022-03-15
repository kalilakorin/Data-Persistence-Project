using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    //public InputField playerName;

    public TMPro.TMP_InputField playerName;

    public void Start()
    {
        playerName.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string name)
    {
        //Debug.Log(name);
        DataManager.Instance.Name = name;
    }

    public void StartGame()
    {
        //playerName.
        //MainManager.Instance.HighScoreName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //quit play mode
#else
        Application.Quit(); //quit unity player
#endif
    }
}
