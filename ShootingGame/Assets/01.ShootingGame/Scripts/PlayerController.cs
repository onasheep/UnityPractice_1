using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    public Transform bulletSpawner = default;
    public GameObject bullet = default;
    private Animator anim = default;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        this.transform.Translate(x * speed * Time.deltaTime, 0f, 0f);

        if(x < 0.1f && x > -0.1f)
        {
            anim.SetFloat("speed", 0);

           
        }
        else
        {
            anim.SetFloat("speed", 1);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }

    }

    void Shot()
    {
        GameObject obj = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);

    }
}
