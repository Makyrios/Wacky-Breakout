using UnityEngine;

public class BonusLongBlock : BonusBlock
{
    [SerializeField]
    private Sprite bonusLongBlockSprite;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void RandomSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bonusLongBlockSprite;
    }
}
