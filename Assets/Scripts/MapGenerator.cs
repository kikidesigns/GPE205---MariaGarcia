using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] grid;




    //returns a random room
    public GameObject RandomRoomPrefab ()
    {
        if(gridPrefabs.Length > 0)
        {
        return gridPrefabs[Random.Range(0,gridPrefabs.Length)];
        }
        else 
        {
            Debug.LogError("gridprefabs array is empty");
            return null;
        }
    }

    public void GenerateMap()
    {
        //clear out the grid - column is our X, Row is our Y
        grid = new Room[cols,rows];

        //for each grid row
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            //for each column in the row
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                //All the rooms in row 0 will have a Y coordinate of 0 ( 0 * roomHeight )
                //All the rooms in row 27 will have a Y coordinate of (27 * roomHeight )
                //All the rooms in row 999 will have a Y coordinate of (999 * roomHeight )
                //firgure out the location
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight *currentRow;
                Vector3 newPosition = new Vector3 (xPosition,0.0f,zPosition);
                
                //create a new grid at the appropriate location
                GameObject tempRoomObj = Instantiate (RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                //set its parent
                tempRoomObj.transform.parent = this.transform;

                //give it a meaningful name
                tempRoomObj.name = "Room_"+currentCol+","+currentRow;

                //get the room object
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                //save it to the grid array
                grid[currentCol,currentRow] = tempRoom;



                //open the doors
                ////if we are in the bottom row, open the north door
                if (currentRow==0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                //if we are in the top row,open the south door
                else if (currentRow == rows - 1)
                {
                    tempRoom.doorSouth.SetActive(false);
                }
                //otherwise we are in the middle so open north and south doors
                else
                {
                    
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }
                //if we are in the leftmost column, open the east door
                if(currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                //if we are in the right most column, open the west door
                else if(currentCol == cols - 1)
                {
                    tempRoom.doorWest.SetActive(false);
                }
                //otherwise we are in the middle so open east and west doors
                else
                {
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
                //save it to grid array
                grid[currentCol,currentRow] = tempRoom;

                //find all pawnspawnpoint child objects and add it to game manaegers list
                PawnSpawnPoint[] spawnPoints = tempRoomObj.GetComponentsInChildren<PawnSpawnPoint>();
                foreach (PawnSpawnPoint spawnPoint in spawnPoints)
                {
                    GameManager.instance.pawnSpawnPoints.Add(spawnPoint);
                }
            }
        }

    }



}
