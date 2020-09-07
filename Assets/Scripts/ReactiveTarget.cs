using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{


    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if(behavior != null)
        {
            behavior.SetAlive(false,true);
        }
        StartCoroutine(Die());
    }
    

    IEnumerator Die()
    {
    //    GetComponent<WanderingAI>().enabled = false;
        this.transform.Rotate(75,0,0);

        yield return new WaitForSeconds(1.5f);
        
        Destroy(this.gameObject);
    }

}
