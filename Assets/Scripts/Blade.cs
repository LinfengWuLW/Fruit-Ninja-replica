using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private bool slicing;

    private Collider bladeCollider;

    private Camera mainCamera;

    public Vector3 direction { get; private set; }

    private float minSliceVelocity = 0.001f;

    private TrailRenderer bladeTrail;

    public float sliceForce = 5f;
    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        mainCamera = Camera.main;

        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlicing();
    }
    private void OnDisable()
    {
        StopSlicing();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if(slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;

        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;

        bladeTrail.enabled = false;
    }
    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
}
