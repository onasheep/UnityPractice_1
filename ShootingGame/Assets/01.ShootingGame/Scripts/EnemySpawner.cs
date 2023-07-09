using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemysPrefabs;

    public GameObject monsterGroup;



    private float spawnMinTime = 3.5f;
    private float spawnMaxTime = 5.0f;

    private float timeSpend = default;
    private float spawnTime = default;
 

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timeSpend += Time.deltaTime;

        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);
        

        if (timeSpend > spawnTime)
        {
            timeSpend = 0f;

            SpawnEnemy();

        }

    }

    public void SpawnEnemy()
    {

        GameObject group = Instantiate(monsterGroup, this.transform.position, this.transform.rotation);
        Transform[] enemyPos = group.GetComponentsInChildren<Transform>();

        for (int i = 1; i < enemyPos.Length; i++)
        {
            int randomEnemyIndex = Random.Range(0, enemysPrefabs.Count());

            GameObject enemy = Instantiate(enemysPrefabs[randomEnemyIndex], enemyPos[i].transform);

        }

    }



}
