using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageListItem : MonoBehaviour
{
    //별이아니라 스테이지마다 HP라던지, 보스 공격등을 다르게 할 예정.. 대공사예정...
    public GameObject lockImage; // 이전단계 클리어 시 다음 단계 unlock예정
    public GameObject leftStar; // 데이터 불러와서 상태에 따라 채워진 별로 바뀔 예정
    public GameObject rightStar;
    public GameObject centerStar;
    public Button StageButton;
    public Text stageText;
    public GameObject[] StageImage;

    public string stageStar_tx;
    public int starCount;
    public void Init(int id)//int id, string missionSpriteName, string missionName, string animalName, int goalVal, int doingVal = 0)
    {

        stageText.text = "Stage " + (id + 1);
        StageImage[id].SetActive(true);

        //캡술화 하기
        if (PlayerPrefs.GetInt("unlockStage")   >= id)
        {
            //별 활성화
            lockImage.SetActive(false);
            stageStar_tx = string.Format("Stage{0}Star", (id+1) );// Stage1Star
            starCount = PlayerPrefs.GetInt(stageStar_tx);

            StageButton.onClick.AddListener(() => click_btn(id));

            Debug.Log(stageStar_tx + " starCount = " + starCount);

            if (starCount >= 1)
            {
                leftStar.SetActive(true);
            }
            if (starCount >= 2)
            {
                rightStar.SetActive(true);
            }
            if (starCount >= 3)
            {
                centerStar.SetActive(true);
            }


        }
        else
        {
            StageButton.enabled = false;
        }

    }

    public void click_btn(int id)
    {
        Debug.Log("id = " + id);
        PlayerPrefs.SetInt("StageLevel", id);
        PlayerPrefs.Save();
        GameObject.Find("AnimalSetting_P").transform.Find("AnimalSetting").gameObject.SetActive(true);
    }

}
