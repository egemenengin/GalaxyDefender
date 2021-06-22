using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] int health = 500;
    [SerializeField] int scoreValue = 50;
    [Header("Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float speedOfLaser = 10f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    float shotCounter;

    [Header("Move")]
    [SerializeField] float speedOfPlayer = 10f;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathVolume = 1f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserVolume = 1f;
    [Header("Death")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots,maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        countDownAndShoot();
    }
    private void fire()
    {
        GameObject laser = Instantiate(laserPrefab,transform.position,Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-speedOfLaser);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);
    }
    private void countDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            fire();
            shotCounter = Random.Range(minTimeBetweenShots,maxTimeBetweenShots);
        }
        {

        }
    }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            damageDealer damageDeal = other.GetComponent<damageDealer>();
            if (damageDeal == null)
            {
                Crash();
            }
            else
            {
                hitProcess(damageDeal);
            }


        }

        private void Crash()
        {
            health -= 100;
            if (health <= 0)
            {

                die();
            }
        }
        private void hitProcess(damageDealer damageDeal)
    {
        health -= damageDeal.getDamage();
        damageDeal.hit();
        if (health <= 0)
        {
            die();
        }
    }
    private void die()
    {
        FindObjectOfType<gameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX,transform.position,transform.rotation);
        Destroy(explosion,durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);

    }
}
