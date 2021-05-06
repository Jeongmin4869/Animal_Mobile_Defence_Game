using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHP : MonoBehaviour
{
    int playerHP = 3; // HP다 사라졌을때 죽어야 게임오버 될 수 있도록
    //public GameObject[] HPtransforms;
    public Image[] HPImage;
    public GameObject GameOverView;
    private void Start()
    {
        string minute = DateTime.Now.ToString("mm");
        AnimalArr.callAnimalArr();
        int rannum = int.Parse(minute)%AnimalArr.AnimalArray.Length;
        Debug.Log("Image " + AnimalArr.AnimalArray[rannum]);
        //AnimalImage.sprite = Resources.Load<Sprite>(string.Format("Animals/{0}", missionData.animal_sprite_name));
        HPImage[0].sprite = Resources.Load<Sprite>(string.Format("Animals/{0}", AnimalArr.AnimalArray[rannum]));
        HPImage[1].sprite = Resources.Load<Sprite>(string.Format("Animals/{0}", AnimalArr.AnimalArray[rannum]));
        HPImage[2].sprite = Resources.Load<Sprite>(string.Format("Animals/{0}", AnimalArr.AnimalArray[rannum]));
    }

    public void MinusHP()
    {
        if (playerHP <= 0)
        {
            GameOverView.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Destroy(HPImage[playerHP - 1]);
            playerHP--;
        }
    }

    public int getHP()
    {
        return playerHP;
    }


}
