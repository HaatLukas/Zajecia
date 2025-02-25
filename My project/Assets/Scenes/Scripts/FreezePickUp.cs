using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickUP : PickUp
{
    public uint timeToFreeze = 3;
    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(timeToFreeze); 
        Destroy(this.gameObject);
    }

    public override void Rotate()
    {
        transform.Rotate(new Vector3(0, 1.5f, 0));
    }

    private void Update()
    {
        Rotate();
    }
}
