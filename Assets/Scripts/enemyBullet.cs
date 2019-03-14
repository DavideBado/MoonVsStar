using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemyBullet : MonoBehaviour
{
    bool OnRot = false;
    Vector3 rotation;
    float Speed = 6.34f;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0.0f, 0.0f, Random.Range(-45.0f, 45.0f));
        transform.Rotate(rotation);
      
    }

    // Update is called once per frame
    void Update()
    {
        FollowTheRoad();
        Gooo();
    }

    private void Gooo()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime); // Mi sposto verso giù, verso il mio concetto di giù
    }

    void FollowTheRoad()
    {
        if(transform.position.x >= 7f && OnRot == false) // Se ho raggiunto il margine destro e non mi sto già girando
        {
            rotation += new Vector3(0, 0, -90); // Mi giro
            transform.Rotate(rotation);
            transform.position += new Vector3(-0.3f * Time.deltaTime, 0, 0); // Faccio un salto verso il centro
            OnRot = true; // Mi sto girando
        }
        if (transform.position.x <= -7f && OnRot == false) // Se ho raggiunto il margine sinisto e non mi sto già girando
        {
            rotation += new Vector3(0, 0, 90);
            transform.Rotate(rotation); // Mi giro
            transform.position += new Vector3(0.3f * Time.deltaTime, 0, 0);
            OnRot = true;
        }
        if (!(transform.position.x >= 7f || (transform.position.x <= -7f )) && OnRot == true) // Se non sono più sui margini e mi sto girando
        {
            OnRot = false; // No non mi sto girando
        }
    }

    private void OnTriggerEnter(Collider other) // Se collido
    {
        if(other.GetComponent<Player>() != null) // Con il cubo del giocatore
        {
            Destroy(gameObject); // Mi distruggo
        } else if(other.GetComponent<PlayerBase>() != null) // Con la sfera del giocatore
        {
            other.GetComponent<PlayerBase>().Damage(); // La danneggio
        }
        else
        if (other.GetComponent<Bullet>() != null) // Con un proiettile del giocatore
        {
            other.GetComponent<Bullet>().Damage(); // Lo danneggio
            Destroy(gameObject); // E mi distruggo
        } else if (other.GetComponent<Cleaner>() != null) // Con uno spazzino
        {
            Destroy(gameObject); // Mi distruggo
        }
    }
}
