using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;

    private PlacementZone currentZone;
    private FragmentsManager fManager;

    float snapSpeed = 20f;

    bool snapped = false;

    void Start()
    {
        fManager = FindAnyObjectByType<FragmentsManager>();
    }

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
        objectRB.isKinematic = false;
        snapped = false;
    }

    public void Drop()
    {
        if (snapped)
        {
            FinalizePlacement();
            return;
        }

        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform == null) return;

        if (currentZone != null && currentZone.tag == gameObject.tag)
        {
            if (currentZone.GetComponent<Collider>().bounds.Contains(objectGrabPointTransform.position))
            {
                SnapToZone();
                return;
            }
        }

        snapped = false;

        float lerpSpeed = 8f;
        Vector3 newPosition = Vector3.Lerp(
            transform.position,
            objectGrabPointTransform.position,
            Time.deltaTime * lerpSpeed
        );

        objectRB.MovePosition(newPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlacementZone zone = other.GetComponent<PlacementZone>();

        if (zone != null)
        {
            currentZone = zone;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlacementZone zone = other.GetComponent<PlacementZone>();

        if (zone == currentZone)
        {
            currentZone = null;
        }
    }

    void SnapToZone()
    {
        snapped = true;

        Vector3 newPos = Vector3.Lerp(
            transform.position,
            currentZone.transform.position,
            Time.deltaTime * snapSpeed
        );

        Quaternion newRot = Quaternion.Lerp(
            transform.rotation,
            currentZone.transform.rotation,
            Time.deltaTime * snapSpeed
        );

        objectRB.MovePosition(newPos);
        objectRB.MoveRotation(newRot);
    }

    void FinalizePlacement()
    {
        objectGrabPointTransform = null;

        transform.position = currentZone.transform.position;
        transform.rotation = currentZone.transform.rotation;

        objectRB.isKinematic = true;

        GetComponent<Collider>().enabled = false;

        fManager.ObjectPlacedCorrectly();
    }
}