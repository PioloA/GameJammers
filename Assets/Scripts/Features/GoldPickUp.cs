using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MetalPickUp
{
    private void Update()
    {
        OnPickedUp();
    }

    public override void OnPickedUp()
    {
        pointValue = 20;
    }
}
