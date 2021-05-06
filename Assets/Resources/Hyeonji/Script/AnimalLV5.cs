using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLV5 : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 firstPosition; // 오브젝트 처음 위치 저장
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        // 오브젝트 처음 위치 저장
        firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast 확인
        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));
    }

    // 마우스 클릭
    private void OnMouseDown()
    {
    }

    // 마우스 드래그
    private void OnMouseDrag()
    {
        // 마우스 드래그하는 동안 위치를 오브젝트에 넣어줌, 물체가 포인터에 따라옴
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        this.transform.position = mousePosition;
    }

    // 마우스를 놓을 때
    private void OnMouseUp()
    {
        // RaycastAll 아래로 확인
        RaycastHit2D[] rayDown = Physics2D.RaycastAll(rigid.position, Vector3.down, 1);
        this.transform.position = firstPosition;
    }
    void updateGround(int n)
    {
        GameObject.Find("AnimalAdd").GetComponent<AnimalAdd>().GroundOK[n] = true;
        GameObject.Find("AnimalAdd").GetComponent<AnimalAdd>().isGroundNumber++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이나 보스랑 부딪히면 사라짐
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "MeteorBullet" || collision.gameObject.tag == "FinalBoss")
        {
            Destroy(gameObject);
            switch (firstPosition.x)
            {
                case -2.057f:
                    updateGround(0);
                    break;
                case -1.592f:
                    updateGround(1);
                    break;
                case -1.127f:
                    updateGround(2);
                    break;
                case -0.669f:
                    updateGround(3);
                    break;
                case -0.2154824f:
                    updateGround(4);
                    break;
                case 0.2433135f:
                    updateGround(5);
                    break;
                case 0.7021092f:
                    updateGround(6);
                    break;
                case 1.167554f:
                    updateGround(7);
                    break;
                case 1.629f:
                    updateGround(8);
                    break;
                case 2.091795f:
                    updateGround(9);
                    break;

            }
        }
    }
}
