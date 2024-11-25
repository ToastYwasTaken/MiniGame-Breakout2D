using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float BallSpeed;

    private Vector3 m_bSpawnPosition;
    private Rigidbody2D m_bRigidBody;
    private float m_rdmFloat;

    // Start is called before the first frame update
    void Start()
    {
        m_bSpawnPosition = transform.position;
        m_bRigidBody = GetComponent<Rigidbody2D>();
        RespawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RespawnBall();
        }
    }

    private void MoveBall()
    {
        m_bRigidBody.velocity = UnityEngine.Random.insideUnitCircle.normalized * BallSpeed;
        //Debug.Log(m_bRigidBody.velocity);
    }

    public void RespawnBall()
    {
        transform.position = m_bSpawnPosition;
        MoveBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Brick")
        {
            Destroy(collision.gameObject);
        }
    }
}
