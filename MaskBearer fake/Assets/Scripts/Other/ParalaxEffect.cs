using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float paralaxEffect;
    [SerializeField] private ParalaxDirection parDir;

    private Transform cam;
    private Vector3 oldCamPos;

    private void Start()
    {
        cam = Camera.main.transform;
        oldCamPos = cam.position;
    }

    private void FixedUpdate()
    {
        if (parDir == ParalaxDirection.Horizontal)
        {
            Vector3 deltaMovement = cam.position - oldCamPos;
            deltaMovement.y = 0;
            transform.position += deltaMovement * paralaxEffect;
            oldCamPos = cam.position;
        }
        else if (parDir == ParalaxDirection.Vertical)
        {
            Vector3 deltaMovement = cam.position - oldCamPos;
            deltaMovement.x = 0;
            transform.position += deltaMovement * paralaxEffect;
            oldCamPos = cam.position;
        }
        else if (parDir == ParalaxDirection.Both)
        {
            Vector3 deltaMovement = cam.position - oldCamPos;
            transform.position += deltaMovement * paralaxEffect;
            oldCamPos = cam.position;
        }
    }
}

public enum ParalaxDirection
{
    Horizontal, Vertical, Both
}

