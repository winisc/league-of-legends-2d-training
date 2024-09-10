using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkill_Area : MonoBehaviour
{
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;

    public int dano;
    GameManager genMan;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0 , rot + 90);

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