using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [SerializeField] float m_speed = 0f;
    [SerializeField] Transform[] m_tBackgrounds = null;

    float m_leftPosX = 0f;
    float m_rightPosX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float t_length = m_tBackgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        m_leftPosX = -t_length;
        m_rightPosX = t_length * m_tBackgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_tBackgrounds.Length; i++) {
            m_tBackgrounds[i].position += new Vector3(m_speed, 0, 0) * Time.deltaTime;
            if(m_tBackgrounds[i].position.x < m_leftPosX)
            {
                Vector3 t_selfPos = m_tBackgrounds[i].position;
                t_selfPos.Set(t_selfPos.x + m_rightPosX, t_selfPos.y, t_selfPos.z);
                m_tBackgrounds[i].position = t_selfPos;
            }
        }
    }
}
