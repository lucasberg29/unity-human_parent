using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSettings
{
    public static void LoadSceneMode(string level)
    {
        SceneManager.LoadScene(level);
    }
}
