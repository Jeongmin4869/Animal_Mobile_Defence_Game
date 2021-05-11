using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletionBtnClick : MonoBehaviour
{
    public Button SelectedBtn1;
    public Button SelectedBtn2;
    public Button SelectedBtn3;
    public static int AnimalNumber1;
    public static int AnimalNumber2;
    public static int AnimalNumber3;
    public Button CompletionBtn;

    private void Start()
    {

    }

    public void Update()
    {
        CompletionBtn.interactable = false;

        if (SelectedBtn3.image.sprite.name != "XbtnImg") // 모든 동물을 선택했을때만 게임이 실행되도록
        {
            CompletionBtn.interactable = true;
        }
    }

    public void SettingCompleted()
    {
        //동물 셋팅
        AnimalNumber1 = AnimalNumberFX(SelectedBtn1.image.sprite.name);
        AnimalNumber2 = AnimalNumberFX(SelectedBtn2.image.sprite.name);
        AnimalNumber3 = AnimalNumberFX(SelectedBtn3.image.sprite.name);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
        // 여기서 게임 씬으로 넘어가도록 .. 

    }


    // SelectedBtn에 있는 이미지 이름을 숫자로 반환
    private int AnimalNumberFX(string AnimalImg)
    {
        int n = 0;
        switch (AnimalImg)
        {
            case "dogImg":
                n = 0; 
                return 0;
            case "elephantImg":
                n = 1;
                return n;
            case "giraffeImg":
                n = 2;
                return n;
            case "hippoImg":
                n = 3;
                return n;
            case "monkeyImg":
                n = 4;
                return n;
            case "pandaImg":
                n = 5;
                return n;
            case "parrotImg":
                n = 6;
                return n;
            case "penguinImg":
                n = 7;
                return n;
            case "pigImg":
                n = 8;
                return n;
            case "snakeImg":
                n = 9;
                return n;
        }
        return n;
    }
}
