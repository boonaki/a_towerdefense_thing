using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class Tracking : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]

    public float range = 5f;
    public float firerate = 1f;
    private float firecountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public float turnSpeed = 5f;
    public Transform parttoRotate;
    public Transform head_Rotate;

    public GameObject bulletPrefab;
    public GameObject smokeRing;
    public Transform firePoint;
    private ObjectPool<GameObject> bulletpool;
    public GameObject nearestEnemy;



    void Start()
    {

        InvokeRepeating("UpdateTarget", 0f, 0.5f); //runs UpdateTarget ~2 times a ssecond
        
        bulletpool = new ObjectPool<GameObject>(() => {
            return Instantiate(bulletPrefab);
        }, projectile => {
            gameObject.SetActive(true);
        }, projectile => {
            gameObject.SetActive(false); 
        }, projectile => {
            Destroy(gameObject);
        }, false, 10, 20);
        
    }
    /*
    private void Awake()
    {
        bulletpool = new ObjectPool<Bullet>(CreatePooledObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, false, 10, 20);
    }

    private Bullet ReturnObjectToPool()
    {
        Bullet instance = Instantiate(bulletPrefab, Vector3.zero, Quarternion.identity);
    }
    private void OnTakeFromPool()
    {
        Instance.gameObject.SetActive(true);
        SpawnBullet(Instance);
    }
    */
    

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //finds all enemies, stores in array

        float shortestroute = Mathf.Infinity; //shortest route
        nearestEnemy = null; //enemy with shortest route

        foreach (GameObject enemy in enemies) //for every enemy in enemies array...
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position); //assigns distance to the called enemy
            if (distancetoEnemy < shortestroute) //if distance to enemy is less than the shortest route...
            {
                shortestroute = distancetoEnemy; //shortest route becomes distance to called enemy and the called enemy becomes the nearest enemy
                nearestEnemy = enemy;
            }
        }

        //try to find a more performant way to look for targets

        if (nearestEnemy != null && shortestroute <= range)
        {
            target = nearestEnemy.transform;
            //Debug.Log("target found");
        }
        else
        {
            target = null;
            //Debug.Log("target lost");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 headrotation = Quaternion.Lerp(head_Rotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        head_Rotate.rotation = Quaternion.Euler(0f, headrotation.y, 0f);


        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }

        firecountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        Debug.Log("SHOOT");
        var smoke = Instantiate(smokeRing, firePoint.position, firePoint.rotation);
        GameObject projectile = bulletpool.Get();
        //GameObject projectile = ObjectPool.SharedInstance.getPooledObject();
        if (projectile != null)
        {
            //Debug.Log("spawned bullet");
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            
        }

        //GameObject projectileGO = GameObject.FindWithTag("Bullet");
        //projectileGO = projectileGO.GetComponent<bulletPrefab>();

        
        //GameObject projectile = (GameObject)Instantiate(projectileGO, firePoint.position, firePoint.rotation);
        Bullet bullet = projectile.GetComponent<Bullet>();




        if (projectile != null && nearestEnemy != null)
        {
            //Debug.Log("seeking");
            bullet.Seek(target, nearestEnemy);
        }

        Destroy(smoke, 2f);

    }

    void OnDrawGizmosSelected() //draws a red circle around turret indicating its range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
