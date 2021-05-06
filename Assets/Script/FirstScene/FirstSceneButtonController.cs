using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneButtonController : MonoBehaviour
{
    public GameObject ClearDataView;
    public GameObject DeveloperInfoView;
    public GameObject PlayerScoreVIew;

    public void onClickClearDataBtn()
    {
        ClearDataView.SetActive(true);
    }

    public void onClickCancleBtn()
    {
        DeveloperInfoView.SetActive(false);
    }

    public void onClickYesBtn()
    {
        PlayerPrefs.DeleteAll();
        ClearDataView.SetActive(false);
        Application.Quit();
    }
    public void onClickNoBtn()
    {
        ClearDataView.SetActive(false);
        Application.Quit();
    }

    public void onClickPlayerScoreBtn()
    {
        PlayerScoreVIew.SetActive(true);
    }

}
