using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCows : MonoBehaviour
{

    GameObject alien;

    private void Start()
    {
        alien = GameObject.Find("Alien");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "Farmer" && collision.gameObject.tag == "Cow")
        {
            collision.gameObject.GetComponent<CowMove>().Moo();
        }

        if(this.gameObject.tag == "Farmer" && collision.gameObject.tag == "Alien")
        {
            StartCoroutine(AlienTriggered());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Cow") || collision.gameObject.tag == ("Alien"))
        {
            Rigidbody2D cowRB = collision.collider.attachedRigidbody;

            cowRB.Sleep();
        }
        

    }

    IEnumerator AlienTriggered()
    {
        yield return new WaitForSeconds(2f);

        alien.GetComponent<Alien>().Angry();
    }
}
