using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging;
    public Transform objetAPlacer;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public float offsetX = 0;
    public float offsety = 0;


    public void OnMouseUp()
    {
        isDragging = false;

        PlacerObjetSurGrille(objetAPlacer);

        if (!_spriteRenderer.isVisible)
        {
            OnBecameInvisible();
        }
    }

    private Vector3 offset;
    private Vector3 spawnpoint;
    private void Start()
    {
        spawnpoint = transform.position;

    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            
        }
    }

    void PlacerObjetSurGrille(Transform objet)
    {
        Vector3 positionActuelle = objet.position;

        // Calcul des indices de la case de grille
        int indiceX = Mathf.RoundToInt(positionActuelle.x);
        int indiceY = Mathf.RoundToInt(positionActuelle.y);

        // Correction de la position pour placer au centre de la case
        float nouveauX = indiceX + offsetX;
        float nouveauY = (float)(indiceY + 0.5f) + offsety;

        // Appliquer la nouvelle position à l'objet
        objet.position = new Vector3(nouveauX, nouveauY, positionActuelle.z);
    }

    public void OnBecameInvisible()
    {
        transform.position = spawnpoint;
    }

    // Helper method to flip colliders
  
}
