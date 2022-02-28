using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.UI;

public class MissionListItem : MonoBehaviour
{
    public Image iconMission;
    public Text txtMissionName;
    public Text animalName;
    public Image icoReward;
    public Text txtRewardVal;
    public Button btnClaim;
    public UIBinder_BtnCliam binderCliam;
    public int id;

    public Slider slider;

    private GameObject UnlockAnimalView;

    public void Init(int id, string missionSpriteName, string missionName,string animalName, int goalVal,int doingVal = 0)
    {
        this.id = id;
        this.txtMissionName.text = missionName;
        this.animalName.text = string.Format("도전과제를 성공해 {0} 해금하기", animalName);
        if (doingVal >= goalVal)
        {
            this.binderCliam.ChangeState(UIBinder_BtnCliam.eBtnState.Active);
        }
    }

    public void Click_UnlockBtn()
    {

        GameObject.Find("U_Animal_P").transform.Find("UnlockAnimalView").gameObject.SetActive(true);
        //UnlockAnimalView.SetActive(true);
    }

}
