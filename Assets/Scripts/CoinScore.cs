using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraCoinScore : MonoBehaviour
{


    [SerializeField] string playerName;

    [SerializeField] Vector3 minTeleportRange;
    [SerializeField] Vector3 maxTeleportRange;

    [SerializeField] int scoreToAdd;

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore player;
        player = other.gameObject.GetComponent<PlayerScore>();
        if (player != null)
        {
            player.AddScore(scoreToAdd);
            
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            //gameObject.GetComponent<AudioSource>().Play();

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Destroy(this.gameObject,3f);
        }
    }

    private void TeleportCoin()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minTeleportRange.x, maxTeleportRange.x),
            Random.Range(minTeleportRange.y, maxTeleportRange.y),
            Random.Range(minTeleportRange.z, maxTeleportRange.z)
        );

        transform.localPosition = randomPosition;
    }

}