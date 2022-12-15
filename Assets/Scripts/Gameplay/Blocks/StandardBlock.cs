using UnityEngine;

public class StandardBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BlockWorth = ConfigurationUtils.StandardBlockWorth;
    }

    protected override void RandomSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int blockSprite = Random.Range(0, 8);
        switch (blockSprite)
        {
            case 0:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_0");
                break;
            case 1:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_1");
                break;
            case 2:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_2");
                break;
            case 3:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_3");
                break;
            case 4:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_4");
                break;
            case 5:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_5");
                break;
            case 6:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_6");
                break;
            case 7:
                spriteRenderer.sprite = blockSpriteAtlas.GetSprite("breakout_pieces_7");
                break;
        }
    }
}
