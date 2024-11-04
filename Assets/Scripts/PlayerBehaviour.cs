using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 initPosition;
    int actualLifes;
    [SerializeField] int maxLifes;

    [SerializeField] Text lifesText;
    [SerializeField] PauseMenuBehaviour pauseMenu;

    private void Start()
    {
        initPosition = transform.localPosition;

        actualLifes = maxLifes;

        lifesText.text = "Lifes: " + actualLifes;

        pauseMenu.RegisterOnPause(PauseBall);
    }

    public int LooseLife(int lifesToLoose)
    {
        if (actualLifes - lifesToLoose > 0)
        {
            actualLifes = actualLifes - lifesToLoose;
            lifesText.text = "Lifes: " + actualLifes;
            return actualLifes;
        }
        else
        {
            lifesText.text = "Game Over";
            Destroy(this.gameObject);
            return 0;
        }

    }

    public void ResetPosition()
    {
        // Funcionalidad para volver a la posición de inicio
        transform.localPosition = initPosition;
        Rigidbody rb;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; // new Vector3(0,0,0)
        rb.angularVelocity = Vector3.zero;
    }

    private void PauseBall(bool pause)
    {
        Rigidbody rb;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}