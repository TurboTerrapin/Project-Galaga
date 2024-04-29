using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixBullet : MonoBehaviour
{

    public int bulletSpeed;
    public int horizontalSpeed;


    private bool bulletFromPlayer;

    public bool isLeft;

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

        if(isLeft)
        {
            horizontalSpeed *= -1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translate = new Vector3(Mathf.Sin(horizontalSpeed * transform.position.y)/5, 1, 0);

        transform.Translate(translate * Time.deltaTime * bulletSpeed * 5);


        if (transform.position.magnitude > 10)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();
        if (bulletFromPlayer && collision.gameObject.CompareTag("Enemy"))
        {
            hp.health -= 100;
            Destroy(gameObject);
        }
        if (!bulletFromPlayer && collision.gameObject.CompareTag("Player"))
        {
            hp.health -= 100;
            Destroy(gameObject);
        }
    }

}
