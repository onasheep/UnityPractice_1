using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawner = default;
    public GameObject bullet = default;
    public GameObject damageEffect = default;

    private Animator anim = default;

    public GameObject[] heartUi = default;


    private float speed = 5f;

    public int curHp = default;
    private int maxHp = 3;



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        curHp = maxHp;

        

    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        
        this.transform.Translate(x * speed * Time.deltaTime, 0f, 0f);

        // 애니메이션 이동
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


        if(curHp <= 0)
        {
            Die();
        }

        
    }

    private void Shot()
    {
        GameObject obj = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);

    }

    public void GetDamage()
    {
        if (curHp > 0)
        {
            
            
            GameObject effect = Instantiate(damageEffect, this.transform);
            Destroy(effect, 1f);
                        
            anim.SetTrigger("hit");

            int index = curHp;
            heartUi[index - 1].SetActive(false);

            curHp -= 1;
            
        
        }
    }
    
    

    public void Die()
    {
        this.gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
