using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float RunSpeed;
    public float GotHayDestroyDelay;
    public float DropDestroyDelay;

    private Collider MyCollider;
    private Rigidbody MyRigidbody;

    private bool BHitByHay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * RunSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        BHitByHay = true;
        RunSpeed = 0;
        Destroy(gameObject, GotHayDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !BHitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }

        else if(other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        MyRigidbody.isKinematic = false;
        MyCollider.isTrigger = false;

        Destroy(gameObject, DropDestroyDelay);
    }
}
