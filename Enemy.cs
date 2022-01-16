using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float force = 0.25f;
    [SerializeField] private float angle = 0.5f;
    [SerializeField] private float Angular_Speed = 1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float time_val = 1f;

    private Vector3 currentpos;

    private Vector3 dir;

    private Transform target;

    private float time;

    private Rigidbody e1_rigidbody;
    

    //public float expl_radius = 5.0f;
    //public float expl_power = 10.0f;
    
   


    
    

    void Start()
    {
        e1_rigidbody = GetComponent<Rigidbody>();

        target = Waypoints.points[0];
        currentpos = transform.position;
        dir = target.position - transform.position;
        
        e1_rigidbody.AddForce(dir.normalized.x * force, (dir.normalized.y + angle) * force, dir.normalized.z * force, ForceMode.Impulse);
        e1_rigidbody.AddTorque(Vector3.up * angle);
        e1_rigidbody.AddTorque(Vector3.forward);


    }

    void FixedUpdate()
    {
        speed = e1_rigidbody.velocity.magnitude;
        Angular_Speed = e1_rigidbody.angularVelocity.magnitude;
        dir = target.position - transform.position;
        e1_rigidbody.WakeUp();

    }

    void OnCollisionEnter(Collision collision)
    {
        
        time = 0;

    }

    
    public void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        
       

        if (collision.gameObject.name == "map2" && time >= time_val)
        {
            
            e1_rigidbody.AddForce(dir.normalized.x * force, (dir.normalized.y + angle) * force, dir.normalized.z * force, ForceMode.Impulse);
            e1_rigidbody.AddTorque(Vector3.forward);
            e1_rigidbody.AddTorque(Vector3.up * angle);
            time = 0f;
        }
    }
    
}
