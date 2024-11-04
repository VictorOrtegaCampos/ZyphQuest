using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] int livesToLose;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player;
        player = other.gameObject.GetComponent<PlayerBehaviour>();

        if (player!=null)
        {
            int lifes;
            
            lifes = player.LooseLife(livesToLose);
             if ( lifes > 0)
            {
                player.ResetPosition();
            }
           
           
        }
        else
        {
           Destroy(other.gameObject);
        }
    }
}
