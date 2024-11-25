using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float Speed = 6f;

    private Rigidbody2D m_pRigidBody;
    private Vector3 m_pSpawnPosition;
    private int m_keyInput;

    // Start is called before the first frame update
    void Start()
    {
        m_pSpawnPosition = transform.position;
        m_pRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_keyInput = -1;
        }else if (Input.GetKey(KeyCode.D))
        {
            m_keyInput = 1;
        }
    }
    private void FixedUpdate()
    {
        if (m_keyInput != 0)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        m_pRigidBody.velocity = Vector2.right * m_keyInput * Speed;
        m_keyInput = 0;
    }

    public void RespawnPlayer()
    {
        transform.position = m_pSpawnPosition;
    }

}
