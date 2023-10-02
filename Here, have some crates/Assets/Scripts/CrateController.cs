using UnityEngine;
using System.Collections.Generic;

public class CrateController : MonoBehaviour
{
    private List<GameObject> boxesInsideCrate = new List<GameObject>();

    public void AddBox(GameObject box)
    {
        // Ajouter une boîte à la liste si elle n'est pas déjà à l'intérieur
        if (!boxesInsideCrate.Contains(box))
        {
            boxesInsideCrate.Add(box);
            Debug.Log("Nombre de boîtes dans la crate : " + boxesInsideCrate.Count);
        }
    }

    public void RemoveBox(GameObject box)
    {
        // Retirer une boîte de la liste si elle est à l'intérieur
        if (boxesInsideCrate.Contains(box))
        {
            boxesInsideCrate.Remove(box);
            Debug.Log("Nombre de boîtes dans la crate : " + boxesInsideCrate.Count);
        }
    }
}
