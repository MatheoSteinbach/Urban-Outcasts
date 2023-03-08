using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] AudioSource steppingSounds1;
    [SerializeField] AudioSource steppingSounds2;
    [SerializeField] AudioSource steppingSounds3;
    [SerializeField] AudioSource steppingSounds4;

    [SerializeField] Camera cam;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator animShadows;

    public string[] staticDirection = { "Static N", "Static NE", "Static E", "Static SE", "Static S", "Static SW", "Static W", "Static NW" };
    public string[] runDirection = { "Run N", "Run NE", "Run E", "Run SE", "Run S", "Run SW", "Run W", "Run NW" };

    private int lastDirection;
    public bool isMoving { get; private set; }

    private bool isPlayingSteppingSounds;
    private int randomSound;
    private void Start()
    {
        cam = Camera.main;
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isMoving)
        {
            if (!steppingSounds1.isPlaying && !steppingSounds2.isPlaying && !steppingSounds3.isPlaying && !steppingSounds4.isPlaying)
            {
                randomSound = Random.Range(0, 3);
                if(randomSound == 0)
                {
                    steppingSounds1.Play();
                }
                if (randomSound == 1)
                {
                    steppingSounds2.Play();
                }
                if (randomSound == 2)
                {
                    steppingSounds3.Play();
                }
                if (randomSound == 3)
                {
                    steppingSounds4.Play();
                }
            }
            //if (!isPlayingSteppingSounds)
            //{
            //    StartCoroutine(PlaySteppingSounds());
            //    isPlayingSteppingSounds = true;
            //}


        }
        else
        {
            steppingSounds1.Stop();
            steppingSounds2.Stop();
            steppingSounds3.Stop();
            steppingSounds4.Stop();
        }    
        BillboardEffect(anim);
        BillboardEffect(animShadows);

        //anim.transform.LookAt(anim.transform.position + cam.transform.rotation * Vector3.forward,
        //cam.transform.rotation * Vector3.up);

    }

    //private IEnumerator PlaySteppingSounds()
    //{
    //    yield return new WaitForSeconds(0.8f);
    //    steppingSounds.Play();
    //    isPlayingSteppingSounds = false;
        
    //}

    public void BillboardEffect(Animator _anim)
    {
        _anim.transform.LookAt(_anim.transform.position + cam.transform.rotation * Vector3.forward,
              cam.transform.rotation * Vector3.up);
        Vector3 eulerAngles = _anim.transform.eulerAngles;
        eulerAngles.z = 0;
        _anim.transform.eulerAngles = eulerAngles;
    }
    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;
        if (direction.magnitude < 0.01)
        {
            isMoving = false;
            directionArray = staticDirection;
        }
        else
        {
            isMoving = true;
            directionArray = runDirection; // UnComment when run anims available
            //directionArray = staticDirection;
            lastDirection = DirectionToIndex(direction);
        }

        anim.Play(directionArray[lastDirection]);
        animShadows.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 direction)
    {
        Vector2 normalizedDir = direction.normalized;
        float step = 360 / 8;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normalizedDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
