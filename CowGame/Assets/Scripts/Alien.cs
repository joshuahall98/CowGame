using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed;

    Vector3 newPos;
    Vector3 moveDirection;

    [SerializeField] float timerMove = 2;
    [SerializeField] float timerMoo;


    public int randomizer;
    int randomizerMove;

    bool canMove;
    public static bool angry;

    AudioSource audio;

    public GameObject mooBubble;
    GameObject player;
    public GameObject cowSprite;
    public GameObject evilCowSprite;

    SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        timerMoo = Random.Range(5, 21);
        mooBubble.SetActive(false);
        player = GameObject.Find("Farmer");
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timerMove -= Time.deltaTime;
        timerMoo -= Time.deltaTime;

        moveDirection = gameObject.transform.position - newPos;

        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (timerMove <= 0)
        {
            randomizer = Random.Range(0, 2);

            if (randomizer == 0)
            {
                canMove = true;
                RandomDirection();
            }
            else
            {
                canMove = false;
            }

            timerMove = 2;

        }

        if (timerMoo <= 0)
        {
            Moo();
            timerMoo = Random.Range(3, 11);
        }

        if (!audio.isPlaying)
        {
            mooBubble.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove == true && angry == false)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPos, step);
        }
        else if(angry == true && player != null)
        {
            var step = speed* Time.deltaTime;
            newPos = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, newPos, step);
        }

    }

    void RandomDirection()
    {
        randomizerMove = Random.Range(0, 4);

        if (randomizerMove == 0)
        {
            newPos = new Vector3(transform.position.x + 1, 0f, 0f);
        }
        else if (randomizerMove == 1)
        {
            newPos = new Vector3(transform.position.x - 1, 0f, 0f);
        }
        else if (randomizerMove == 2)
        {
            newPos = new Vector3(0, transform.position.y + 1, 0f);
        }
        else if (randomizerMove == 3)
        {
            newPos = new Vector3(0, transform.position.y - 1, 0f);
        }
    }

    public void Moo()
    {
        audio.Play();
        mooBubble.SetActive(true);

    }

    public void Angry()
    {
        speed = speed * 6;
        angry = true;
        //render.color = new Color(1, 0, 0);
        evilCowSprite.SetActive(true);
        cowSprite.SetActive(false);
        Moo();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(angry == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
