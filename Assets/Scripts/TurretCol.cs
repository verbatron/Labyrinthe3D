using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCol : MonoBehaviour
{
    public int HealthTurret = 4;                    // Sant� de la Tourelle
    public GameObject explodeParticles;             // Pour Explosions



    private void OnCollisionEnter(Collision collision)  // A Chaque Collision
    {
        if (collision.gameObject.CompareTag("Balle"))     // Avec la Balle Joueur
        {
            HealthTurret -= 1;                          // La Tourelle perd un point de vie a chaque Fois

            if (HealthTurret <= 0)                       // Si la Tourelle est d�truite
            {
                Destroy(this.gameObject);               // On D�truit la Tourelle
                Instantiate(explodeParticles, transform.position, Quaternion.identity);  // On Cr�e l'explosion

            }
        }

    }
        

    
}
