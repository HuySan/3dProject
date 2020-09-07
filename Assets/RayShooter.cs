using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    Camera cam;
    GameObject prtcl;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//скрываемм курсор мыши
        Cursor.visible = false;
        cam = GetComponent<Camera>();
        prtcl = GameObject.Find("HitEffect");
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");//Тектовая метка
    }

    void FixedUpdate()
    {
        Vector2 poin = new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(poin);
            // Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                   // StartCoroutine(SphereIndicator(hit.point));
                    prtcl.transform.position = hit.point;
                    prtcl.GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }

}
