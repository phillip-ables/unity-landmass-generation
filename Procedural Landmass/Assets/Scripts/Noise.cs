using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise {  // were not attaching this to any object, no need MonoBehaviour
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octaves, float persistance, float lacunarity)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (scale <= 0)
            scale = 0.0001f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight =0;
  

                for (int i=0; i < octaves; i++)
                {
                    //frequency to take effect
                    //multiplying our sample coordinates by it
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    //higher frequncy, further apart the sample points
                    //height values will change more rapidly
                     
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                    //del noiseMap[,]
                    //increase noise height by perlin value of each octave
                    noiseHeight += perlinValue * amplitude;

                    //amplitude decreases each octive
                    //lacunarity increases each octave
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
            }
        }
        return noiseMap;
    }
}
