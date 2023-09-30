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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += transform.forward * move_Speed * Time.deltaTime;
        
        if(Input.GetKey("w"))
        {
            move_Speed = 10;
        }
        else if(Input.GetKey("s"))
        {
            move_Speed = 2;
        }
        
        //Rotation
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        //Body
        positionSnake.Insert(0, transform.position);
        int i = 0;
        foreach (var prefab in namesOfDestroyedObjects)
        {
            Vector3 position = positionSnake[Mathf.Min((int)(i * insert), positionSnake.Count -1)];
            Vector3 positionforward = position - prefab.transform.position;
            prefab.transform.position += positionforward * move_Speed * Time.deltaTime;
            prefab.transform.LookAt(position);
            i++;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Apple")
        {
            Destroy(other.gameObject);
            SnakePrefab();
        }
    }

    private void SnakePrefab()
    {
        GameObject prefab = Instantiate(PrefabBody);
        namesOfDestroyedObjects.Add(prefab);
    }
}
