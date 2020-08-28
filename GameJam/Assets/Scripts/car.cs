using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public Transform centerOfMass;

    public WheelCollider wheelColliderFL;
    public WheelCollider wheelColliderFR;
    public WheelCollider wheelColliderBL;
    public WheelCollider wheelColliderBR;

    public Transform wheelFL;
    public Transform wheelFR;
    public Transform wheelBL;
    public Transform wheelBR;

    public Transform arrow;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    public float jumpForce;

    public bool youWon;

    private Rigidbody _rb;

    public bool isColliding;
    GameObject cargo;
    public GameObject newTargetPos;

    public GameObject WaterCarPrefab;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass.localPosition;
    }


    private void Update()
    {

        //Movimiento del coche + rotacion de las ruedas
        wheelColliderBL.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderBR.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderFL.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderFR.steerAngle = Input.GetAxis("Horizontal") * maxSteer;

        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderFL.GetWorldPose(out pos, out rot);
        wheelFL.position = pos;
        wheelFL.rotation = rot;

        wheelColliderFR.GetWorldPose(out pos, out rot);
        wheelFR.position = pos;
        wheelFR.rotation = rot * Quaternion.Euler(0, 180, 0);

        wheelColliderBL.GetWorldPose(out pos, out rot);
        wheelBL.position = pos;
        wheelBL.rotation = rot;

        wheelColliderBR.GetWorldPose(out pos, out rot);
        wheelBR.position = pos;
        wheelBR.rotation = rot * Quaternion.Euler(0,180,0);

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
