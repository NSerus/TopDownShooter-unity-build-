using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject ClosedRoom;
    public List<GameObject> Rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject FlipBoss;

    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (i == Rooms.Count -1)
                {
                    Instantiate(FlipBoss , Rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }               
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }  
}
