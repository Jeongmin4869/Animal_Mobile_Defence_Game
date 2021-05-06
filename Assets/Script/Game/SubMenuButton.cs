using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public GameObject SubMenuView;

    public void onClickButton()
    {
        Time.timeScale = 0.0f;
        SubMenuView.SetActive(true);
    }
}
