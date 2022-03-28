using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMesh : MonoBehaviour
{
    public float MovementSpeed;
    public float HorizontalBoundries = 22;
    public float ShootInterval;
    private float ShootTimer;

    public GameObject HayBalePrefab;
    public Transform HaySpawnpoint;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        if (HorizontalInput < 0 && transform.position.x > -HorizontalBoundries)
        {
            transform.Translate(transform.right * -MovementSpeed * Time.deltaTime);
        }

        else if (HorizontalInput > 0 && transform.position.x < HorizontalBoundries)
        {
            transform.Translate(transform.right * MovementSpeed * Time.deltaTime);
        }
    }

    private void UpdateShooting()
    {
        ShootTimer -= Time.deltaTime;
        if (ShootTimer<=0 && Input.GetKey(KeyCode.Space))
        {
            ShootTimer = ShootInterval;
            ShootHay();
        }
    }
    private void ShootHay()
    {
        Instantiate(HayBalePrefab, HaySpawnpoint.position, Quaternion.identity);
    }
}
