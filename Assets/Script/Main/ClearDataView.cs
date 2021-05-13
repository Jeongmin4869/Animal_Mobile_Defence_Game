using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataView : MonoBehaviour
{
    public void onClickYesBtn()
    {
        PlayerPrefs.DeleteAll();
        //ClearDataView.SetActive(false);
        Application.Quit();
    }
    public void onClickNoBtn()
    {
        //ClearDataView.SetActive(false);
        Application.Quit();
    }
}
