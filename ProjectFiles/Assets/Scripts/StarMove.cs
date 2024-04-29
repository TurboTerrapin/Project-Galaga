using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{

    public float speed;
    public GameObject star;


    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(0, 360f);
        star.transform.eulerAngles = new Vector3(0, 0, rand);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-Vector3.up * Time.deltaTime * speed);

        if(transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 10, 0);
            float rand = Random.Range(0, 360f);
            star.transform.eulerAngles = new Vector3(0, 0, rand);
            speed = Random.Range(1, 6);
        }

    }
}
