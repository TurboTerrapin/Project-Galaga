using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    
    
    public float quadrant;
    public int delay;

    public GameObject enemyBullet;
    public GameObject parent;

    public List<GameObject> upgradePrefabs;

    private Scoreboard score;
    private Health health;
    private SplineAnimate animate;

    
    private Vector3 finalPos;

    private bool inPlace;
    public float timer;
    public float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
        score = GameObject.Find("ScoreKeeper").GetComponent<Scoreboard>();
        animate = gameObject.GetComponent<SplineAnimate>();
        inPlace = false;
        animate.Pause();
        if (quadrant == 0)
        {
            finalPos = new Vector3(parent.transform.position.x - 0.25f, parent.transform.position.y + 0.25f, parent.transform.position.z);
        }
        else if(quadrant == 1)
        {
            finalPos = new Vector3(parent.transform.position.x + 0.25f, parent.transform.position.y + 0.25f, parent.transform.position.z);
        }
        else if(quadrant == 3)
        {
            finalPos = new Vector3(parent.transform.position.x - 0.25f, parent.transform.position.y - 0.25f, parent.transform.position.z);
        }
        else if(quadrant == 4)
        {
            finalPos = new Vector3(parent.transform.position.x + 0.25f, parent.transform.position.y - 0.25f, parent.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        bulletTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && bulletTimer > 0.5f && timer > 6 + delay)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            bulletTimer = 0;
        }

        if(timer > delay + (quadrant / 2))
        {
            animate.Play();
        }

        if (!inPlace && transform.position == parent.transform.position)
        {
            transform.position = finalPos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            inPlace = true;
        }

        if (transform.position.y < -8)
        {
            health.health = 0;
        }

        if (health.health <= 0)
        {
            score.score += 1000;
            if(Random.Range(0,10) == 0)
            {
                Instantiate(upgradePrefabs[Random.Range(0, upgradePrefabs.Count)]);
            }
            Destroy(gameObject);
        }
    }
}
