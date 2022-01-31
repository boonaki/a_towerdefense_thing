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
    
    

    void Start()
    {
        e1_rigidbody = GetComponent<Rigidbody>(); //gets the rigidbody of the fish

        target = Waypoints.points[0]; //selects the target transform to be the position of the waypoint set in game
        currentpos = transform.position; //currentpos of enemy
        dir = target.position - transform.position; //dirction to jump
        
        //-----------Jumping-------------
        e1_rigidbody.AddForce(dir.normalized.x * force, (dir.normalized.y + angle) * force, dir.normalized.z * force, ForceMode.Impulse);
        e1_rigidbody.AddTorque(Vector3.up * angle);
        e1_rigidbody.AddTorque(Vector3.forward);
        //-------------------------------

    }

    void FixedUpdate() //called every other frame or something like that
    {
        speed = e1_rigidbody.velocity.magnitude; //sets speed to the velocity of enemy1
        Angular_Speed = e1_rigidbody.angularVelocity.magnitude; //sets angular speed to angular velocity of enemy1
        dir = target.position - transform.position; //current direction to go is the target position - enemy pos
        e1_rigidbody.WakeUp(); //added cause of other issues

    }

    void OnCollisionEnter(Collision collision) //on collision, set time to 0
    {
        
        time = 0;

    }

    
    public void OnCollisionStay(Collision collision) //when collided, increment time and repeat the jump
    {
        time += Time.deltaTime;
        
       

        if (collision.gameObject.name == "map2" && time >= time_val)
        {
            //-----------Jumping-------------
            e1_rigidbody.AddForce(dir.normalized.x * force, (dir.normalized.y + angle) * force, dir.normalized.z * force, ForceMode.Impulse);
            e1_rigidbody.AddTorque(Vector3.forward);
            e1_rigidbody.AddTorque(Vector3.up * angle);
            //-------------------------------

            time = 0f; //resets time
        }
    }
    
}
