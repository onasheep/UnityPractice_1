using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }

        if(other.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
