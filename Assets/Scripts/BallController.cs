using UnityEngine;
using System;
using Unity.VisualScripting;

public class BallController : MonoBehaviour
{
    private Rigidbody myRB;
    private TrailRenderer trail;

    [SerializeField] private MaterialControllerSO materialController;
    [SerializeField] private Vector3 originTransform;

    public event Action<Vector3> onLaunch;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        originTransform = Vector3.zero;
        myRB.useGravity = false;
        trail.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            Debug.Log("Ganaste");
        }
    }
    public void Launch(Vector3 velocity)
    {
        myRB.linearVelocity = velocity;
        myRB.useGravity = true;
        trail.enabled = true;
        materialController.SetBallColor(OnMaterialChange.OnLaunch);
        onLaunch?.Invoke(velocity);
    }
    public void ResetLaunch()
    {
        myRB.linearVelocity = Vector3.zero;
        myRB.useGravity = false;
        trail.enabled = false;
        myRB.position = originTransform;
        materialController.SetBallColor(OnMaterialChange.OnNormal);
    }
}
