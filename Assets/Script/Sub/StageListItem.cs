using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageListItem : MonoBehaviour
{
    //별이아니라 스테이지마다 HP라던지, 보스 공격등을 다르게 할 예정.. 대공사예정...
    public GameObject lockImage; // 이전단계 클리어 시 다음 단계 unlock예정
    public GameObject FistStar; // 데이터 불러와서 상태에 따라 채워진 별로 바뀔 예정
    public GameObject SecondStar;
    public GameObject ThirdStar;
    public Button StageButton;
    public Text stageText;


    public void Init(int id)//int id, string missionSpriteName, string missionName, string animalName, int goalVal, int doingVal = 0)
    {
        stageText.text = "Stage " + (id + 1);
        if (PlayerPrefs.GetInt("unlockStage")   >= id)
        {
            //별 활성화
            lockImage.SetActive(false);
        }
        else
        {
            StageButton.enabled = false;
        }




        /*
        this.id = id;
        //this.iconMission.sprite = AssetManager.Instance.atlas.GetSprite(missionSpriteName);
        this.txtMissionName.text = missionName;//string.Format("", missionName);
        this.animalName.text = string.Format("도전과제를 성공해 {0} 해금하기", animalName);
        if (doingVal >= goalVal)
        {
            this.binderCliam.ChangeState(UIBinder_BtnCliam.eBtnState.Active);
        }
        */
        /*
        if(doingVal > 0)
        {
            var per = (float)doingVal / (float)goalVal;
            slider.value = per;
        }
        else
        {
            slider.value = 0;
        }
        */
    }

    public void onClick()
    {
        //여긴 주석이라 괜찮아 AnimalArr.callAnimalArr();
        GameObject.Find("AnimalSetting_P").transform.Find("AnimalSetting").gameObject.SetActive(true);
    }


}
