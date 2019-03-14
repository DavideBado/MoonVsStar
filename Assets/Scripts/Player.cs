using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 TargetR, TargetL;
    public GameObject bullet;
    public Camera Camera;
    float GunTimer = 0;
    
    // Update is called once per frame
    void Update()
    {       
        InUpdate();       
    }

    private void OnMouseDrag() // Quando mi cliccano sopra con il tasto sinistro del mouse e finché non rilasciano quest'ultimo
    {        
        GunTimer += Time.deltaTime; // Conto il tempo
        if((transform.position.x < TargetR.x && Input.GetAxisRaw("Mouse X") > 0 || 
            (transform.position.x > TargetL.x && Input.GetAxisRaw("Mouse X") < 0))) // Quando sono dentro ai margini o nel caso fossi oltre un margine se il mouse non prosegue oltre il margine come se fosse antani la supercazzola con lo scappellamento a destra
        {
            transform.position += new Vector3(0.5f * Input.GetAxisRaw("Mouse X"), 0); // Mi sposto in base al movimento orizzontale del mouse
        }
}

    void InUpdate()
    {
        Shoot();
    }

    void Shoot() // Spara Jurij spara
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))  // Quando il tasto sinistro del mouse viene rilasciato
        {
            // Se il tempo che avevo contato quando il tasto era premuto è:
            if (GunTimer > 2 && GunTimer < 4) // Compreso tra 2 e 4
            {
                // Spara colpo 1
                GameObject bullet1 = Instantiate(bullet, transform.position, Quaternion.identity);              
                bullet1.GetComponent<Bullet>().BulletLevel = 1;
                GunTimer = 0; // Torna a contare
            }
            else
            if (GunTimer > 4 && GunTimer < 6)  // Compreso tra 4 e 6
            {
                // Spara colpo 2
                GameObject bullet2 = Instantiate(bullet, transform.position, Quaternion.identity);
                bullet2.GetComponent<Bullet>().BulletLevel = 2;
                GunTimer = 0; // Torno a contare
            }
            else
            if (GunTimer > 6) // Maggiore di 6
            {
                // Spara colpo 3
                GameObject bullet3 = Instantiate(bullet, transform.position, Quaternion.identity);               
                bullet3.GetComponent<Bullet>().BulletLevel = 3;
                GunTimer = 0;// Turbotorno a contare
            }
        }
    }
}
