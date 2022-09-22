using UnityEngine;

[CreateAssetMenu(menuName = "Collectible")]
public class SoCollectible : ScriptableObject
{   [SerializeField] private string collectibleName;
    [SerializeField] private string collectibleType;
    public string GetCollectible()
    {
        return collectibleName;
    }

    /*[SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;

    public Sprite GetSprite() => sprite;
    public CollectibleType GetCollectibleType() => collectibleType;

    public Sprite GetOutlinesSprite() => outlineSprite;

    public bool GetRespawnable() => respawnable;*/


    // Start is called before the first frame update
    /*/void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
