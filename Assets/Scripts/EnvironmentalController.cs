using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject checkmarkSprite;
    public List<GameObject> checkmarks;
    private Player player;
    public List<Vector2> playerQueue;
    
   


    void Start()
    {
        player = (Player)GameObject.Find("Player").GetComponent(typeof(Player));
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void addCheckmark() {

        playerQueue = player.getQueue();
        Vector2 lastLocation = playerQueue[playerQueue.Count - 1];
        checkmarks.Add(Instantiate(checkmarkSprite, lastLocation, Quaternion.identity));
       }

    public void removeCheckmark() {
        Debug.Log("Remove function called");
        Destroy(checkmarks[0]);
        checkmarks.RemoveAt(0);
        
    }
    
}
