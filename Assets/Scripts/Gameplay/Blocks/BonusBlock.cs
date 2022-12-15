public abstract class BonusBlock : Block
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BlockWorth = ConfigurationUtils.BonusBlockWorth;
    }

}
