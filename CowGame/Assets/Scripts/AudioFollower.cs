using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFollower : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Farmer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 100);
    }
}
