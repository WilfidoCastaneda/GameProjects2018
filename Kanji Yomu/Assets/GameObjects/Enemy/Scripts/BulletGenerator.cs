using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public BulletPool bulletPool;
    private GameObject currentBullet;

    public int linesPerSpread;
    public int spreadAngle;
 
    public int numSpreads;
    public int angleOfSpreads;
  
    public int spinSpeed;
    public int spinSpeedChange;
    public int rotation;
    public bool spinSpeedReverse;
    public int maxSpinSpeed;
    public float  fireRate;
    public float bulletSpeed;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
        countDown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0.0f)
        {
            currentBullet = bulletPool.GetBullet();
            currentBullet.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 0.7f, this.transform.position.z);
            currentBullet.SetActive(true);
            currentBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -bulletSpeed));

            countDown = fireRate;
        }
    }
}
