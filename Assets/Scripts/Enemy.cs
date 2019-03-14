using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int life;
    public int LevelID = 1;
    float Speed = 4.8f, AttackTimer, savedTime;
    public GameObject bullet;
    Vector3 CurrentTarget;
    int i = 0;
    public List<Vector3> targets = new List<Vector3>();
    int BulletType;
    // Start is called before the first frame update
    void Start()
    {
        life = LevelID * 10; // La mia vita dipende dal livello
        savedTime = (3.1f - (0.1f * LevelID)); // Il mio ritmo di attacco dipende dal livello
        AttackTimer = savedTime;
        CurrentTarget = targets[i]; // Ecco la mia prima destinazione
    }

    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InUpdate()
    {
        EnemyMove();
        Attack();
    }
    void Attack()
    {
        AttackTimer -= Time.deltaTime; // Aspetto di poter attaccare
        if (AttackTimer <= 0) // Se è arrivato il momento giusto
        {
    
            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity); // Creo un proiettile
            _bullet.transform.parent = transform.parent; // Lo metto nel livello
            AttackTimer = savedTime; // Torno ad aspettare
        }
    }

    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime); // Mi muovo verso la mia destinazione
        if (transform.position == CurrentTarget) // Quando arrivo a destinazione
        {
            if (i == (targets.Count - 1)) // Se era l'ultima destinazione
            {
                i = 0; // Torno alla prima
            }
            else i++; // Se non lo era allora passo alla prossima
            CurrentTarget = targets[i]; // Aggiorno la destinazione
        }
    }

    public void Damage(int _power) // Mi hanno colpito
    {
        life -= _power; // Perdo vita in relazione alla potenza del colpo
    }
     
}

