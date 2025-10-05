using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject projectile;               // Pour Stocker le Prefab de la Balle //
    public Transform posTir;                    // Position d'instanciation de Projectiles //
    public float force;                         // Puissance de Tir //
    public int HealthPlayer;                    // Valeur Santé Joueur //
    public AudioClip SonTir;                    // Pour le Son du Tir Joueur //

    void Update()
    {
        if(Input.GetMouseButtonDown(0))         // Pour un Clic Bouton Gauche //
        {
            GameObject go = Instantiate(projectile, posTir.position, Quaternion.identity);      // Création du Projectile //
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force);                      // On Propulse le Projectile //
            GetComponent<AudioSource>().PlayOneShot(SonTir);                                    // On Joue le Son du Tir //
            Destroy(go, 3);                                                                     // On Détruit le Projectile après 3 Secondes //
        }

    }

}
