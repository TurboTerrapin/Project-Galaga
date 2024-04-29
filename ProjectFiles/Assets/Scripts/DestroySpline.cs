using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpline : MonoBehaviour
{
    public GameObject enemyParent;

    // Update is called once per frame
    void Update()
    {
        //Deletes the spline when all enemies have died
        if(enemyParent.transform.childCount == 0)
        {
            Destroy(gameObject);
            
        }
    }
}
