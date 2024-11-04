using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField] int rotationLimitX;
    [SerializeField] int rotationLimitZ;
    [SerializeField] float speedZ;
    [SerializeField] float speedX;

    [SerializeField] PauseMenuBehaviour pauseMenu;

    bool gamePaused;

    private void Start()
    {
        pauseMenu.RegisterOnPause(OnPause);

        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            bool aKeyPressed = Input.GetKey(KeyCode.W);

            if (aKeyPressed)
            {
                if ((transform.eulerAngles.z >= -1 && transform.eulerAngles.z <= rotationLimitZ)
                    ||
                (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 270))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z + speedZ);

                    transform.eulerAngles = newRotation;
                }
            }

            bool dKeyPressed = Input.GetKey(KeyCode.S);

            if (dKeyPressed)
            {
                if ((transform.eulerAngles.z >= -1 && transform.eulerAngles.z <= 90)
                    ||
                (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (360 - rotationLimitZ)))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z - speedZ);

                    transform.eulerAngles = newRotation;
                }
            }

            bool wKeyPressed = Input.GetKey(KeyCode.D);

            if (wKeyPressed)
            {
                if ((transform.eulerAngles.x >= -1 && transform.eulerAngles.x <= rotationLimitX)
                    ||
                (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= 270))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x + speedX,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }

            bool sKeyPressed = Input.GetKey(KeyCode.A);

            if (sKeyPressed)
            {
                if ((transform.eulerAngles.x >= -1 && transform.eulerAngles.x <= 90)
                    ||
                (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= (360 - rotationLimitX)))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x - speedX,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }
        }
    }

    private void OnPause(bool pause)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        gamePaused = pause;
    }

    public void ResetPosition()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}