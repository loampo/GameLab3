using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.PLAYER))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
