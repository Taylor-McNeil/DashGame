using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawning : MonoBehaviour
{


    public GameObject businessLady;
    public GameObject businessLady2;
    float x;
    Vector2 spawnLocation;
    public float spawnRate;
    float nextSpawn = 0.0f;

    //Right Most Section -6.98
    //Left Most Section -9.21


/*

Problem One: 

*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;




            float rand = Random.Range(-16.56f,-6.98f);
            spawnLocation = new Vector2(rand,transform.position.y);
            //Instantiate(businessLady,spawnLocation,Quaternion.identity);
            Instantiate(businessLady2,spawnLocation,Quaternion.identity);
            Debug.Log("Spawned");
            
        }
    }


   

    /*
    Function #1:  Spawn CustomerGroup

    -needs to keep track of how many waves have spawned
    -determine size of group to spawn (level)
    -determine location of the spawn

    Function #2: Number of Waves to Spawn (level & final score)

    

    */
}
