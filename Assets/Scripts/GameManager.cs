using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver, Level;
    Vector3 EnemySpawnPoint, PlayerSpawnPoint;
    Enemy enemy;
    PlayerBase earth;
    public GameObject EnemyPref, PlayerPref;
    int LevelID;
    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    
    void InUpdate()
    {
        EnemyLife(); // Controllo la vita del cubo in alto
        PlayerLife(); // Controllo la vita della sfera in basso
        if(Level.activeSelf == true) // Dimmi livello, sei attivo?
        {
            InStart(); // Ok, iniziamo
        }
    }

    void InStart() // Si inizia
    {
        LevelID = 1; // Siamo al livello 1
        enemy = FindObjectOfType<Enemy>(); // Il nemico è un oggetto di tipo nemico, lo cerco
        EnemySpawnPoint = enemy.transform.position; // Salvo la sua posizione come posizione iniziale di riferimento
        earth = FindObjectOfType<PlayerBase>(); // Cerco la sfera
        PlayerSpawnPoint = earth.transform.position; // Ne salvo la posizione iniziale
    }

    void EnemyLife()
    {
        if (enemy != null) // Ok, prima l'avevo trovato il nemico?
        {
            enemy.LevelID = LevelID; // Il al nemico serve sapere in che livello siamo
            if (enemy.life <= 0) // La vita del nemico è minore o uguale a 0?
            {
                Clean(); // Facciamo pulizia
                LevelID++; // Passiamo al livello successivo
                Destroy(enemy.gameObject); // Distruggo il nemico attuale
                GameObject _enemy = Instantiate(EnemyPref, EnemySpawnPoint, Quaternion.identity); // Creo un nuovo nemico
                _enemy.transform.parent = Level.transform; // Lo metto come figlio del livello
                enemy = _enemy.GetComponent<Enemy>(); // Aggiorno i contatti del nemico sulla mia agenda
            }
        }
    }
    void PlayerLife()
    {
        if (earth != null) // Avevo trovato la sfera?
        {
            if (earth.life <= 0) // La vita dello sfero è minore o uguale a 0?
            {
                Clean(); // Facciamo pulizia
                GOver(); // Chi giocava ha perso, peccato ci stavamo divertendo
                LevelID = 1; // Siamo nuovamente al livello 1
                Destroy(earth.gameObject); // Distruggo la sfera
                GameObject _earth = Instantiate(PlayerPref, PlayerSpawnPoint, Quaternion.identity); // Ne posiziono una nuova
                _earth.transform.parent = Level.transform; // La metto dentro il livello
                earth = _earth.GetComponent<PlayerBase>(); // Aggiorno i contatti
            }
        }
    }

    void GOver()
    {
        GameOver.SetActive(true); // Accendo la schermata di gameover
        Level.SetActive(false); // Spengo il livello
    }

    void Clean()
    {
        List<Bullet> bullets = FindObjectsOfType<Bullet>().ToList(); // Cerco nella scena tutti i proiettili del giocatore
        List<enemyBullet> enemyBullets = FindObjectsOfType<enemyBullet>().ToList();  // Cerco nella scena tutti i proiettili del nemico

        foreach (var item in bullets) // Distruggo ogni proiettile del giocatore
        {
            Destroy(item.gameObject);
        }

        foreach (var item in enemyBullets) // Distruggo ogni proiettile del nemico
        {
            Destroy(item.gameObject);
        }
    }
}
