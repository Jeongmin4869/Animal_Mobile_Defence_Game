using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    public static int GamePlayCount = 0;

    private void Start()
    {
        GamePlayCount = PlayerPrefs.GetInt("GamePlayCount");
        if (GamePlayCount <= 0)
        {
            PlayerPrefs.SetInt("GamePlayCount", 0);
            PlayerPrefs.Save();
        }
    }

    public void onClickStartGameBtn(){
        GamePlayCount++;
        PlayerPrefs.SetInt("GamePlayCount", GamePlayCount);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    
}
