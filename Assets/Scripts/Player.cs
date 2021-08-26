//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] int health = 500;
    
    [Header("Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float speedOfLaser = 10f;
    [SerializeField] float shotingPeriod = 0.1f;

    [Header("Move")]
    [SerializeField] float padding = 1f;
    [SerializeField] float speedOfPlayer = 10f;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathVolume = 1f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserVolume = 1f;

    [Header("Death")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;


    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        setUpBoundaries();  
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }
    //MOVE
    private void move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speedOfPlayer;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speedOfPlayer;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos,newYPos);
    }
    private void setUpBoundaries()
    {

        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    //FIRE
    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
            }
            firingCoroutine = StartCoroutine(fireContinuously());


        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    IEnumerator fireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedOfLaser);
            AudioSource.PlayClipAtPoint(laserSound,Camera.main.transform.position,laserVolume);

            yield return new WaitForSeconds(shotingPeriod);
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
        Destroy(gameObject);
        FindObjectOfType<Level>().loadGameOverScene();
        GameObject explosion = Instantiate(deathVFX,transform.position,transform.rotation);
        Destroy(explosion,durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound,Camera.main.transform.position,deathVolume);
    }

    public int getHealth()
    {
        return health;
    }
}
