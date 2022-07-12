using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Obstacle;

    public float spawnTime;

    float m_spawnTime;

    bool m_isGameOver;

    int m_score;


    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
    }
    //-1.25, -3
    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime; 
        }

    }

    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-3, -1.25f);

        Vector2 spawnPos = new Vector2(11, randYpos);

        if (Obstacle)
        {
            Instantiate(Obstacle, spawnPos, Quaternion.identity);
        }
    }
    
    public void SetScore(int values)
    {
        m_score = values;
    }
    public int GetScore()
    {
        return m_score;
    }

    public void ScoreIncrement()
    {
        m_score++;
    }
    

    public bool isGameOver()
    {
        return m_isGameOver;
    }

    public void SetGameOverState(bool state)
    {
        m_isGameOver = state;
    }
}
