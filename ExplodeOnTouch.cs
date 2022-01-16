using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    private Rigidbody e1_rigidbody;

    [SerializeField] private float expl_radius = 5.0f;
    [SerializeField] private float expl_power = 10.0f;

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeEnemy()
    {
        Debug.Log("explodeded");

        e1_rigidbody = GetComponent<Rigidbody>();
        e1_rigidbody.AddForce(dir.normalized.x * expl_power, (dir.normalized.y + angle) * expl_power, dir.normalized.z * expl_power, ForceMode.Impulse);
    }
}
