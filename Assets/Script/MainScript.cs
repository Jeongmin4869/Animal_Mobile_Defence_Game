using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainScript : MonoBehaviour
{

    public GameObject simpleMonster;
    public GameObject bossMonster;

    //현재시간
    float currentTime; // 0으로 맞춰야하나?
    //일정시간
    public float createTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

   
        
    }

    // Update is called once per frame
    void Update()
    {
        createMonster();
    }

   
    void createMonster()
    {
        //시간이 흐른다.
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            //적 공장에서 적을 생성한다.
        }
    }


}
