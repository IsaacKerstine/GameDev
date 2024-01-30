using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //Camera Variables
    public Camera cam;
    private Vector2 look_input = Vector2.zero;
    private float look_speed = 60f;
    private float horizontal_look_angle = 0f;
    public bool invert_x = false;
    public bool invert_y = false;
    public int invert_facter_x = 1;
    public int invert_facter_y = 1;
    [Range(0.01f, 1f)] public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        //Hide the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Invert Camera
        if (invert_x) invert_facter_x = -1;
        if (invert_y) invert_facter_y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    public void GetLookInput(InputAction.CallbackContext context)
    {
        look_input = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        //Left/right
        transform.Rotate(Vector3.up, look_input.x * look_speed * Time.deltaTime * invert_facter_x * sensitivity);

        //Up/Down
        float angle = look_input.y * look_speed * Time.deltaTime * invert_facter_y * sensitivity;
        horizontal_look_angle -= angle;
        horizontal_look_angle = Mathf.Clamp(horizontal_look_angle, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(horizontal_look_angle, 0, 0);
    }
}
