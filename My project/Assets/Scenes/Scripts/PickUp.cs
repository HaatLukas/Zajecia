using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    // virtual  - wirtualna
    
    virtual public void Picked()
    {
        Debug.Log("Podnios³em");
        Destroy(this.gameObject);
    }

    virtual public void Rotate()
    {
        transform.Rotate(new Vector3(0, 3f, 0));
    }
  
    void Update()
    {
        Rotate();
    }
}
