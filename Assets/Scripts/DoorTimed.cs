using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimed : MonoBehaviour
{
    [SerializeField] float openedTime;
    [SerializeField] float closedTime;
    [SerializeField] bool openAtStart;
    float timeCounter;

    Animator animator;

    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        timeCounter = 0;
        isOpen = openAtStart;

        animator.SetBool("Open", openAtStart);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter = timeCounter + Time.deltaTime;

        //if (isOpen && timeCounter > openedTime)
        //{
        //    // Hay que cerrar
        //    animator.SetBool("Open", false);

        //    isOpen = false;
        //    timeCounter = 0;
        //}

        //if (!isOpen && timeCounter > closedTime)
        //{
        //    // Hay que abrir
        //    animator.SetBool("Open", true);

        //    isOpen = true;
        //    timeCounter = 0;
        //}
        if (isOpen)
        {
            // Está abierto
            if (timeCounter > openedTime)
            {
                // Cierro
                animator.SetBool("Open", false);

                isOpen = false;
                timeCounter = 0;
            }
        }
        else
        {
            // Está cerrado
            if (timeCounter > closedTime)
            {
                // Abro
                animator.SetBool("Open", true);

                isOpen = true;
                timeCounter = 0;
            }
        }

    }
}
