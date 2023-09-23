using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Gems++;
            Debug.Log(other.GetComponent<Player>().Gems);
            Destroy(this.gameObject);
        }
    }
}
