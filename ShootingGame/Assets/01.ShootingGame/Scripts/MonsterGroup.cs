using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterGroup : MonoBehaviour
{

    float maxMoveTime = 0.5f;
    float time = default;

    bool isRight = true;


    private void Update()
    {
        time += Time.deltaTime;

        if(time > maxMoveTime)
        {
            time = 0;
            if(isRight)
            {
                if (this.transform.position.x >= 2.0f)
                {
                    isRight = false;
                    this.transform.position = this.transform.position + new Vector3(0f, 0f, -2f);

                }
                else if(this.transform.position.x < 2.0f)
                this.transform.position = this.transform.position + new Vector3(2f, 0f, 0f);
            }
            else
            {
                if (this.transform.position.x <= -2.0f)
                {
                    isRight = true;
                    this.transform.position = this.transform.position + new Vector3(0f, 0f, -2f);

                }
                else if (this.transform.position.x > -2.0f)
                    this.transform.position = this.transform.position + new Vector3(-2f, 0f, 0f);
            }
        }

    

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DeadZone"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            player.GetDamage();
            Destroy(this.gameObject);
        }
    }
}
