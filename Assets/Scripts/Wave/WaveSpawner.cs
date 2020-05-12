using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum Spawnstate { SPAWNING, WAITING, COUNTTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextwave = 0;
    public float timebetweenwaves = 5f;
    private float wavecountdown;
    private float searchCountdown = 1f;
    private Spawnstate state = Spawnstate.COUNTTING;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("error");

        }
        wavecountdown = timebetweenwaves;
    }

    // Update is called once per frame
    void Update()

    {
        if(state == Spawnstate.WAITING)
        {
            if(!EnemyAlive())
            {

                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if(wavecountdown <= 0)
        {
            if(state != Spawnstate.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextwave]));
            }
        }
        else
        {
            wavecountdown -= Time.deltaTime;
        }
    }
    void WaveCompleted()
    {
        Debug.Log("Wave ok!");
        state = Spawnstate.COUNTTING;
        wavecountdown = timebetweenwaves;

        if (nextwave + 1 > waves.Length + 1)
        {
            nextwave = 0;
            Debug.Log("All wave done");
        }
        else
        {
            nextwave++;
        }

    }
    bool EnemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <=0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        
        
            return true;
        
    }

   IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave"+_wave.name);
        state = Spawnstate.SPAWNING;
        for(int i =0; i< _wave.count; i++)
        {
            SpaenEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);

        }
        state = Spawnstate.WAITING;
        yield break;
    }
    void SpaenEnemy(Transform _enemy)
    {
        
        Debug.Log("Spawning Enemy:" + _enemy.name);
        if(spawnPoints.Length ==0)
        {
            Debug.LogError("error");

        }
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
