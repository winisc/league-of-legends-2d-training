using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMinionGue : MonoBehaviour
{
    [SerializeField] private Transform alvo;
    [SerializeField] private float speed;

    Player_HP playerHP;
    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        playerHP = FindObjectOfType<Player_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

    }

    private void FollowPlayer()
    {
        if(alvo.position != null)
        {
            transform.position =  Vector2.MoveTowards(transform.position, alvo.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            playerHP.MachucarJogador(25);
        }
    }
}
