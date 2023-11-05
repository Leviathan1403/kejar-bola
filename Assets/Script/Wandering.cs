using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public GameObject character;
    public GameObject WanderTarget;

    private Vector3 velocity;
    public float mass = 15;
    public float MaxVelocity = 2;
    public float MaxForce = 10;

    public float CircleRadius = 3;
    public float CircleDistance = 6;
    public float WanderAngle = 15.0f;
    public float AngleChange = 5;
    public float time;
    void Start()
    {
        InvokeRepeating("NextWayPoint", 2.0f, time);
        velocity = Vector3.zero;
        
    }

    private void NextWayPoint()
    {
        Vector3 wan = new Vector3(Random.Range(19,39),1, Random.Range(14,34));
        WanderTarget.transform.position = wan;
        Debug.Log("pindah");
    }

    void Update() 
    {
        Vector3 desiredVelocity = WanderTarget.transform.position - character.transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        Vector3 wand = desiredVelocity - velocity;
        Vector3 steering = Wander(wand);
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);

        character.transform.position += velocity * Time.deltaTime;
    }   


    private Vector3 Wander(Vector3 velocity)
    {
        Vector3 circleCentre = velocity.normalized;
        circleCentre *= CircleDistance;

        Vector3 displacement = new Vector3(Mathf.Clamp01(1.0f), 1, Mathf.Clamp01(1.0f));
        displacement *= CircleRadius;
        displacement = setAngle(displacement, WanderAngle);

        WanderAngle += Random.Range(0.01f, 1.0f) * AngleChange - AngleChange * 0.5f;
        Vector3 wanderforce = circleCentre + displacement;
        return wanderforce;
    }

    private Vector3 setAngle(Vector3 vector, float WanderAngle)
    {
        Vector3 v = vector;
        float len = vector.magnitude;
        v.x = Mathf.Cos(WanderAngle) * len;
        v.z = Mathf.Sin(WanderAngle) * len;
        return v;
    }
}