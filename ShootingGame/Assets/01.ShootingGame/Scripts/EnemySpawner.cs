using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemys;
    public Transform[] spawnPoint;



    private float spawnMinTime = 0.5f;
    private float spawnMaxTime = 2.0f;
    private float timeSpend = default;
    private float spawnTime = default;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSpend += Time.deltaTime;

        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);

        SpawnEnemy();

    }

    public void SpawnEnemy()
    {
        if(timeSpend > spawnTime)
        {
            timeSpend = 0f;

            int spawnPosIndex = Random.Range(0, spawnPoint.Count());

            int randomEnemyIndex = Random.Range(0, Enemys.Count());

            GameObject enem = Instantiate(Enemys[randomEnemyIndex], spawnPoint[spawnPosIndex].position, spawnPoint[spawnPosIndex].rotation);

            Rigidbody enumRigid = enem.GetComponent<Rigidbody>();
            enumRigid.AddForce(this.transform.forward * 10f, ForceMode.VelocityChange);

        }
    }

    
}
