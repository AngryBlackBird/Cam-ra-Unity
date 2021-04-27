using UnityEngine;

public class zoomMainCam : MonoBehaviour
{

    Camera m_MainCamera;

    public int speed = 10;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Vector3 positionCam;
    
   

    void Start()
    {
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (m_MainCamera.fieldOfView >= 15)
            {
                m_MainCamera.fieldOfView -= 5f;
                Debug.Log(m_MainCamera);
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {

            if (m_MainCamera.fieldOfView <= 80)
            {
                Debug.Log("Mouse Scroll Down");
                m_MainCamera.fieldOfView += 5f;
            }
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            Vector3 mousePos = Input.mousePosition;

            float x = moveRotateX();
            float y = moveRotateY();

            m_MainCamera.transform.eulerAngles = new Vector3(y, x, 0.0f);
        }

        positionCam = m_MainCamera.transform.position;
       

        if (Input.GetKey("up"))
        {
            Debug.Log(m_MainCamera.transform.forward);

            positionCam = positionCam + Camera.main.transform.forward * speed * Time.deltaTime;
            m_MainCamera.transform.position = positionCam;

        }
        if (Input.GetKey("down"))
        {
            positionCam = positionCam - Camera.main.transform.forward * speed * Time.deltaTime;
            m_MainCamera.transform.position = positionCam;

            Debug.Log(m_MainCamera.transform.position);
        }
        
        if (Input.GetKey("left"))
        {

            positionCam = positionCam - transform.right * speed * Time.deltaTime;
            m_MainCamera.transform.position = positionCam;
        }

        if (Input.GetKey("right"))
        {
            positionCam = positionCam + transform.right * speed * Time.deltaTime;
            m_MainCamera.transform.position = positionCam;
        }

    }

    public float moveRotateX()
    {
        Debug.Log(Input.GetAxis("Mouse X"));
        yaw += Input.GetAxis("Mouse X");
        return yaw;
    }
    
    public float moveRotateY()
    {
        Debug.Log(Input.GetAxis("Mouse Y"));
        pitch -=  Input.GetAxis("Mouse Y");
        return pitch;
    }
}
