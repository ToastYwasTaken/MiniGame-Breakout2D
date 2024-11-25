using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject BrickPrefab;
    [SerializeField]
    int Width = 7;
    [SerializeField]
    int Height = 7;
    [SerializeField]
    float Spacing = 0.1f;

    public int GetBrickAmount() { return Width * Height; }

    private List<GameObject> m_allBricks = new List<GameObject>();
    Color m_rdmColor;

    // Start is called before the first frame update
    void Start()
    {
        ResetBricks();
        SpawnBricks();
    }

    public void ResetBricks()
    {
        foreach (GameObject go in m_allBricks)
        {
            Destroy(go);
        }
        m_allBricks.Clear();
    }

    public void SpawnBricks()
    {
        int count = 0;
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                m_rdmColor = UnityEngine.Random.ColorHSV();
                Vector3 brickSpawnPos = transform.position + new Vector3( i * (BrickPrefab.transform.localScale.x + Spacing), -j * (BrickPrefab.transform.localScale.y + Spacing), 0);
                GameObject newBrick = Instantiate(BrickPrefab, brickSpawnPos, Quaternion.identity);
                    m_allBricks.Add(newBrick);
                newBrick.name = $"Brick [{count}]";
                newBrick.GetComponent<Renderer>().material.color = m_rdmColor;
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
