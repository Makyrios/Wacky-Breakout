using UnityEngine;

public class BonusStandardBlock : BonusBlock
{
    [SerializeField]
    private Sprite bonusStandardBlockSprite;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void RandomSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bonusStandardBlockSprite;
    }
}
