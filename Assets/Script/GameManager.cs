using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameManager : MonoBehaviour
{
    public List<GameObject> GeometryObjectModel;
    private Camera cam;
    private int countObject;
    private Transform current;

    void Start()
    {
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 12.0f;       // we want 2m away from the camera position
        Vector3 objectPos = cam.ScreenToWorldPoint(mousePos);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<Figure>()) 
                {
                    if (current == null)
                        current = hit.transform;
                    else if (current != hit.transform)
                    {
                        current.GetComponent<Figure>().IsPanel(false);
                        current = hit.transform;
                    }
                }
            }
            else
            {
                if (countObject >= 3) return;
                GameObject figura = GeometryObjectModel[UnityEngine.Random.Range(0, GeometryObjectModel.Count)];
                Instantiate(figura, objectPos, Quaternion.identity);
                GeometryObjectModel.Remove(figura);
                countObject++;
            }
        }
    }

    
}
[Serializable]
public class item
{
    public string Cube;
    public string Sphere;
    public string Capsule;
}
