using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearView : MonoBehaviour
{
    PlayerHP playerHP;
    Player_Coin player_Coin;

    public int hp;
    public int coin;

    public int stageLevel;
    public int unlockStage;
    public int starCount;

    public GameObject leftStar;
    public GameObject rightStar;
    public GameObject centerStar;




    private void Start()
    {
        playerHP = GameObject.Find("PlayerHP").GetComponent<PlayerHP>();
        player_Coin = GameObject.Find("Player_Coin").GetComponent<Player_Coin>();
        
        hp = playerHP.getHP();
        coin = player_Coin.getCoin_Score();

        leftStar.SetActive(true);

        starCount = 1;

        //클리어했으면 왼별
        if (hp >= 3) // hp를 모두 남겼으면 오른별
        {
            rightStar.SetActive(true);
            starCount++;
            //오른별세팅
            if (coin >= 200) // 코인을 200이상 남기고 클리어할경우 가운데별 
            {
                centerStar.SetActive(true);
                starCount++;
                //중앙별 세팅
            }
        }
        
        stageLevel = PlayerPrefs.GetInt("StageLevel");

        if (stageLevel == 0)
        {
            unlockStage = 2;
            PlayerPrefs.SetInt("unlockStage",1);
            PlayerPrefs.SetInt("Stage1Star", starCount);
            PlayerPrefs.Save();
            //별저장
        }

        if (stageLevel == 1)
        {
            PlayerPrefs.SetInt("unlockStage", 2);
            PlayerPrefs.SetInt("Stage2Star", starCount);
            PlayerPrefs.Save();
        }

        if (stageLevel == 2)
        {
            PlayerPrefs.SetInt("Stage3Star", starCount);
            PlayerPrefs.Save();
        }

        //세팅 저장
        //해금하기. (json으로 저장해서, sub씬으로 갔을때 불러오도록...)

    }

    public void onClickBtn()
    {
        Time.timeScale = 1.0f;
        //if 지금 레벨과 스테이지 레벨 비교해 스테이지 개방
        SceneManager.LoadScene("Sub");
    }
}
