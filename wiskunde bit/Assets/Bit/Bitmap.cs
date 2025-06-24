using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Bitmap : MonoBehaviour
{
    Bitmap bitmap;
    [SerializeField] Byte[] bites = new Byte[8];
    [SerializeField] int[] values = new int[8];

    void Start()
    {
        for (int i = 0; i < bites.Length; i++)
        {
            values[i] = Random.Range(1, 255);
            bites[i].SetValue(values[i]);
        }
    }

    void Update()
    {
        for (int i = 0; i < bites.Length; i++)
        {
            bites[i].SetValue(values[i]);
        }
    }
}