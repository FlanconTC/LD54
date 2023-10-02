using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    public LayerMask crateLayer; // Layer où se trouvent les crates

    private List<GameObject> boxesInsideCrate = new List<GameObject>();
    public void FindCollidingObjects(GameObject box)
    {
        List<GameObject> collidingObjects = new List<GameObject>();
        PolygonCollider2D boxCollider = box.GetComponent<PolygonCollider2D>();

        if (boxCollider != null)
        {
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = false; // Si vous ne voulez pas inclure les triggers

            // Tableau pour stocker les colliders en chevauchement
            PolygonCollider2D[] overlappingColliders = new PolygonCollider2D[10]; // Ajustez la taille du tableau au besoin

            // Utilisez Physics2D.OverlapCollider pour trouver les colliders en chevauchement
            int numOverlaps = boxCollider.OverlapCollider(contactFilter, overlappingColliders);

            // Parcourez les résultats pour obtenir les GameObjects en collision
            for (int i = 0; i < numOverlaps; i++)
            {
                PolygonCollider2D collider = overlappingColliders[i];
                GameObject collidingObject = collider.gameObject;

                // Assurez-vous que l'objet en collision n'est pas le même que l'objet de départ
                if (collidingObject != box)
                {
                    collidingObjects.Add(collidingObject);
                }
            }
        }
     
        boxesInsideCrate =  collidingObjects;
    }
}
