using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class UnlockAnimalView : MonoBehaviour
{
    public GameObject unlockAnimalView;
    public Image AnimalImage;
    public Text subTextB;
    public Text subTextW;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            unlockAnimalView.SetActive(false);
        }
    }

    public void setImageAndText(int index)
    {
        var missionData = DataManager.GetInstance().GetData<MissionData>(index);
        subTextB.text = "새로운 동물 " + missionData.animal_name + " 해금!";
        subTextW.text = subTextB.text;
        AnimalImage.sprite = Resources.Load<Sprite>(string.Format("Animals/{0}", missionData.animal_sprite_name));
        Debug.Log("missionData.animal_sprite_name = " + missionData.animal_sprite_name);
        AnimalArr.callAnimalArr();
        
        /*array가 존재하지 않아서 에러가 났음. 미리 불러줌. 
         * 테스트할때는 이곳저곳에서 부르기 때문에 오류가 난것같다.
         실제 완성될때는 Main씬에서 시작할것이기 때문에 따로 부르지 않아도 될듯*/

        //var result = Array.Exists(AnimalArr.AnimalArray,i => i.Equals(missionData.animal_sprite_name));
        //여기서 해금한 동물친구를 선택할수 있도록 수정하는것.
        if (AnimalArr.AnimalArray.Contains(missionData.animal_sprite_name)==false) //해금한 동물이 해금된 동물들 리스트에 존재하지 않을 경우
        {
            AnimalArr.animalArrayString = string.Format("{0},{1}", AnimalArr.animalArrayString, missionData.animal_sprite_name);
            PlayerPrefs.SetString("AnimalArray", AnimalArr.animalArrayString);
            PlayerPrefs.Save();
            AnimalArr.callAnimalArr();
        }
    }



}
