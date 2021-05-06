using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLV1 : MonoBehaviour
{
    public Transform[] AllAnimals = new Transform[10]; // 모든 동물
    public Transform[] Animals2 = new Transform[3]; // 2단계 동물 프리팹
    private Rigidbody2D rigid;
    private int isDestroy = 0; // 충돌 횟수 확인
    private Vector3 firstPosition; // 오브젝트 처음 위치 저장
    private Vector3 nowPosition; // 업그레이드 된 동물 생성될 위치
    private Vector3[] Positions = new Vector3[2]; // 충돌체 위치 저장
    public bool isMove = false; //움직임을 확인. 움직일때는 몬스터에의한 죽음이 없어야함


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        // 오브젝트 처음 위치 저장
        firstPosition = this.transform.position;
        // 동물설정
        Animals2[0] = AllAnimals[CompletionBtnClick.AnimalNumber1];
        Animals2[1] = AllAnimals[CompletionBtnClick.AnimalNumber2];
        Animals2[2] = AllAnimals[CompletionBtnClick.AnimalNumber3];
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
        // 충돌 오브젝트 0개 초기화
        isDestroy = 0;
    }

    // 마우스 드래그
    private void OnMouseDrag()
    {
        // 마우스 드래그하는 동안 위치를 오브젝트에 넣어줌, 물체가 포인터에 따라옴
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        this.transform.position = mousePosition;
        isMove = true;
    }

    // 마우스를 놓을 때
    private void OnMouseUp()
    {
        // RaycastAll 아래로 확인
        RaycastHit2D[] rayDown = Physics2D.RaycastAll(rigid.position, Vector3.down, 1);

        for (int i=0; i <rayDown.Length; i++)
        {
            // 충돌한 동물 태그가 지금 동물 태그와 같다면 횟수+
            if (rayDown[i].collider.gameObject.tag == this.transform.tag)
            {
                isDestroy++;// 횟수가 2, 즉 본인과 충돌한 동물이 같다면
                if (isDestroy == 2)
                {
                    // 생성 될 위치 저장
                    Positions[0] = rayDown[i].collider.gameObject.transform.position;
                    Positions[1] = rayDown[i-1].collider.gameObject.transform.position;
                    // 둘 다 삭제
                    Destroy(rayDown[i].collider.gameObject);
                    Destroy(rayDown[i - 1].collider.gameObject);
                    // 생성 될 위치 확인
                    for(int j=0; j<2; j++)
                    {
                        if (Positions[j] != firstPosition)
                        {
                            nowPosition = Positions[j];
                        }
                    }
                    // 2단계 동물 랜덤 업그레이드 (★동물 수 변경)
                    int RandomAnimal = Random.Range(0, Animals2.Length);
                    Instantiate(Animals2[RandomAnimal], new Vector3(nowPosition.x, nowPosition.y + 0.461f, 0), Quaternion.identity);
                    //토탈동물 -1
                    AnimalAdd.TotalAnimal--;
                    // 동물 생성 가능한 땅 정보 업데이트
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
                    break;

                }
                else // 충돌한 동물이 없다면 제자리로
                {
                    this.transform.position = firstPosition;
                }
            }
            
        }

        isMove = false;

    }

    void updateGround(int n)
    {
        GameObject.Find("AnimalAdd").GetComponent<AnimalAdd>().GroundOK[n] = true;
        GameObject.Find("AnimalAdd").GetComponent<AnimalAdd>().isGroundNumber++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isMove)
        {
            // 적이나 보스(공격)랑 부딪히면 사라짐
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "MeteorBullet" || collision.gameObject.tag == "FinalBoss")
            {
                AnimalAdd.TotalAnimal--;
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
}
