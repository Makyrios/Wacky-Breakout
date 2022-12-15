using UnityEngine;
using UnityEngine.U2D;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;
    Vector2 paddleSpawnLocation;

    [SerializeField]
    GameObject standartBlockPrefab;
    [SerializeField]
    GameObject longBlockPrefab;
    [SerializeField]
    GameObject bonusStandardBlockPrefab;
    [SerializeField]
    GameObject bonusLongBlockPrefab;
    [SerializeField]
    GameObject effectBlockPrefab;
    [SerializeField]
    SpriteAtlas blockSpriteAtlas;


    // Start is called before the first frame update
    void Start()
    {
        paddleSpawnLocation = new Vector2(0, -4f);
        Instantiate(paddlePrefab, paddleSpawnLocation, Quaternion.identity);

        SpawnBlocks(ConfigurationUtils.BlockRowsToBuild);
    }

    /// <summary>
    /// Spawns rows of random blocks
    /// </summary>
    /// <param name="rows">Count of rows</param>
    void SpawnBlocks(int rows)
    {
        // Choose random block type and block sprite
        GameObject blockToSpawn = RandomBlock();
        BoxCollider2D blockToSpawnCollider = blockToSpawn.GetComponent<BoxCollider2D>();
        bool lastBlock = false;

        int rowCount = 1;

        for (float i = ScreenUtils.ScreenTop - blockToSpawnCollider.size.y / 2 - 0.1f; rowCount <= rows; i -= (blockToSpawnCollider.size.y + 0.1f))
        {
            for (float j = ScreenUtils.ScreenLeft + 0.2f; j <= ScreenUtils.ScreenRight; j += 0.1f)
            {

                if (Physics2D.OverlapArea(new Vector2(j, i),
                    new Vector2(j + blockToSpawnCollider.size.x, i)) == null)
                {
                    // If we could insert standard block at the end than try again
                    if (lastBlock)
                        lastBlock = false;

                    float randomBlockSpawn = Random.value;

                    if (randomBlockSpawn < ConfigurationUtils.BlockSpawnChance)
                    {
                        Vector2 spawnLocation = new Vector2(j + blockToSpawnCollider.size.x / 2, i);
                        Instantiate(blockToSpawn, spawnLocation, Quaternion.identity);
                        print($"Block spawned at x: {spawnLocation.x}, y: {spawnLocation.y}");
                    }

                }

                // If we can't insert block
                else
                {
                    // If we can't put in standard block at the end than stop
                    if (lastBlock)
                        break;
                    // Try to put in standart block at the end
                    blockToSpawn = standartBlockPrefab;
                    blockToSpawnCollider = blockToSpawn.GetComponent<BoxCollider2D>();
                    lastBlock = true;
                    j -= 0.1f;
                    continue;
                }

                // After every succesfull block insert move to the end of this new block
                j += blockToSpawnCollider.size.x;

                // Random next block
                blockToSpawn = RandomBlock();
                blockToSpawnCollider = blockToSpawn.GetComponent<BoxCollider2D>();
            }
            rowCount++;
        }
    }

    GameObject RandomBlock()
    {
        //int rand = Random.Range(0, 100);
        //switch (rand)
        //{
        //    case 0:
        //        return standartBlockPrefab;
        //    case 1:
        //        return longBlockPrefab;
        //    case 2:
        //        return bonusStandardBlockPrefab;
        //    case 3:
        //        return bonusLongBlockPrefab;
        //    case 4:
        //        return effectBlock;
        //}
        //return standartBlockPrefab;

        float randomBlockType = Random.value;
        if (randomBlockType < ConfigurationUtils.StandardBlockSpawnChance)
        {
            return standartBlockPrefab;
        }
        else if (randomBlockType < ConfigurationUtils.StandardBlockSpawnChance + ConfigurationUtils.LongBlockSpawnChance)
        {
            return longBlockPrefab;
        }
        else if (randomBlockType < ConfigurationUtils.StandardBlockSpawnChance + ConfigurationUtils.LongBlockSpawnChance +
            ConfigurationUtils.BonusBlockSpawnChance)
        {
            if (Random.Range(0, 2) == 0)
            {
                return bonusStandardBlockPrefab;
            }
            else
            {
                return bonusLongBlockPrefab;
            }
        }
        else
        {
            return effectBlockPrefab;
        }
    }


}
