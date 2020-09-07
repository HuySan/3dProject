using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    float speed = 3f;
    float obstacleRange = 5f;

    bool alive;
    bool force;

    Rigidbody rg;
    [SerializeField] GameObject fireBallPrefab;
    GameObject fireBall;

    private void Start()
    {
        force = false;
        alive = true;
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerHaracter>()) { 
                    if (fireBall == null)
                    {
                        fireBall = Instantiate(fireBallPrefab) as GameObject;
                        fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.75f);
                        fireBall.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angleRotation = Random.Range(-120, 120);
                    transform.Rotate(0, angleRotation, 0);
                }
            }
        }
    }

    public void SetAlive(bool _alive,bool _force) {
        alive = _alive;
        force = _force;
        if (force == true)
        {

            rg.AddForce(transform.forward * 20, ForceMode.Impulse);
        }
    }
}
