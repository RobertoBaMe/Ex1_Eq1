using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] float move_Speed = 2f;
    [SerializeField] float rotationSpeed = 180.0f;
    public GameObject PrefabBody;
    public float insert = 40;

    public List<GameObject> namesOfDestroyedObjects = new List<GameObject>();
    public List<Vector3> positionSnake = new List<Vector3>();

    // Velocidad máxima y mínima para el movimiento
    public float maxSpeed = 100f;
    public float minSpeed = 2f;

    // Incremento/decremento de velocidad
    public float speedChangeRate = 2f;

    // Velocidad adicional por recolectar manzanas
    public float speedIncrementPerApple = 5f;

    // Indicadores para controlar la tecla presionada
    private bool isWPressed = false;
    private bool isSPressed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Incrementar o reducir la velocidad según las teclas "W" y "S"
        if (Input.GetKey("w"))
        {
            isWPressed = true;
            isSPressed = false;
        }
        else if (Input.GetKey("s"))
        {
            isWPressed = false;
            isSPressed = true;
        }
        else
        {
            isWPressed = false;
            isSPressed = false;
        }

        // Incrementar o reducir la velocidad gradualmente
        if (isWPressed)
        {
            move_Speed += speedChangeRate * Time.deltaTime;
        }
        else if (isSPressed)
        {
            move_Speed -= speedChangeRate * Time.deltaTime;
            // Limitar la velocidad mínima
            move_Speed = Mathf.Max(move_Speed, minSpeed);
        }

        // Limitar la velocidad máxima
        move_Speed = Mathf.Clamp(move_Speed, minSpeed, maxSpeed);

        transform.position += transform.forward * move_Speed * Time.deltaTime;

        //Rotation
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        //Body
        positionSnake.Insert(0, transform.position);
        int i = 0;
        foreach (var prefab in namesOfDestroyedObjects)
        {
            Vector3 position = positionSnake[Mathf.Min((int)(i * insert), positionSnake.Count - 1)];
            Vector3 positionforward = position - prefab.transform.position;
            prefab.transform.position += positionforward * move_Speed * Time.deltaTime;
            prefab.transform.LookAt(position);
            i++;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            Destroy(other.gameObject);
            SnakePrefab();

            // Incrementar la velocidad al recolectar una manzana
            move_Speed += speedIncrementPerApple;
        }
    }

    private void SnakePrefab()
    {
        GameObject prefab = Instantiate(PrefabBody);
        namesOfDestroyedObjects.Add(prefab);
    }
}