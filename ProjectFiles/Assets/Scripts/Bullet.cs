using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;

    private bool bulletFromPlayer;

    private bool hasHit;
    void Start()
    {
        if (tag == "Bullet")
        {
            bulletFromPlayer = true;
        }
        else
        {
            bulletFromPlayer = false;
            bulletSpeed *= -1;
        }
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translate = new Vector3(0, 1, 0);
        
        transform.Translate(translate * Time.deltaTime * bulletSpeed * 5);

        if(transform.position.magnitude > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();
        if (bulletFromPlayer && collision.gameObject.CompareTag("Enemy") && !hasHit)
        {
            hasHit = true;
            hp.health -= 100;
            Destroy(gameObject);
        }
        if(!bulletFromPlayer && collision.gameObject.CompareTag("Player") && !hasHit)
        {
            hasHit = true;
            hp.health -= 100;
            Destroy(gameObject);
        }
    }

}
