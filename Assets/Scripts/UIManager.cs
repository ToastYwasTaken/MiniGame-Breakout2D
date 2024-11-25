using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject ScoreTextGO;
    [SerializeField]
    GameObject LifeTextGO;
    [SerializeField]
    BrickSpawner BrickSpawnerRef;
    [SerializeField]
    Player PlayerRef;
    [SerializeField]
    Ball BallRef;

    private int m_score = 0;
    private int m_lifes = 3;
    TextMeshProUGUI m_lifeTextUGUI;
    TextMeshProUGUI m_scoreTextUGUI;

    private void Start()
    {
        m_lifeTextUGUI = ScoreTextGO.GetComponent<TextMeshProUGUI>();
        m_scoreTextUGUI = LifeTextGO.GetComponent<TextMeshProUGUI>();
        ResetUI();
    }
    public void UpdateScore()
    {
        m_score++;
        if (m_score >= BrickSpawnerRef.GetBrickAmount())
        {
            //Won game
            ResetUI();
            BallRef.RespawnBall();
            PlayerRef.RespawnPlayer();
            BrickSpawnerRef.ResetBricks();
            BrickSpawnerRef.SpawnBricks();
        }
        m_lifeTextUGUI.text = "Score: " + m_score;
    }
    public void UpdateHealth()
    {
        m_lifes--;
        if (m_lifes == 0)
        {
            //Lost Game
            ResetUI();
            BallRef.RespawnBall();
            PlayerRef.RespawnPlayer();
            BrickSpawnerRef.ResetBricks();
            BrickSpawnerRef.SpawnBricks();
        }
        m_scoreTextUGUI.text = "Lifes: " + m_lifes;
    }

    private void ResetUI()
    {
        m_score = 0;
        m_lifes = 3;
        m_scoreTextUGUI.text = "Score: " + m_score;
        m_lifeTextUGUI.text = "Lifes: " + m_lifes;

    }

}
