﻿using UnityEngine;
using System.Collections;

public static class MeshGenerator
{
    public static void GenerateTerrainMesh(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //start creating our verticix
            }
        }
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
    }
}