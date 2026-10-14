using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //Velocidad de rotación
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotar alrededor del eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        //Rotar alrededor del eje X
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        //rotar alrededor del eje Z
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
