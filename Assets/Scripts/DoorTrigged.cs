using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigged : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isOpen;
    [SerializeField] SwitchBehaviour trigger;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        if (isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
        trigger.RegisterFunctionToCall(Trigger);
    }

    private void Trigger(bool active, SwitchBehaviour sender)
    {
        if (!isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        animator.SetBool("Open", true);
        isOpen = true;
    }

    public void Close()
    {
        animator.SetBool("Open", false);
        isOpen = false;
    }
}
