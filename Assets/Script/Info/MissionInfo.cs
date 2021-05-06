using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo 
{
    public int id; // 0=Coin, 1=PlayTime, 2=nomalEnemy, 3=BossEnemy, 4=readDeveloperInfo 
    public int doingVal;
    public bool clickedBtn;

    public MissionInfo(int id, int doingVal)
    {
        this.id = id;
        this.doingVal = doingVal;
        this.clickedBtn = false;
    }

}
