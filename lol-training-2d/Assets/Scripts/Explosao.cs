using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    public int dano;
    GameManager genMan;

    // Start is called before the first frame update
    void Start()
    {
        genMan = FindObjectOfType<GameManager>();

        dano += genMan.danoMagico;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HPEnemy>().Damage(dano);
        }
    }
}
