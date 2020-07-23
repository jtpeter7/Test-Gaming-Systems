using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingArm : MonoBehaviour {

    public bool RunAnime = false;
    public float swingSpeed;
    public Transform startMarker;
    public Transform blade;
    int timepassed = 0;
    Quaternion mySpawnRotation;
    public Transform AttackBall;
    GameObject[] gameObjects;
    public bool DeleteOnClick, DeleteAfterClick;
    public float SwingDistance;

    void Start () {
        startMarker = transform;
        mySpawnRotation = transform.localRotation;
    }
	

	void Update () {
        if (Input.GetMouseButtonDown(0) && RunAnime == false)
        {
            RunAnime = true;
            timepassed = 0;
            if (DeleteOnClick)
            {
                gameObjects = GameObject.FindGameObjectsWithTag("AttackBall");

                for (var i = 0; i < gameObjects.Length; i++)
                    Destroy(gameObjects[i]);
            }
            
        }

        if (RunAnime == true)
        {
            transform.Rotate(2*swingSpeed, -2 * swingSpeed, 0, Space.Self);
            timepassed++;
            Transform Attack = Instantiate(AttackBall, new Vector3(0, 0, 0), Quaternion.identity);
            Attack.transform.parent = blade;
            Attack.transform.localPosition = new Vector3(0, SwingDistance/2, 0);
            Attack.transform.localRotation = blade.rotation;
            Attack.transform.localRotation = new Quaternion(0, -45, 0, 0);
            Attack.transform.localScale = new Vector3(0.1F, SwingDistance, .1F);
            Attack.tag = "AttackBall";
            Attack.transform.parent = gameObject.transform.parent;
            Attack.GetComponent<AttackCollisionWithPlayer>().PID = gameObject.transform.parent.parent.GetComponent<PlayerID>().PlayerIDINT;
            Attack.transform.parent = null;
            //Attack.GetComponent<AttackCollisionWithPlayer>().Penetration = 

            if (timepassed*swingSpeed >= 30 )
            {
                RunAnime = false;
                transform.localRotation = mySpawnRotation;
            }
        }
        if (RunAnime == false && DeleteAfterClick)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("AttackBall");

            for (var i = 0; i < gameObjects.Length; i++)
                Destroy(gameObjects[i]);
        }




    }
}
