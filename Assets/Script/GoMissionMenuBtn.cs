using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class GoMissionMenuBtn : MonoBehaviour
{
   public GameObject MissionMenuView;
   
   public void onClickGoMissionMenuBtn()
    {
        SettingMissionData();
        MissionMenuView.SetActive(true);
    }

   public void SettingMissionData()
    {

        //GameObject.Find("EnemyDeathManager").GetComponent<EnemyDeathManager>().setNewEnemyDeath();
        GameObject.Find("TestUGUI").GetComponent<TestUGUI>().setGamePlayCount(); // 정상
        GameObject.Find("TestUGUI").GetComponent<TestUGUI>().setReadDeveloperInfo(); 
        GameObject.Find("TestUGUI").GetComponent<TestUGUI>().testUBUISetting();
    }

}
