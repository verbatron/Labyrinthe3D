using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;                  // Inclusions des Espaces de Noms
using UnityEngine.UI;

public class TurretCollision : MonoBehaviour
{
    public int HealthTurret = 4;                    // Santé de la Tourelle
    public GameObject explodeParticles;             // Pour Explosions
    public GameObject pistol;                       // Pour le Pistolet
    public Text TxtFinJeu;                          // Texte Fin de Jeu
    public Text TxtTemps;                           // Texte Temps Restant
    public float remainingTime = 70f;               // Variable Temps Restant


    private void Start()                            // AU Démarrage du Script
    {
        StartCoroutine(nameof(DecompteTemps));                 // Démarrage CoRoutine de Décompte Temps
    }

    private void OnCollisionEnter(Collision collision)  // A Chaque Collision
    {
        if (collision.gameObject.CompareTag("Balle"))     // Avec la Balle Joueur
        {
            HealthTurret -= 1;                          // La Tourelle perd un point de vie a chaque Fois

            if (HealthTurret <= 0)                       // Si la Tourelle est détruite
            {
                Destroy(this.gameObject);               // On Détruit la Tourelle
                Instantiate(explodeParticles, transform.position, Quaternion.identity);  // On Crée l'explosion
                TxtFinJeu.text = "VICTOIRE ! 'ESCAPE' POUR QUITTER.";  // Texte Victoire 

            }
        }

    }

    private void Update()                               // A Chaque Image 
    {
        if (remainingTime <= 0f && HealthTurret > 0)        // Si le Temps est écoulé et que la Tourelle n'est pas détruite
        {
            if (TxtFinJeu != null && string.IsNullOrEmpty(TxtFinJeu.text))                           // Si le Texte Fin Jeu est valide
            {
                TxtFinJeu.text = "DEFAITE. APPUYER 'R' POUR REJOUER";                       // On affiche la Défaite //
            }

            if (pistol != null)                         // Si le Prefab du Pistolet est valide
            {
                Destroy(pistol);                        // On le Supprime
            }

            if (Input.GetKey(KeyCode.R))                // Puis si Appui sur 'r' 
            {
                SceneManager.LoadScene(0);              // On Recharge la Scène
            }
        }

        if (remainingTime > 0f && HealthTurret <= 0)    // Si le Temps n'est pas ecoulé et que la Tourelle est détruite
        {
            if (TxtFinJeu != null && string.IsNullOrEmpty(TxtFinJeu.text))  // Si le Texte Fin Jeu est valide
            {
                TxtFinJeu.text = "VICTOIRE ! 'ESCAPE' POUR QUITTER.";       // On affiche la Victoire
            }

            if (Input.GetKey(KeyCode.Escape))           // Puis si Appui sur 'ESC'
            {
                Application.Quit();                     // On Quitte le Jeu //
            }
        }


    }

    private IEnumerator DecompteTemps()                 // CoRoutine de Décompte Temps
    {
        while (remainingTime > 0f)                      // Si Temps Restant Positif
        {
            if (TxtTemps != null)                       // Si le Texte Temps est valide
            {
                TxtTemps.text = remainingTime.ToString();   // On l'affiche dans la Scène
            }
            yield return new WaitForSeconds(1f); // Attends 1 seconde AVANT de décrémenter

            remainingTime--;                            // On Décrémente le Temps Restant
        }

        if (TxtTemps != null)                           // Si le Texte Temps est valide
        {
            TxtTemps.text = "0".ToString();         // Pour MAJ Affichage Valeur '0' //
        }

    }


}



