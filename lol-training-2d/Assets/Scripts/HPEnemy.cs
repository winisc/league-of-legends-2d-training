using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    public int vidaAtual;
    public int vidaMaxima;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int danoParaReceber)
    {
        vidaAtual -= danoParaReceber;
        
        if(vidaAtual <= 0)
        {
            gM.countAbates += 1;
            Destroy(this.gameObject);
        }
    }
}

