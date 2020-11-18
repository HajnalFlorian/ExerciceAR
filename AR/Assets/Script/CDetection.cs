using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class CDetection : MonoBehaviour
{
    GameObject pupitre;
    GameObject canvas;

    private void Update()
    {
        if(pupitre == null)
        {
            pupitre = GameObject.FindGameObjectWithTag("pupitre");
        }
        else
        {
            pupitre.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            pupitre.transform.rotation = Quaternion.Euler(-90, -92,0);
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "pupitre")
                {
                    canvas = pupitre.transform.Find("Canvas").gameObject;
                    if (canvas.activeSelf)
                    {
                        canvas.SetActive(false); 
                    }
                    else
                    {
                        canvas.SetActive(true);
                    }
                }
            }
        }
    }

   


}
