using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRunManager : MinigameManager
{
    private Vector3 pos;

    public Texture2D image;
    public GameObject plane;
    public GameObject Spwan;

    public float distance;
    void Start()
    {
        pos = transform.position;
        distance = plane.transform.localScale.x + 0.05f;

        if (image == null)
        {
            Debug.Log("in");
            for (int i = -14; i < 14; i++)
            {
                for (int j = -14; j < 14; j++)
                {
                    Instantiate(plane, pos + new Vector3(distance * i, 0, distance * j), Quaternion.Euler(0, 0, 0), transform);
                }
            }
        }
        else if (four_Players)
        {
            float MaxValue = GreatestCommonDivisor(image.width, image.height);
            int width = image.width / (int)Mathf.Round(MaxValue) * 10;

            int height = image.height / (int)Mathf.Round(MaxValue) * 10;
        }
        else if (eight_Players)
        {
            float MaxValue = GreatestCommonDivisor(image.width, image.height);
            int width = image.width / (int)Mathf.Round(MaxValue) * 10;

            int height = image.height / (int)Mathf.Round(MaxValue) * 10;
        }
    }
    float GreatestCommonDivisor(float num01, float num02)
    {
        float remainder;
        while (num02 == 0)
        {
            remainder = num01 % num02;
            num01 = num02;
            num02 = remainder;
        }
        return num01;
    }
}
