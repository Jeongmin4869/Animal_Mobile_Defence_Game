using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenu : MonoBehaviour
{
    public GameObject SubMenuView;

    public void onClickStartBtn()
    {
        SubMenuView.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void onClickGoMenuBtn()
    {   
        GameObject.Find("EnemyDeathManager").GetComponent<EnemyDeathManager>().setNewEnemyDeath();
        SceneManager.LoadScene("Sub");
        Time.timeScale = 1.0f;
    }
}
