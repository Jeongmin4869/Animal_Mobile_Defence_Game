using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalAdd : MonoBehaviour
{
    public GameObject GameOverView;
    public Button AnimalAddButton; // Animal+버튼
    public Transform[] AllAnimals;
    private Transform[] Animals = new Transform[3]; // 설정된 동물 3개만
    public List<Transform> AnimalList = new List<Transform>();
    public Text DisNeedGold; // Animal생성할 때 필요한 골드 표시 text
    private int NeedGold = 10; // Animal생성할 때 필요한 골드 수
    private float[] GroundX = { -2.057f, -1.592f, -1.127f, -0.669f, -0.2154824f, 0.2433135f, 0.7021092f, 1.167554f, 1.629f, 2.091795f }; // Ground 위치 x좌표
    public bool[] GroundOK = { true, true, true, true, true, true, true, true, true, true }; // Ground 위에 동물 생성 가능한지 확인하기 위한 배열
    public int isGroundNumber = 10; // 생성 가는한 Ground 수
    public static int TotalAnimal = 0;

    void Start()
    {
        // Animal+버튼 OnCLick 이벤트 설정
        AnimalAddButton = this.transform.GetComponent<Button>();
        if (AnimalAddButton)
        {
            AnimalAddButton.onClick.AddListener(AnimalAddButtonClick);
        }
        else
        {
            Debug.Log("AddButtonMissing");
        }

        Debug.Log("CompletionBtnClick : " + CompletionBtnClick.AnimalNumber1 + " " + CompletionBtnClick.AnimalNumber2 + " " + CompletionBtnClick.AnimalNumber3);
        // 동물설정
        Animals[0] = AllAnimals[CompletionBtnClick.AnimalNumber1];
        Animals[1] = AllAnimals[CompletionBtnClick.AnimalNumber2];
        Animals[2] = AllAnimals[CompletionBtnClick.AnimalNumber3];
    }

    private void Update()
    {
        checkGameover();
    }

    // Animal+버튼 OnClick 이벤트
    void AnimalAddButtonClick()
    {
        Player_Coin player_Coin = GameObject.Find("Player_Coin").GetComponent<Player_Coin>();
        if (Player_Coin.coin_score >= NeedGold)
        {
            /*
        AnimalArr.callAnimalArr();
        for (int i = 0; i < AnimalArr.AnimalArray.Length; i++)
        {
            //파일위치, 파일이름 바꾸면 오류.
            string name = string.Format("Hyeonji/Prefabs/Animals/{0}/{1}", AnimalArr.AnimalArray[i], AnimalArr.AnimalArray[i]);
            GameObject obj = Resources.Load(name) as GameObject;
            AnimalList.Add(obj.transform);
        }
        Animals = AnimalList.ToArray();
        */

            // 랜덤한 동물 (★동물 수 변경)
            int RandomAnimal = Random.Range(0, Animals.Length);
            // 랜덤한 위치
            int RandomX = Random.Range(0, 10);
            if (GroundOK[RandomX] == true) // 생성 가능한 Ground이면
            {
                if (Player_Coin.coin_score >= NeedGold)
                {
                    setCoin();
                    makeAnimal(RandomAnimal, RandomX);
                    isGroundNumber--;
                    TotalAnimal++;
                }
            }
            else // 아니면 다른 생성 가능한 Ground에 생성
            {
                if (isGroundNumber == 0) // 생성 가능한 Ground 없음
                {
                    Debug.Log("생성불가능");
                }
                else // 생성 가능한 Ground가 있음.
                {
                    while (true)
                    {
                        RandomX = Random.Range(0, 10);
                        if (GroundOK[RandomX] == true)
                        { // 생성 가능한 Ground발견
                            isGroundNumber--;
                            TotalAnimal++;
                            break;
                        }
                    }
                    setCoin();
                    makeAnimal(RandomAnimal, RandomX);
                }
            }
        }
    }

    
    void checkGameover()
    {
        /*
         도중에 게임오버 조건
         1. 생성 가능한 땅 있음. 
         2. 생성되어있는 동물이 없고(TotalAnimal)
         3. 돈이 부족해 동물을 생성 할 수 없을 경우 (Player_Coin.coin_score < NeedGold).
        */

        if (TotalAnimal == 0 && Player_Coin.coin_score < NeedGold)
        {
            //게임오버
            GameOverView.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }


    void setCoin()
    {
        Player_Coin player_Coin = GameObject.Find("Player_Coin").GetComponent<Player_Coin>();
        Player_Coin.coin_score -= NeedGold;
        player_Coin.coin_text_obj.text = "" + Player_Coin.coin_score;
    }

    void makeAnimal(int ranAnimal, int ranX)
    {
        Instantiate(Animals[ranAnimal], new Vector3(GroundX[ranX], -3.41f, 0), Quaternion.identity); // ranAnimal : 랜덤 동물, ranX : 랜덤 위치
        GroundOK[ranX] = false; // Ground생성 불가능 표시
        NeedGold = NeedGold + 10; // 필요 골드 10 증가
        DisNeedGold.text = NeedGold.ToString(); // text 변경
    }

    public void falseGround(int i)
    {
        Debug.Log("kill "+ i);
        GroundOK[i] = false;
        isGroundNumber--;
    }

}
