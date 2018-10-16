using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour {

    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL; 
    public WheelCollider wheelRR;

    [Header("Car options")]
    public Color color;
    public float currentSpeed;
    public float maxSpeed = 100;
    public float maxSteerAngle = 45f;
    public float maxMotorTorque = 30f;
    public bool isBraking = false;
    public float maxBrakeTorque = 20f;
    public float currentBrakeTorque;

	void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }
	
	void FixedUpdate () {
        Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        if(currentSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
        
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    private void Braking()
    {
        wheelRL.brakeTorque = maxBrakeTorque;
        wheelRR.brakeTorque = maxBrakeTorque;
        
    }

    private void NoBraking()
    {
        wheelRL.brakeTorque = 0;
        wheelRR.brakeTorque = 0;
    }

    private void Sensors()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.14f))
        {
            Debug.DrawRay(transform.position, hit.transform.forward / 4, Color.red);
            if (hit.transform.gameObject.tag == "Car")
            {
                Braking();
            }
            if (hit.transform.gameObject.tag == "TrafficLight")
            {
                if (hit.transform.Find("Light").GetComponent<Renderer>().material.color == Color.red || hit.transform.Find("Light").GetComponent<Renderer>().material.color == Color.yellow)
                {
                    Braking();
                }
                if (hit.transform.Find("Light").GetComponent<Renderer>().material.color == Color.green)
                {
                    NoBraking();
                }
            }
        }
        else
        {
            NoBraking();
        }
    }

  

}
