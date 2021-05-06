using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class EnemyDeathManager : MonoBehaviour
{
    public static int killBossNum=0;
    public static int killEnemyNum=0;
    public static int killBosALLNum = 0;
    public static int killEnemyALLNum = 0;

    private void Start()
    {
        killBosALLNum = PlayerPrefs.GetInt("killBosALLNum");
        if(killBosALLNum <= 0)
        {
            PlayerPrefs.SetInt("killBosALLNum", 0);
        }
        killEnemyALLNum = PlayerPrefs.GetInt("killEnemyALLNum");
        if (killEnemyALLNum <= 0)
        {
            PlayerPrefs.SetInt("killEnemyALLNum", 0);
        }

        killBossNum = 0;
        killEnemyNum = 0;

    }

    public void saveKillNum()
    {
        PlayerPrefs.SetInt("killBosALLNum", killBosALLNum);
        PlayerPrefs.SetInt("killEnemyALLNum", killEnemyALLNum);
        PlayerPrefs.Save();
    }

    
    public void setNewEnemyDeath()
    {
        killBosALLNum += killBossNum;
        killEnemyALLNum += killEnemyNum;
        var json = PlayerPrefs.GetString("game_info");//파일 이미 만들어져 있기 때문에 null처리안함
        
            TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        //일반 죽음 수
        if (TestUGUI.gameInfo != null)
        {
            var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == 2);
            if (foundMissionInfo != null)//이미 있다.
            {
                int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == 2);
                TestUGUI.gameInfo.missionInfos[index].doingVal = killEnemyALLNum;
            }
            else//아직없다.
            {
                Debug.Log("아직없다");
                TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(2, killEnemyALLNum));//없을경우 새로 만들어 넣는다.
            }

            //보스 죽음 수
            foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == 3);
            if (foundMissionInfo != null)//이미 있다.
            {
                int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == 3);
                TestUGUI.gameInfo.missionInfos[index].doingVal = killBosALLNum;
            }
            else//아직없다.
            {
                TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(3, killBosALLNum));//없을경우 새로 만들어 넣는다.
            }
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 string형태로 저장.

            saveKillNum();
            PlayerPrefs.SetString("game_info", gameInfoJson);
            PlayerPrefs.Save();
        }
    }

    
}
