using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygameCount 
{

    public void setPlaygameCount()
    {
        var playCount = PlayerPrefs.GetInt("GamePlayCount");
        playCount++;
        PlayerPrefs.SetInt("GamePlayCount", playCount);
        
        PlayerPrefs.Save();
    }

}
