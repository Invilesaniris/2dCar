using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject thingToFollow;
    [SerializeField] public GameObject CameraBoundaryBottom;
    [SerializeField] public GameObject CameraBoundaryLeft;
    [SerializeField] public GameObject CameraBoundaryRight;
    [SerializeField] public GameObject CameraBoundaryTop;


    private float aspectRatio;

    private void Start()
    {
        aspectRatio = Screen.width / Screen.height;
    }

    void Update()
    {
        transform.position = new Vector3(thingToFollow.transform.position.x,
            thingToFollow.transform.position.y,
            transform.position.z);


    }
}
