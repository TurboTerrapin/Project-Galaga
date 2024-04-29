using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Scoreboard score;
    public Health health;
    public GameObject[] bulletPrefabs;

    public int currentBullet;

    public float horizontalInput;

    public float borders;

    private float timer;
    public float upgradeTimer;

    private Vector3 startPos;
    private bool gameEnded;
    void Start()
    {
        timer = 0;
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        health = gameObject.GetComponent<Health>();
        score = GameObject.Find("ScoreKeeper").GetComponent<Scoreboard>();
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        timer += Time.deltaTime;
        upgradeTimer += Time.deltaTime;

        if (!gameEnded)
        {
            Move();
        }

        enforceBorders();

        if(Input.GetKey(KeyCode.Space) && timer > 0.5f)
        {
            Instantiate(bulletPrefabs[currentBullet], transform.position, transform.rotation);
            timer = 0;
        }

        if(upgradeTimer > 20)
        {
            currentBullet = 0;
        }

        if(health.health <= 0)
        {
            killPlayer(); 
        }
    }

    void Move()
    {
        Vector3 translate = new Vector3(horizontalInput, 0, 0);

        transform.Translate(translate * Time.deltaTime * 10);
    }

    void enforceBorders()
    {
        if (transform.position.x > borders)
        {
            transform.position = new Vector3(borders, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -borders)
        {
            transform.position = new Vector3(-borders, transform.position.y, transform.position.z);
        }
    }

    void killPlayer()
    {
        if(!gameEnded && score.lives <= 0)
        {
            score.endGame();
            gameEnded = true;
        }
        else if (score.lives > 0)
        {
            transform.position = startPos;
            health.health = 100;
            score.lives -= 1;
        }
    }
}
