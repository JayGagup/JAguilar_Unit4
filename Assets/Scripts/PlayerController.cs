using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float speed = 10.0f;
    GameObject focalPoint;
    Renderer Colorshift;
    public float powerUpSpeed = 10.0f;
    bool hasPowerUp = false;
    public GameObject powerUpInd;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        Colorshift = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardinput = Input.GetAxis("Vertical");
        float magnitud = forwardinput * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * magnitud, ForceMode.Impulse);

        if (forwardinput > 0)
        {
          
            Colorshift.material.color = new Color(1.0f - forwardinput, 1.0f, 1.0f- forwardinput);
        }
        else
        {
            Colorshift.material.color = new Color(1.0f + forwardinput, 1.0f, 1.0f + forwardinput);

        }

        powerUpInd.transform.position = transform.position;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUpInd.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDir = collision.gameObject.transform.position - transform.position;
            rbEnemy.AddForce(awayDir * powerUpSpeed, ForceMode.Impulse);
        }

    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpInd.SetActive(false);
    }

}
