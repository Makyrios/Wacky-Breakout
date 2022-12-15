using UnityEngine;

public class LongBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BlockWorth = ConfigurationUtils.LongBlockWorth;
    }

    protected override void RandomSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int blockSprite = Random.Range(0, 6);
        switch (blockSprite)
        {
            case 0:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_59");
                break;
            case 1:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_60");
                break;
            case 2:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_61");
                break;
            case 3:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_63");
                break;
            case 4:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_66");
                break;
            case 5:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_67");
                break;
        }
    }
}
