using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;


    }
    public Wave[] waves;
    
    private int nextWave = 0;

    public float timeGap = 5f;
    public float waveCountdown;

    private float searchDelay = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Text timeText;
    void Start()
    {
        waveCountdown = timeGap;
        
    }
    private void Update()
    {
        float timer = Time.timeSinceLevelLoad;
        float minutes = Mathf.Floor(timer / 60f);
        string m = minutes.ToString();
        float seconds = Mathf.RoundToInt(timer % 60f);
        string s = seconds.ToString();
        if(minutes < 10)
        {
            m = "0" + minutes.ToString();
        }
        if(seconds < 10)
        {
            s = "0" + seconds.ToString();
        }
        timeText.text = m + ":" + s;
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                if (nextWave < 1)
                {
                    nextWave++;
                }
                if(nextWave == 1)
                {
                    nextWave = 0;
                }
                state = SpawnState.COUNTING;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }
    bool EnemyIsAlive()
    {
        searchDelay -= Time.deltaTime;
        if(searchDelay <= 0f)
        {
            searchDelay = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return false;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        //Spawns enemy
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
