using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(10, 11);
    }

}
