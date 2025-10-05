using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;                        // Cible
    public GameObject bullet;                       // Prefab Balle Tourelle
    public float force = 5000;                             // Puissance de Tir
    public float reloadTime = 1.5f;                 // Temps entre 2 Tirs
    public Transform posTir;                        // Pour Instancier la Balle Tourelle
    public GameObject canon;                        // Canon de la Tourelle
    public bool canShoot = true;                    // Validation Tir
    public Vector3 targetPosition;
    public float distance;

    private void Update()
    {
            targetPosition = new Vector3(target.position.x, canon.transform.position.y, target.position.z);     // Calcul Position Cible
            canon.transform.LookAt(targetPosition);                                                             // Orientation Tourelle vers Cible
            distance = Vector3.Distance(transform.position, target.position);                                   // Distance entre Tourelle et Joueur 
 
        if (canShoot && distance < 40 && posTir != null)                                                    // Si on Peut Tirer on tire sinon on attend
        {
            canShoot = false;                                                                               // Désactivation Tir
            GameObject go = Instantiate(bullet, posTir.position, Quaternion.identity);                      // On Crée une Balle Tourelle
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force);                                  // On la Propulse
            Destroy(go, 5);                                                                                 // On la Détruit après 5s.
            StartCoroutine(nameof(Reload));                                                                 // Rechargement
        }

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);                                                        // On Attend 1.5 Secondes                                                    
        canShoot = true;                                                                                    // On Revalide le Tir
    }
}

