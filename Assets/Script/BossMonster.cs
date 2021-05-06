using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
{

    public float maxShotDelay;//최대
    public float curShotDelay;//현재
    public float curSpawnDelay;
    bool plusTime = true;
    SpriteRenderer bossSpriteRenderer;
    public Sprite[] sprites;

    public GameObject meteorBullet;

    public int BossSkillCount = 2;

    private void Awake()
    {
        bossSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Reload();
        //나중에 캡슐화시킬예정!
        setSkillTime(plusTime);
        if (curSpawnDelay > 3f)
        {
            curSpawnDelay = 0;
            plusTime = false;
            bossSpriteRenderer.sprite = sprites[1]; // 인스펙터창에서 데미지 입었을 경우 이미지가 변하도록 설정
            Invoke("returnSprite", 0.3f);
            ranBossSkill();
        }

    }

        //1. 모두의 속력 높이기
        //2. 몬스터 대량으로 나오기
        //3. 랜덤으로 플레이어의 동물 죽이기

        void returnSprite()
    {
        bossSpriteRenderer.sprite = sprites[0];

    }

    //보스 스킬 랜덤으로 하나만 발생
    //확률이 너무 겹치고있음. 1이 너무 자주나온다 ㅜㅜ
    void ranBossSkill()
    {
        int ran = Random.Range(0, BossSkillCount);
        if (ran == 0)
            bossSkill_Meteor(); 
        else if (ran == 1)
            bossSkill_spawnEnemy();
    }

    void setSkillTime(bool a)
    {
        if (a)
        {
            curSpawnDelay += Time.deltaTime;
        }
    }



    void bossSkill_spawnEnemy()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.spawnEnemy();
        gameManager.spawnEnemy();
        gameManager.spawnEnemy();
    }

    void bossSkill_Meteor()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int ranPoint = Random.Range(0, gameManager.spawnPoints.Length);

        Instantiate(meteorBullet,
            gameManager.spawnPoints[ranPoint].position,
            gameManager.spawnPoints[ranPoint].rotation);
    }

    //일정 시간동안 스폰되는 몬스터의 이속이 빨라진다.
    void bossSkill_upSpeed()
    {

    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
        
    }

}
