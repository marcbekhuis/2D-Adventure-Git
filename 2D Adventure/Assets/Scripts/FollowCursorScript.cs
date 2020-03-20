using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursorScript : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
