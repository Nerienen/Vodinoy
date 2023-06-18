using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTilingLoop : MonoBehaviour
{
    public float speed = 1f; // Speed of the texture movement
    public float repeatRate = 0.1f; // Time between texture movement

    private Renderer rend; 
    private Vector2 offset; // The current texture offset

    private void Start()
    {
        rend = GetComponent<Renderer>(); 
        offset = rend.material.mainTextureOffset; 
        InvokeRepeating("MoveTexture", 0f, repeatRate); //  moving texture
    }

    private void MoveTexture()
    {
        offset.x += speed * repeatRate; // nove the texture
        if (offset.x > 1f) // Loop texture
        {
            offset.x -= 1f;
        }
        rend.material.mainTextureOffset = offset; // zet new texture offset
    }
}
