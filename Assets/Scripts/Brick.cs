using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private UIManager m_scoreManager;

    private void Awake()
    {
        m_scoreManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        m_scoreManager.UpdateScore();
    }
}
