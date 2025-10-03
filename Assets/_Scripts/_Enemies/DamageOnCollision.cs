using System;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour {

    PlayerController Pcontroller;

    private bool alrtkndmg = false;
    public int dmg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start( ) {

    }

    // Update is called once per frame
    void Update( ) {

    }

    private void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.tag == "player" && alrtkndmg == false ) {
            Pcontroller.TakeDamage( dmg );
            alrtkndmg = true;
            Debug.Log( "cwel" );
        }
    }
}
