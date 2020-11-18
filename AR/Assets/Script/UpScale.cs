using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScale : MonoBehaviour
{
    private GameObject presse = null;
    public float scaleSpeed = 0.005f;
    private float scaleMin = 0.01f;
    private float scaleMax = 1.00f;


    // Update is called once per frame
    void Update()
    {
        if (presse == null)
            presse = GameObject.FindGameObjectWithTag("presse");
        if(Input.touchCount == 2 && presse != null)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0Pos = touch0.position - touch0.deltaPosition;
            Vector2 touch1Pos = touch1.position - touch1.deltaPosition;

            float pScale = (touch0Pos - touch1Pos).magnitude;
            float cScale = (touch0.position - touch1.position).magnitude;

            float _upScale = (touch0.deltaPosition - touch1.deltaPosition).magnitude * scaleSpeed;

            if (pScale > cScale)
                presse.transform.localScale = new Vector3(Mathf.Clamp(presse.transform.localScale.x - _upScale, scaleMin, scaleMax), Mathf.Clamp(presse.transform.localScale.y - _upScale, scaleMin, scaleMax), Mathf.Clamp(presse.transform.localScale.z - _upScale, scaleMin, scaleMax));

            if (pScale < cScale)
                presse.transform.localScale = new Vector3(Mathf.Clamp(presse.transform.localScale.x + _upScale, scaleMin, scaleMax), Mathf.Clamp(presse.transform.localScale.y + _upScale, scaleMin, scaleMax), Mathf.Clamp(presse.transform.localScale.z + _upScale, scaleMin, scaleMax));

        }
    }
}
