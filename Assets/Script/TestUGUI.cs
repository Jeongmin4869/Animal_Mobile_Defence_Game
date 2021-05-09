using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;


public class TestUGUI : MonoBehaviour
{

    public MissionListItem listItemPrefabs;
    public RectTransform contents;
    public static GameInfo gameInfo;
    private List<MissionListItem> missionListItems = new List<MissionListItem>();
    public static int clearmissionNum = 0;
    public int GamePlayCount;
    public int readDeveloperCount = 0;
    void Start()
    {
        //데이터 로드
        //게임 시작할때마다 로드될것이기 때문에, 나중에 게임 시작??? 할때 생성하던가
        //예외문을 만들기....
        //만약 없으면 로드하도록
        //겟 데이타 없으면 로드??
        DataManager.GetInstance().LoadData<MissionData>("Data/mission_data");
        DataManager.GetInstance().LoadData<StageData>("Data/stage_data");
        testUBUISetting();
        GamePlayCount = PlayerPrefs.GetInt("GamePlayCount");
    }

    public void testUBUISetting()
    {
        //데이터 삭제
        clearmissionNum = 0;

        //info를 로드합니다
        var json = PlayerPrefs.GetString("game_info");

        if (string.IsNullOrEmpty(json)) // 저장된 파일이 없을경우 True반환
        {
            TestUGUI.gameInfo = new GameInfo();
            /*
            TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(0, 100));
            //데이터를 바꾸는 예시!
            if (TestUGUI.gameInfo.missionInfos[0].id == 0)
                TestUGUI.gameInfo.missionInfos[0].doingVal = 200;
            */
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
            PlayerPrefs.SetString("game_info", gameInfoJson);
        }
        else
        {
            Debug.LogFormat("{0}", json);
            TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);

        }


        //데이터 불러와야할부분.


        //리스트 아이템 생성부분.
        DeleteChilds();
        missionListItems.Clear();

        for (int i = 0; i < 5; i++)
        {
            var listItem = this.CreateListItem();
            //missionListItems.Clear();
            missionListItems.Add(listItem);
            listItem.btnClaim.onClick.AddListener(() =>
            {
                this.Claim(listItem.id);
            });

            var missionData = DataManager.GetInstance().GetData<MissionData>(i);
            var MissionName = string.Format(missionData.mission_name, missionData.goal_val.ToString("#,###"));

            if (TestUGUI.gameInfo != null)
            {
                var foundMission = TestUGUI.gameInfo.missionInfos.Find(x => x.id == missionData.id);
                if (foundMission != null)
                {
                    listItem.Init(foundMission.id, missionData.sprite_name, MissionName, missionData.animal_name, missionData.goal_val, foundMission.doingVal);
                }
                else
                {
                    listItem.Init(missionData.id, missionData.sprite_name, MissionName, missionData.animal_name, missionData.goal_val);
                }
            }
            else
            {
                listItem.Init(missionData.id, missionData.sprite_name, MissionName, missionData.animal_name, missionData.goal_val);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            setMissionBtnState(i);
        }

    }

    // 클릭이벤트
    private void Claim(int id) // 인덱스 오류 ArgumentNullException: Value cannot be null.Parameter name: source
    {

        var missionData = DataManager.GetInstance().GetData<MissionData>(id);
        var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == id);

        if (foundMissionInfo != null)
        {
            if (foundMissionInfo.doingVal >= missionData.goal_val)
            {
                //해당 리스트 아이템의 버튼 상태를 바꿔준다.
                var foundListItem = missionListItems.Find(x => x.id == foundMissionInfo.id);
                if (foundListItem != null)
                {
                    //여기까진 잘 돌아감
                    //GameObject.Find("UnlockAnimalView").GetComponent<UnlockAnimalView>().setImageAndText(id);
                    GameObject.Find("U_Animal_P").transform.Find("UnlockAnimalView").gameObject.SetActive(true);// UnlockAnimalView 를 active
                    GameObject.Find("UnlockAnimalView").GetComponent<UnlockAnimalView>().setImageAndText(id);

                    foundListItem.binderCliam.ChangeState(UIBinder_BtnCliam.eBtnState.Success);//버튼의 상태를 바꿔준다... 
                    int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == id);
                    TestUGUI.gameInfo.missionInfos[index].clickedBtn = true;
                    var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
                    PlayerPrefs.SetString("game_info", gameInfoJson);
                    PlayerPrefs.Save();
                }
            }
        }

    }

    //버튼상태설정
    private void setMissionBtnState(int index)
    {
        //var missionData = DataManager.GetInstance().GetData<MissionData>(id);//리스트에서 클릭한것.
        var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == index); // id가 i인것을 찾음.
        if (foundMissionInfo != null)
        {
            if (foundMissionInfo.clickedBtn == true)
            {
                //해당 리스트 아이템의 버튼 상태를 바꿔준다.
                var foundListIten = missionListItems.Find(x => x.id == foundMissionInfo.id);
                //int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == foundListIten.id);
                //foundListIten = missionListItems.Find(x => x.id == index);
                if (foundListIten != null)
                {
                    Debug.LogFormat("{0} {1}", index, foundListIten);
                    foundListIten.binderCliam.ChangeState(UIBinder_BtnCliam.eBtnState.Success);
                    clearmissionNum++;
                }
            }
        }
    }

    private MissionListItem CreateListItem()
    {
        var listItemGo = Instantiate(this.listItemPrefabs);
        listItemGo.transform.SetParent(contents, false);
        return listItemGo.GetComponent<MissionListItem>();
    }

    public void DeleteChilds()
    {
        Transform allChildren = contents.GetComponentInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            // 자기 자신의 경우엔 무시 
            // (게임오브젝트명이 다 다르다고 가정했을 때 통하는 코드)
            if (child.name == transform.name)
                return;
            Destroy(child.gameObject);
        }
    }

    public void setGamePlayCount()
    {
        var json = PlayerPrefs.GetString("game_info");//파일 이미 만들어져 있기 때문에 null처리안함
        TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        //일반 죽음 수
        if (TestUGUI.gameInfo != null)
        {
            var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == 1);
            if (foundMissionInfo != null)//이미 있다.
            {
                int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == 1);
                TestUGUI.gameInfo.missionInfos[index].doingVal = GamePlayCount;
            }
            else//아직없다.
            {
                Debug.Log("아직없다");
                TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(1, GamePlayCount));//없을경우 새로 만들어 넣는다.
            }
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 string형태로 저장.
            PlayerPrefs.SetString("game_info", gameInfoJson);
            PlayerPrefs.Save();
        }
    }

    public void setReadDeveloperInfo()
    {
        readDeveloperCount = PlayerPrefs.GetInt("readDeveloperInfo"); // 없으면 0
        Debug.Log("readDeveloperCount " + readDeveloperCount);
        var json = PlayerPrefs.GetString("game_info");//파일 이미 만들어져 있기 때문에 null처리안함
        TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == 4);
        if (foundMissionInfo == null)//이미 있다.
        {
            TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(4, readDeveloperCount));//없을경우 새로 만들어 넣는다.
            
        }
        else
        {
            int index = TestUGUI.gameInfo.missionInfos.FindIndex(x => x.id == 4);
            TestUGUI.gameInfo.missionInfos[index].doingVal = readDeveloperCount; 
            
        }
        var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
        PlayerPrefs.SetString("game_info", gameInfoJson);
        PlayerPrefs.Save();
    }
}
