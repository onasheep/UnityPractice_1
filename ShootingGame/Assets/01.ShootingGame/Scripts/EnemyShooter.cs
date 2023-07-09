using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    private float minBulletTime = 1.5f;
    private float maxBulletTime = 3.0f;

    private float time = default;

    private float bulletRatio = default;

    private PlayerController pC;
    // Start is called before the first frame update
    void Start()
    {
        pC = FindObjectOfType<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bulletRatio = Random.Range(minBulletTime, maxBulletTime);

        if (time > bulletRatio)
        {
            time = 0f;
            GameObject obj = Instantiate(bullet, barrel.position, barrel.rotation);
        }
    }
}
