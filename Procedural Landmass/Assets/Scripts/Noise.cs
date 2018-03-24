﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise {  // were not attaching this to any object, no need MonoBehaviour
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)//existence presisted
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        //psuedo random number generator
        System.Random prng = new System.Random(seed);
        //Each octave to be sampled from a different location
        //create an array of Vec2
        Vector2[] octaveOffsets = new Vector2[octaves];
        for(int i=0; i< octaves; i++)
        {
            //if Mathf.perlinNoise coordinate thats too hight
            //keeps returning same number over&over again
            float offsetX = prng.Next(-100000, 100000) + offset.x; // range
            float offsetY = prng.Next(-100000, 100000) + offset.y; // when calculating add offsets

            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
            scale = 0.0001f;

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight =0;
  

                for (int i=0; i < octaves; i++)
                {
                    float sampleX = x - halfWidth / scale * frequency + octaveOffsets[i].x;
                    float sampleY = y - halfHeight / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY)*2-1;

                    noiseHeight += perlinValue * amplitude;
                    
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if(noiseHeight > maxNoiseHeight){
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < maxNoiseHeight){
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
            }
        }
        
        //normalize our noiseMap and happily return it
        for(int y =0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
}
