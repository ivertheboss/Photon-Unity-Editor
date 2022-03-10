using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public void Rescale()
    {
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
