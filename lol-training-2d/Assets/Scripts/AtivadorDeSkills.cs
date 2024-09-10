using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeSkills: MonoBehaviour
{
    
    [SerializeField] private float timerToAutoAtck = 0;
    public float timerToQ;
    public float timerToW;
    public float timerToE;
    public float timerToR;

    [SerializeField] private bool autoAtck = false;
    [SerializeField] private bool delayAutoAtck = false;
    [SerializeField] private bool skillQ = false;
    [SerializeField] private bool skillW = false;
    [SerializeField] private bool skillE = false;
    public bool temEscudo;
    [SerializeField] private bool skillR = false;

    [SerializeField] private GameObject areaDeAtck;

    [SerializeField] private GameObject autoAtck_obj;
    [SerializeField] private Transform autoAtck_pos;

    [SerializeField] private GameObject skillq_obj;
    [SerializeField] private Transform skillq_pos;

    [SerializeField] private GameObject skillw_obj;
    [SerializeField] private Transform skillw_pos;

    [SerializeField] private GameObject skille_obj;
    //[SerializeField] private Transform skille_pos;

    [SerializeField] private GameObject skillr_obj;
    [SerializeField] private Transform skillr_pos;

    public float velocidadeDeAtaque;

    private Buttons buttons;

    Player_HP player;

    Layout layout;
    
    // Start is called before the first frame update
    void Start()
    {
        skille_obj.SetActive(false);

        buttons = FindObjectOfType<Buttons>();
        
        velocidadeDeAtaque = .8f;

        player = FindObjectOfType<Player_HP>();
        layout = FindObjectOfType<Layout>();

        timerToQ = 4;
        timerToW = 4;
        timerToE = 9;
        timerToR = 4;

        layout.timerQ.enabled = false;
        layout.timerW.enabled = false;
        layout.timerE.enabled = false;
        layout.timerR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Q();
        TimerQ();

        W();
        TimerW();

        E();
        TimerE();

        R();
        TimerR();

        AtivarAutoAtck();
        AutoAtck();
        TimerAutoAtck();
    }

    private void AtivarAutoAtck()
    {
        if(Input.GetKeyDown(KeyCode.A) && !autoAtck && !delayAutoAtck)
        {
            areaDeAtck.SetActive(true);
            Debug.Log("AutoAtck ativada");
            autoAtck = true;
        }

    }

    private void AutoAtck()
    {

        if(Input.GetMouseButton(0) && autoAtck && !delayAutoAtck)
            {
                areaDeAtck.SetActive(false);
                Instantiate(autoAtck_obj, autoAtck_pos.position, Quaternion.Euler(0f, 0f, 0f));
                delayAutoAtck = true;
                autoAtck = false;
            }
    }

    private void Q()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !skillQ && buttons.habilidadeQDisponivel && player.manaAtualPlayer >= 25)
        {
            Debug.Log("Skill Q ativada");
            skillQ = true;

            Instantiate(skillq_obj, skillq_pos.position, Quaternion.Euler(0f, 0f, 0f));

            player.ConsumirMana(25);
        }
    }

    private void W()
    {
        if(Input.GetKeyDown(KeyCode.W) && !skillW && buttons.habilidadeWDisponivel && player.manaAtualPlayer >= 25)
        {
            Debug.Log("Skill W ativada");
            skillW = true;

            Instantiate(skillw_obj, skillw_pos.position, Quaternion.Euler(0f, 0f, 0f));

            player.ConsumirMana(25);
        }
    }

    private void E()
    {
        if(Input.GetKeyDown(KeyCode.E) && !skillE && buttons.habilidadeEDisponivel && player.manaAtualPlayer >= 25)
        {
            Debug.Log("Skill E ativada");
            skillE = true;
            temEscudo = true;

            skille_obj.SetActive(true);

            player.ConsumirMana(25);
        }
    }

    private void R()
    {
        if(Input.GetKeyDown(KeyCode.R) && !skillR && buttons.habilidadeRDisponivel && player.manaAtualPlayer >= 25)
        {
            Debug.Log("Skill R ativada");
            skillR = true;

            Instantiate(skillr_obj, skillr_pos.position, Quaternion.Euler(0f, 0f, 0f));

            player.ConsumirMana(25);
        }  
    }

    private void TimerAutoAtck()
    {
        if(delayAutoAtck == true)
        {
            timerToAutoAtck += Time.deltaTime;
            if(timerToAutoAtck >= velocidadeDeAtaque)
            {
                delayAutoAtck = false;
                timerToAutoAtck = 0;
            }
        }
    }
    private void TimerQ()
    {
        if(skillQ == true)
        {
            layout.timerQ.enabled = true;
            timerToQ -= Time.deltaTime;
            if(timerToQ <= 1)
            {
                layout.timerQ.enabled = false;
                skillQ = false;
                timerToQ = 4;
            }
        }
    }

    private void TimerW()
    {
        if(skillW == true)
        {
            layout.timerW.enabled = true;
            timerToW -= Time.deltaTime;
            if(timerToW <= 1)
            {
                layout.timerW.enabled = false;
                skillW = false;
                timerToW = 4;
            }
        }
    }

    private void TimerE()
    {
        if(skillE == true)
        {
            layout.timerE.enabled = true;
            timerToE -= Time.deltaTime;
            if(timerToE <= 6)
            {
                skille_obj.SetActive(false);
                temEscudo = false;
            }
            
            if(timerToE <= 1)
            {
                layout.timerE.enabled = false;
                timerToE = 9;
                skillE = false;
            }
        }
    }

    private void TimerR()
    {
        if(skillR == true)
        {
            layout.timerR.enabled = true;
            timerToR -= Time.deltaTime;
            if(timerToR <= 1)
            {
                layout.timerR.enabled = false;
                skillR = false;
                timerToR = 4;
            }
        }
    }
}
