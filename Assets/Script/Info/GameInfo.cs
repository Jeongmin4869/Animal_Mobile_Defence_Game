using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo 
{
    public List<MissionInfo> missionInfos;
    public List<StageInfo> stageInfos;

    public GameInfo()
    {
        this.missionInfos = new List<MissionInfo>();
        this.stageInfos = new List<StageInfo>();
    }
}
