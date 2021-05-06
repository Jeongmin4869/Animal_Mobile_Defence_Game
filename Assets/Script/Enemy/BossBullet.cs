using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float dmg;

    // Start is called before the first frame update
    void Start()
    {
        /*
        float angle = Mathf.Atan2(0f, 0f) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D rigid = transform.GetComponent<Rigidbody2D>();
        //bullet.transform.LookAt(targetAnimal);
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);//삭제하는 함수
            //플레이어의 HP 깎는다
        }
        if (collision.gameObject.tag == "Animal")
        {
            Destroy(gameObject);
        }
    }

 }
