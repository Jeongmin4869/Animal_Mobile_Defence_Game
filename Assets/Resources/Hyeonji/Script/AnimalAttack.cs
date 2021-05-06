using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttack : MonoBehaviour
{
    public GameObject Weaponpf; // 무기 프리팹
    private Rigidbody2D rigid;
    private Vector3 firstPosition; // 오브젝트 처음 위치 저장
    public float maxShotDelay; // 공격 속도(쏘는데 걸리는 시간, 낮을 수록 빠름)
    private float curShotDelay;

    void Start()
    {
        // 오브젝트 처음 위치 저장
        firstPosition = this.transform.position;
    }

    void Update()
    {
        Attack();
        ShotDelay();
    }
    // 무기로 공격
    private void Attack()
    {
        float minLen = 2000.0f;
        int minIndex = 0;

        if (curShotDelay < maxShotDelay)
            return;

        GameObject weapon = Instantiate(Weaponpf, firstPosition, transform.rotation); // 무기 생성
        Rigidbody2D rigid = weapon.GetComponent<Rigidbody2D>();

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // Enemy Tag로 적들 찾기
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss"); // Enemy Tag로 적들 찾기
        GameObject[] finalbosses = GameObject.FindGameObjectsWithTag("FinalBoss"); // Enemy Tag로 적들 찾기
        var enemyList = new List<GameObject>();
        enemyList.AddRange(enemys);
        enemyList.AddRange(bosses);
        enemyList.AddRange(finalbosses);

        if (enemyList.Count == 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // 적이 없으면 위를 향해 
        }
        else
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].transform.position.y > -3.8) // 땅보다 위
                {
                    if (minLen > enemyList[i].transform.position.y)
                    {
                        minLen = enemyList[i].transform.position.y;
                        minIndex = i;
                    }
                }
            }
            Vector2 target = enemyList[minIndex].transform.position;
            Vector2 me = gameObject.transform.position;
            float angle = Mathf.Atan2(target.y - me.y, target.x - me.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); // 적을 향해 회전
        }
        rigid.AddRelativeForce(Vector2.up * 20, ForceMode2D.Impulse); // 공격

        curShotDelay = 0;
    }

    private void ShotDelay()
    {
        curShotDelay += Time.deltaTime;
    }
}
