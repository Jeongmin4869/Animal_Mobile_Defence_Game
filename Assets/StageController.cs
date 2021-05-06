using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class StageController : MonoBehaviour
{
    public StageListItem listItemPrefabs;
    public RectTransform contents;
    public static GameInfo gameInfo;
    //public GameInfo Stage1Btn;
    //private List<StageListItem> stageListItems = new List<StageListItem>();

    // Start is called before the first frame update
    void Start()
    {
        //stage data 로드
        DataManager.GetInstance().LoadData<StageData>("Data/stage_data"); // 오류

        //info를 로드합니다
        //var json = PlayerPrefs.GetString("stage_info");

        
        /*
        if (string.IsNullOrEmpty(json)) // 저장된 파일이 없을경우 True반환
        {
            StageController.gameInfo = new GameInfo();
            
            //TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(0, 100));
            //데이터를 바꾸는 예시!
            //if (TestUGUI.gameInfo.missionInfos[0].id == 0)
            //    TestUGUI.gameInfo.missionInfos[0].doingVal = 200;
            
            var stageInfoJson = JsonConvert.SerializeObject(StageController.gameInfo);//json을 storing형태로 저장.
            PlayerPrefs.SetString("stage_info", stageInfoJson);
        }
        else
        {
            Debug.LogFormat("{0}", json);
            StageController.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        }
        // 주석 이건 안나


        for (int i = 0; i < 3; i++)
        {
            var listItem = this.CreateListItem();
            
            //이미지 세팅 이미지는 받아오기
            //별 세팅. PlayerPrefs로 설정하기.
            //false true세팅 ..  PlayerPrefs로 설정하기.
        }

        */

        ///밑에내용 코드들 전부 삭제하기
        //불러온 데이터에 따라 현재 버튼 상태를 다르게 줘야함.
        //불이 켜진 별이 생긴다던지, 해금한다던지
        //{T,F,F,F,F} 으로 설정?? 버튼마다 스크립트를 주는쪽으로 일단 생성 할 계획.
        //{"missionInfos":[{"id":2,"doingVal":0,"clickedBtn":false},{"id":3,"doingVal":0,"clickedBtn":false},{"id":0,"doingVal":10,"clickedBtn":false},{"id":1,"doingVal":2,"clickedBtn":false},{"id":4,"doingVal":1,"clickedBtn":false}]}
        //id:1,tatalval:0 .. 이런식으로 짜서 별 .. .할예정... 불러온 데이터와 비교해서 별 부여
    }


    private StageListItem CreateListItem()
    {
        var listItemGo = Instantiate(this.listItemPrefabs);
        listItemGo.transform.SetParent(contents, false);
        return listItemGo.GetComponent<StageListItem>();
    }

}
