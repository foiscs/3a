using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public bool touch = false;
    public Player_controller player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touch)
            touch = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!touch)
        {
            touch = !touch;
            player.JumpTriggerCount++;
        }
    }
}
