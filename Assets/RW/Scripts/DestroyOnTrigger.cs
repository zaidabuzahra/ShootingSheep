using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string TagFilter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagFilter))
        {
            Destroy(gameObject);
        }
    }
}
