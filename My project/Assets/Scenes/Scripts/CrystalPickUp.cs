using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickUp : PickUp
{
    public int points = 10; 
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }

    public override void Rotate()
    {
        transform.Rotate(new Vector3(0, 4.5f, 0));
    }

    private void Update()
    {
        Rotate();
    }
}
