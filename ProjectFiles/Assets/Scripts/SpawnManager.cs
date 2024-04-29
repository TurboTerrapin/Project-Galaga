using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{


    public List<GameObject> levels;

    public int currentLevel;

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindFirstObjectByType<DestroySpline>())
        {
            Instantiate(levels[currentLevel] as GameObject);
            incrementLevel();
        }
    }

    void incrementLevel()
    {
        currentLevel++;
        if(currentLevel % levels.Count == 0)
        {
            currentLevel = 0;
        }
    }


}
