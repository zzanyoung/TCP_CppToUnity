using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TcpClientEx : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating(nameof(Repeat), 0f, 5f);
    }

    void Repeat()
    {
        TcpClient client = new TcpClient("localhost", 12345);

        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[3 * 4 * 4]; // 3x4 matrix of floats
        int bytesRead = stream.Read(buffer, 0, buffer.Length);

        float[,] matrix = new float[3, 4];
        Buffer.BlockCopy(buffer, 0, matrix, 0, bytesRead);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Debug.Log(matrix[i, j]);
            }
        }

        stream.Close();
        client.Close();
    }
}

