using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInputHandler : MonoBehaviour
{
    private MapGenerator mapGenerator;
    // Start is called before the first frame update
    private void Start()
    {
        mapGenerator = GetComponent<MapGenerator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mapGenerator.GenerateMap();
        }
    }
}
