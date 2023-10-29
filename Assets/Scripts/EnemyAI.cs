using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    Rigidbody rbEnemy;
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 seekDirection = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(seekDirection * speed * Time.deltaTime);
    }
}
