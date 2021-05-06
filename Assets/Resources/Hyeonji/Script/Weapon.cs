using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이랑 부딪히거나 화면 밖으로 나가면 무기 삭제
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
    }

}
