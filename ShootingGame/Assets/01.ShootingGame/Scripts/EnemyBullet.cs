using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 12f;
    private Rigidbody rigid = default;
    public GameObject effect = default;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
        GameObject bulletEffect = Instantiate(effect, this.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(this.gameObject);

            PlayerController player = other.GetComponent<PlayerController>();
            
            player.GetDamage();
           
        }
        if (other.tag.Equals("DeadZone"))
        {
            Destroy(this.gameObject);

        }

    }
}
