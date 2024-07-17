using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float follow_speed = 2f;
    public Transform target;
    public Camera camera;

    [SerializeField] private float min_zoom = 2f;
    [SerializeField] private float max_zoom = 8f;

    private float cur_zoom = 5f;

    private void UpdateZoom(float new_zoom)
    {
        cur_zoom = Mathf.Clamp(cur_zoom, min_zoom, max_zoom);
    }
    // Update is called once per frame
    void Update()
    {
        // follow code.
        Vector3 new_position = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, new_position, follow_speed * Time.deltaTime);

        // zoom code.
        {
            float scroll_input = Input.mouseScrollDelta.y * 10;
            if      (scroll_input > 0) UpdateZoom(cur_zoom + ( 1 * .55f) );
            else if (scroll_input < 0) UpdateZoom(cur_zoom + (-1 * .55f) );

            camera.orthographicSize = cur_zoom;
        }
    }
}
