using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatformBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float speed;
    [SerializeField] float offset;
    [SerializeField] float duration;

    float timer;

    int actualDestiny;

    private void Start()
    {
        actualDestiny = 0;
        timer = 0;
    }

    private void Update()
    {
        Vector3 direction;
        Vector3 destiny = positions[actualDestiny].position;
        Vector3 actualPosition = transform.position;

        direction = destiny - actualPosition;
        direction.Normalize();

        Vector3 newPosition = actualPosition + (direction * speed * Time.deltaTime);

        transform.position = newPosition;

        float distance = Vector3.Distance(newPosition, destiny);

        if (distance < offset)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                if (actualDestiny == positions.Length-1)
                {
                    actualDestiny = 0;  
                }
                else
                {
                    actualDestiny += 1;           
                }

                timer = 0;
            }
            
            
        }
    }
}
