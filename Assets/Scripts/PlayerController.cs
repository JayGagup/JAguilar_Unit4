using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float speed = 10.0f;
    GameObject focalPoint;
    Renderer Colorshift;
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


    }
}
