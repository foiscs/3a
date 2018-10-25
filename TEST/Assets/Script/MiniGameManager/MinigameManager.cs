using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlaying;
    [HideInInspector]
    public bool four_Players;
    [HideInInspector]
    public bool eight_Players;

    private void Awake()
    {
        isPlaying = false;
        four_Players = false;
        eight_Players = false;
    }
}
