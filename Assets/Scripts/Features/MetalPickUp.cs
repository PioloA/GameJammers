using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPickUp : MonoBehaviour
{
    public int pointValue = 10;

    void Update()
    {
        OnPickedUp();
    }

    public virtual void OnPickedUp()
    {
        pointValue = 10;
    }
}

