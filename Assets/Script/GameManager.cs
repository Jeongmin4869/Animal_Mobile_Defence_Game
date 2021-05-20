using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public GameObject bossObj;
    public GameObject Final_bossObj;

    public float maxSpqwnDelay;
    public float curSpawnDelay; // 현재 흐르고 있는 시간
    public float bossSpawnDelay;
    public float spawnSpeed = 0.7f;
    //public float playTime;

    public int playerPoint;

    public int Enemy_HP;
    public int spawnCount = 0;
    public int spawnBossCount = 0;

    public bool callEnemy = true;

    public GameObject clearView;
    public GameObject[] stageImage;

    //public Text Coin_score;//Coin의 점수

    private void Start()
    {
        var stageLevel = PlayerPrefs.GetInt("StageLevel");
        spawnSpeed = 0.8f - stageLevel * 0.1f; // 
        stageImage[stageLevel].SetActive(true);
        Enemy_HP = 0;
        curSpawnDelay = 0;
    }

    private void Update()
    {
        curSpawnDelay += Time.deltaTime;
        bossSpawnDelay += Time.deltaTime;
        //playTime += Time.deltaTime;
        if (callEnemy)
        {
            //적 스폰 시간
            if (curSpawnDelay > maxSpqwnDelay)
            {
                spawnEnemy();
                //maxSpqwnDelay = Random.Range(0.5f, 3f); // 랜덤시간으로 생성.

                curSpawnDelay = 0;
                spawnCount++;
                if (spawnCount % 3 == 0)
                {
                    if (maxSpqwnDelay >= spawnSpeed)
                    {
                        maxSpqwnDelay -= 0.1f;
                    }
                }
            }

            //보스 스폰 시간
            if (bossSpawnDelay > 30f + spawnBossCount * 5f)
            {
                spawnBoss();
                bossSpawnDelay = 0;
                spawnBossCount++;

                if (spawnBossCount >= 5)
                {

                    callEnemy = false;
                    Invoke("spawnFinalBoss", 5); // 2초뒤 LaunchProjectile함수 호출
                    //보스 호출
                }

            }
        }
    }

    void spawnFinalBoss()
    {
        //getvalue
        int ranPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(Final_bossObj,
            spawnPoints[4].position,
            spawnPoints[4].rotation);
    }


    void spawnBoss()
    {
        //getvalue
        int ranPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(bossObj,
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);
    }

    public void spawnEnemy()
    {
        int ranEnemey = Random.Range(0, enemyObjs.Length); // 지금 적이 보스와 일반 몬스터 뿐
        int ranPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyObjs[ranEnemey], 
            spawnPoints[ranPoint].position, 
            spawnPoints[ranPoint].rotation);

        Enemy_HP += 1;

    }

    public void GameClear()
    {
        clearView.SetActive(true);
    }
}

