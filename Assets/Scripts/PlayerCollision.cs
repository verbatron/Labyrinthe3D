using System.Collections;
using UnityEngine;                                      // Directives Inclusions
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerCollision : MonoBehaviour
{
    public Text TxtFinJeu;                              // Texte Fin de Jeu
    public int HealthPlayer = 7;                        // Valeur Sant� de D�part Joueur
    public AudioClip SonDouleur;                        // Son de Souffrance du Joueur
    public bool ValidFin = false;                       // Pour Valider la Fin de Jeu 
    public GameObject Pistol;                           // R�f�rence dans le Script au Pistolet 



    void OnCollisionEnter(Collision collision)  // A la d�tection d'une collision
    {
        if (collision.gameObject.CompareTag("Tourelle"))    // Entre le Joueur et la Balle Tourelle
        {
            Destroy(collision.gameObject);                  // On D�truit la Balle Tourelle
            HealthPlayer--;                                 // Le Joueur perd un Point de Vie
            GetComponent<AudioSource>().PlayOneShot(SonDouleur);    // On Joue le Son de Douleur si Valid� 


            if (HealthPlayer <= 0)                      // Si le Joueur Meurt
            {
                ValidFin = true;                        // On Valide la Fin du Jeu
                TxtFinJeu.text = "DEFAITE.APPUYEZ 'R' POUR REJOUER";   // Affiche la D�faite
                Destroy(Pistol);             // On D�truit le Pistolet 
                AudioListener.pause = true;         // On Arr�te tous les Sons 
            }


        }


    }

    private void Update()
    {
        if (ValidFin && Input.GetKeyDown(KeyCode.R))   // Si on est en fin de Jeu et qu'on appuie sur 'r'
        {
            AudioListener.pause = false;                    // On R�active les Sons
            SceneManager.LoadScene(0);                       // On Recharge le Jeu
        }
    }
 
            

}


 
            
       

 
