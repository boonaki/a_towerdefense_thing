using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float velocity = 50f;
    public GameObject impacteffect;
    //public float expl_radius = 3.0f;
    //public float expl_power = 1.5f;
    [SerializeField] private float angle = 1f;
    


    private Transform target;
    private Rigidbody bullet_rb;
    //private Rigidbody bullet_clone;
    private Vector3 dir;

   

    public void Seek(Transform _target) //calls target position found in Tracking script
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            Debug.Log("destroyed");
            return;
        }

        dir = target.position - transform.position; //maybe modify to grab direction from tracking script
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //if current distance to target is less than the distance to target that frame
        {
            //add logic for when target is hit
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget() //what happens when we hit our target
    {
        
        var impact = Instantiate(impacteffect, transform.position, transform.rotation);
        Debug.Log("we shot someone");
        Destroy(impact, .5f);
        gameObject.SetActive(false);
        
        Damage();

 

    }

    void Damage()
    {
        //kill


    }
   /*
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Terrain") 
        {
            Debug.Log("Bullet collision");

            collision.rigidbody.AddForce(dir.normalized.x * expl_power, (dir.normalized.y + angle) * expl_power, dir.normalized.z * expl_power, ForceMode.Impulse);

        }
        return;

    }
    */
}