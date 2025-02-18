using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFriendBehaviour : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] float shootingDelay;

    [SerializeField] Vector3 forceVector;

    Rigidbody target;

    void SetInShootingPoint()
    {
        target.transform.position = shootingPoint.position;
    }
    
    IEnumerator ShootWithDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        Shoot();
    }

    void Shoot()
    {
        target.isKinematic = false;
        target.AddForce(forceVector);
    }

    private void SetTarget(Rigidbody newTarget)
    {
        target = newTarget;
        target.isKinematic = true;
        SetInShootingPoint();
        StartCoroutine(ShootWithDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && target == null)
        {
            SetTarget(collision.gameObject.GetComponent<Rigidbody>());
        }
    }
}
