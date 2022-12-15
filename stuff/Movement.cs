using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    public Transform movePoint;
    public AudioClip footstep;
    public AudioClip footstep2;
    public LayerMask WhatStopsMovement;
    public bool isImportant;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        
    }
    void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    void Update()
    {
       if (!isImportant)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position,  moveSpeed * Time.deltaTime);
        
        

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
        if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, WhatStopsMovement))
                    {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.PlayOneShot(footstep);
                    }
                        

                }
            }
            if (Input.GetAxisRaw("Vertical") == 0 || (Input.GetAxisRaw("Horizontal") == 1 || (Input.GetAxisRaw("Horizontal") == -1)))
            {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                    {        
                    if  (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, WhatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.PlayOneShot(footstep2);
                    }
                            
                }
            }

        } 
        
          
            
            



        }
    }
}
