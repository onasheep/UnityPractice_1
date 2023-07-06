using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody rigid = default;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Vector3.forward * speed,ForceMode.VelocityChange);
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
