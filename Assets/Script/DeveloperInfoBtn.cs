using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DeveloperInfoBtn : MonoBehaviour
{

    public GameObject DeveloperInfoView;

    public void onClick_DeveloperInfo_Btn()
    {
        DeveloperInfoView.SetActive(true);
        PlayerPrefs.SetInt("readDeveloperInfo", 1);
        PlayerPrefs.Save();
    }

}
