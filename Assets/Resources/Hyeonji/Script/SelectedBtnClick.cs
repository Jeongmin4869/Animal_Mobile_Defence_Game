using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedBtnClick : MonoBehaviour
{
    public Sprite XSprite;
    private Image myImage;

    private void Start()
    {
        myImage = GetComponent<Image>();
    }

    // SelectedBtn 클릭시 동물 빠지게
    public void ChangeImage()
    {
        PossibleSelected(myImage.sprite.name);
        myImage.sprite = XSprite; 
    }

    // 빠진 동물은 다시 등록 할 수 있게 isSelected를 true로
    private void PossibleSelected(string img)
    {
        switch (img)
        {
            case "dogImg":
                GameObject.Find("DogBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "elephantImg":
                GameObject.Find("ElephantBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "giraffeImg":
                GameObject.Find("GiraffeBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "hippoImg":
                GameObject.Find("HippoBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "monkeyImg":
                GameObject.Find("MonkeyBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "pandaImg":
                GameObject.Find("PandaBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "parrotImg":
                GameObject.Find("ParrotBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "penguinImg":
                GameObject.Find("PenguinBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "pigImg":
                GameObject.Find("PigBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
            case "snakeImg":
                GameObject.Find("SnakeBtn").GetComponent<AnimalBtnClick>().isSelected = true;
                return;
        }
    }

}
