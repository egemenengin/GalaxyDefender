//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    public int getDamage(){return damage;}

    public void hit(){Destroy(gameObject);}

}
