using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    public int upgradeType;


    void Update()
    {

        transform.Translate(0, -Time.deltaTime, 0);


        if(gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.currentBullet = upgradeType;
            player.upgradeTimer = 0;
            Destroy(gameObject);
        }
    }
}
