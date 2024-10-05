using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour
{
    [SerializeField]
    private float lavaMoveSpeed;
    public Transform playerTransform;

    public float minLavaSpeed, maxLavaSpeed;
    // Update is called once per frame
    void Update()
    {
        float distance = playerTransform.transform.position.y - transform.position.y;

        lavaMoveSpeed = Mathf.Clamp(distance * minLavaSpeed, minLavaSpeed, maxLavaSpeed);

        transform.position = new Vector2(0, transform.position.y + lavaMoveSpeed * Time.deltaTime);
    }
}
