using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPickUp : PickUp
{
    public uint time = 4;
    public bool AddTime = true;
    // true - dodajemy, false- odejmujemy czas

    public override void Picked()
    {
        int znak = 1;
        if (AddTime)
        {
            znak = 1;
        }
        else
        {
            znak = -1;
        }
        GameManager.gameManager.AddTime((int)time * znak);
        Destroy(this.gameObject);
    }

    public override void Rotate()
    {
        transform.Rotate(new Vector3(0, 2f, 0));
    }

    private void Update()
    {
        Rotate();
    }

}
