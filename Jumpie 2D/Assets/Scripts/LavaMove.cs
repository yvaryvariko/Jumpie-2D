using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour
{
    [SerializeField]
    private float lavaMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, transform.position.y + lavaMoveSpeed * Time.deltaTime);
    }
}
