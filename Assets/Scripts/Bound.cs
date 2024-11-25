using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    [SerializeField]
    Player PlayerRef;
    [SerializeField]
    UIManager LifeManager;
    [SerializeField]
    Ball BallRef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            LifeManager.UpdateHealth();
            PlayerRef.RespawnPlayer();
            BallRef.RespawnBall();
        }
    }
}
