using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCol : MonoBehaviour
{
    public int HealthTurret = 4;                    // Santé de la Tourelle
    public GameObject explodeParticles;             // Pour Explosions



    private void OnCollisionEnter(Collision collision)  // A Chaque Collision
    {
        if (collision.gameObject.CompareTag("Balle"))     // Avec la Balle Joueur
        {
            HealthTurret -= 1;                          // La Tourelle perd un point de vie a chaque Fois

            if (HealthTurret <= 0)                       // Si la Tourelle est détruite
            {
                Destroy(this.gameObject);               // On Détruit la Tourelle
                Instantiate(explodeParticles, transform.position, Quaternion.identity);  // On Crée l'explosion

            }
        }

    }
        

    
}
