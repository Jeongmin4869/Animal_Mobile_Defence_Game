using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBtn : MonoBehaviour
{
    public void onClickBtn()
    {
        PlayerPrefs.DeleteAll();
    }
}
