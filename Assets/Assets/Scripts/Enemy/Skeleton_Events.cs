using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Events : MonoBehaviour
{

    public void DestroyEvent()
    {
        GameObject parent = this.transform.parent.gameObject;
        Destroy(parent);
        Destroy(this.gameObject);
    }

}
