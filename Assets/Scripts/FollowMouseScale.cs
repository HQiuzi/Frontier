using UnityEngine;
using UnityEngine.UI;

public class FollowMouseScale : MonoBehaviour
{
    public GameObject mapPanel;
    public float scaleSpeed = 5.0f;
    private float minScale = 1.0f;
    private float maxScale = 150.0f;
    private float currentScale;
    private float defaultScale;

    // Use this for initialization

    void Start()
    {
        //根据当前摄像机是正交还是透视进行对应赋值

        if (Camera.main.orthographic == true)
        {
            currentScale = Camera.main.orthographicSize;
        }
        else
        {
            currentScale = Camera.main.fieldOfView;
        }
        defaultScale = currentScale;
    }

    // Update is called once per frame

    void Update()
    {

        //获取鼠标滚轮的值，向前大于0，向后小于0，并设置放大缩小范围值
        currentScale -= Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        //根据当前摄像机是正交还是透视进行对应赋值，放大缩小

        if (Camera.main.orthographic == true)
        {
            Camera.main.orthographicSize = currentScale;
        }

        else
        {
            Camera.main.fieldOfView = currentScale;
        }
        if (currentScale < defaultScale)
        {
            mapPanel.SetActive(true);
        }
        else
        {
            mapPanel.SetActive(false);
        }
    }

}