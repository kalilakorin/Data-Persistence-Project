using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitHandler : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //quit play mode
#else
        Application.Quit(); //quit unity player
#endif
    }
}
