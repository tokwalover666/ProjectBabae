using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;

    private PlacementZone currentZone;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        Debug.Log(gameObject.name + " grabbed");

        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
    }

    public void Drop()
    {
        Debug.Log(gameObject.name + " dropped");

        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;

        CheckPlacement();
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 8f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlacementZone zone = other.GetComponent<PlacementZone>();

        if (zone != null)
        {
            currentZone = zone;
            Debug.Log(gameObject.name + " entered zone: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlacementZone zone = other.GetComponent<PlacementZone>();

        if (zone == currentZone)
        {
            Debug.Log(gameObject.name + " left zone: " + other.name);
            currentZone = null;
        }
    }

    private void CheckPlacement()
    {
        if (currentZone == null)
        {
            Debug.Log("No placement zone detected");
            return;
        }

        Debug.Log("Checking placement: Object tag = " + gameObject.tag +
                  " | Zone tag = " + currentZone.tag);

        if (currentZone.tag == gameObject.tag)
        {

            transform.position = currentZone.transform.position;
            transform.rotation = currentZone.transform.rotation;

            objectRB.isKinematic = true;

            GetComponent<Collider>().enabled = false;
        }

    }
}