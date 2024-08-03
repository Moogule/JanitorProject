using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class healthSystem : MonoBehaviour
{
    public float health;


    public abstract void addHealth();
    public abstract void removeHealth();

}
