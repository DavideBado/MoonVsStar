using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int Power;
    float timer = 0.1f, timerSaved = 0.1f;
    public int BulletLevel = 1;
    public int Speed;
    // Update is called once per frame
    void Update()
    {
        GoBulletGo();
        PowerOfColors();
    }
    void GoBulletGo()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, Speed * Time.deltaTime);   // Verso l'infinito e oltre
    }

    void PowerOfColors() // Potere dei colori!
    {
        if(BulletLevel == 1) // Se sono un proiettile sfigato
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);  // Sono piccolo
            GetComponent<Renderer>().material.color = Color.yellow; // Giallo
            Power = 1; // E non faccio un cazzo di danno
        }
        else if (BulletLevel == 2) // Per fortuna non sono sfigato, sarò forse un proiettile medio?
        {
            transform.localScale = new Vector3(0.5f, 1f, 0.5f); // Sono medio
            GetComponent<Renderer>().material.color = Color.red; // Sono rosso
            Power = 5; // Faccio male

        }
        else if (BulletLevel == 3) // Ma non mi dire, ho i pugni nei colori
        {
            transform.localScale = new Vector3(0.5f, 1.5f, 0.5f); // Sono grande
            Power = 10; // Faccio male
            timer -= Time.deltaTime; // Conto il tempo
            if(timer <= 0) // Quando finisce il tempo
            {
                GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1); // Cambio colore a cazzo di cane
                timer = timerSaved; // E torno a contare
            }
        } else if(BulletLevel <= 0) // Ah, come dici? Non ero neanche il super proiettile
        {
            Destroy(gameObject); // Allora aspetta che vado a suicidarmi
        }
        
    }

    public void Damage() // Quando mi fanno male
    {
        BulletLevel--; // Perdo vitalivello
    }

    private void OnTriggerEnter(Collider other) // Quando entro in contatto con
    {
        if (other.GetComponent<Enemy>() != null) // Un nemico
        {
            other.GetComponent<Enemy>().Damage(Power); // Mi pensa che lui è maxi maxi triste
            Destroy(gameObject); // Poi però mi sparo
        }
        else if (other.GetComponent<Cleaner>() != null) // Uno spazzino
        {
            Destroy(gameObject); // Niente da fare, spazzino OP
        }

    }
}
