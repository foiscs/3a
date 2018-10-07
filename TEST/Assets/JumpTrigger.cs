using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public Player_controller player;
    private void OnTriggerEnter(Collider other)
    {
        player.JumpTriggerCount++;
    }
    private void OnTriggerExit(Collider other)
    {
            player.JumpTriggerCount-- ;
    }
}
