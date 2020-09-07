using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHaracter : MonoBehaviour
{
    int health;
    void Start()
    {
        health = 5;
    }


    public void hurt(int damage)
    {
        if (health > 1)
        {
            health -= damage;
            Debug.Log("Yout helth: " + health);
        }
        else
        {
            FPSInput fps = GetComponent<FPSInput>();
            Debug.Log("You dead,oh shit");
            fps.SetLive(false);
            transform.Rotate(0, 0, 70);            
        }
    }
}
