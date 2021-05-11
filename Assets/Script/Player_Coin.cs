using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class Player_Coin : MonoBehaviour
{

    public static int coin_score = 10; // 모두 공유.
    public Text coin_text_obj;
    public static int total_coin_score = 0;
    //public static GameInfo gameInfo;


    void Start()
    {
        coin_score = 10;

        total_coin_score = PlayerPrefs.GetInt("total_coin_score");
        if (total_coin_score <= 0)
        {
            PlayerPrefs.SetInt("total_coin_score", 0);
            PlayerPrefs.Save();
        }

        coin_text_obj.text = "" + coin_score;
    }


    public void setNowPlayerCoin()
    {
        //데이터를 읽어온다.
        

        var json = PlayerPrefs.GetString("game_info");//파일 이미 만들어져 있기 때문에 null처리안함
        TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        if (TestUGUI.gameInfo != null)
        {
            var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == 0);
            if (foundMissionInfo != null)//이미 있다.
            {
                int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == 0);
                TestUGUI.gameInfo.missionInfos[index].doingVal = total_coin_score;
            }
            else//아직없다.
            {
                TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(0, total_coin_score));//없을경우 새로 만들어 넣는다.
            }
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
            PlayerPrefs.SetString("game_info", gameInfoJson);
            PlayerPrefs.SetInt("total_coin_score", total_coin_score);
            PlayerPrefs.Save();
        }

    }

    public int getCoin_Score()
    {
        return coin_score;   
    }


}
