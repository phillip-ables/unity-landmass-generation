using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);





        //it now has two xyz on script generator
        //last error was array index size line of color map
        //button wont throw error, was array [x,y]
        //think its the editor cs and visual studio completely froze up had to shut down

        //thought it could have been
        //        base.OnInspectorGUI();
        //he didnt have but his old unity??
    }
}
