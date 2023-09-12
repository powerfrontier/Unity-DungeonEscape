using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    public Transform pointA, pointB;
    // Start is called before the first frame update


    // Update is called once per frame
    public abstract void Update();

}
