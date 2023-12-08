using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offSetColor;
    [SerializeField] private SpriteRenderer _renderer;
    // Start is called before the first frame update

    public void Init(bool isOffSet)
    {
        _renderer.color = isOffSet ? _offSetColor : _baseColor;
    }  
}
