using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minX = -5f;
    public float maxX = 80f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = -5f;
    public float maxZ = 70f;

    private void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        
        if (transform.position.z <= maxZ && ((Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0f) || Input.mousePosition.y >= Screen.height - panBorderThickness))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.z >= minZ && ((Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0f) || Input.mousePosition.y <= panBorderThickness))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x >= minX && ((Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0f) || Input.mousePosition.x <= panBorderThickness))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x <= maxX && ((Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0f) || Input.mousePosition.x >= Screen.width - panBorderThickness))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;

        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
