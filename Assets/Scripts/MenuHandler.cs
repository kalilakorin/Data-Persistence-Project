using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{

    public TMPro.TMP_InputField playerName;

    public void Start()
    {
        playerName.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string playerName)
    {
        Debug.Log(playerName + " " + playerName.GetType());
        DataManager.Instance.setName(playerName);
    }

    public void StartGame()
    {
        DataManager.Instance.LoadScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //quit play mode
#else
        Application.Quit(); //quit unity player
#endif
    }
}
