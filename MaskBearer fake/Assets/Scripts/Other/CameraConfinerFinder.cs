using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerFinder : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Cinemachine.CinemachineConfiner2D>().m_BoundingShape2D =
            GameObject.FindGameObjectWithTag("CamLimit").
            GetComponent<PolygonCollider2D>();
        GetComponent<Cinemachine.CinemachineConfiner2D>().InvalidateCache();
    }
    public void ResetBoundingShape()
    {
        GetComponent<Cinemachine.CinemachineConfiner2D>().m_BoundingShape2D =
    GameObject.FindGameObjectWithTag("CamLimit").
    GetComponent<PolygonCollider2D>();
        GetComponent<Cinemachine.CinemachineConfiner2D>().InvalidateCache();
    }
}
