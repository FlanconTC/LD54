using UnityEngine;
using System.Collections.Generic;

public class CrateController : MonoBehaviour
{
    private List<GameObject> boxesInsideCrate = new List<GameObject>();

    public void AddBox(GameObject box)
    {
        // Ajouter une bo�te � la liste si elle n'est pas d�j� � l'int�rieur
        if (!boxesInsideCrate.Contains(box))
        {
            boxesInsideCrate.Add(box);
            Debug.Log("Nombre de bo�tes dans la crate : " + boxesInsideCrate.Count);
        }
    }

    public void RemoveBox(GameObject box)
    {
        // Retirer une bo�te de la liste si elle est � l'int�rieur
        if (boxesInsideCrate.Contains(box))
        {
            boxesInsideCrate.Remove(box);
            Debug.Log("Nombre de bo�tes dans la crate : " + boxesInsideCrate.Count);
        }
    }
}
