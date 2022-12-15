using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : Block
{
    [SerializeField]
    Sprite FreezerBlockSprite;
    [SerializeField]
    Sprite SpeedupBlockSprite;

    private EffectName effect;
    private float effectDuration;

    FreezerBlockEvent freezerEvent;
    SpeedupBlockEvent speedupEvent;

    private void Awake()
    {
        freezerEvent = new FreezerBlockEvent();
        speedupEvent = new SpeedupBlockEvent();
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BlockWorth = ConfigurationUtils.EffectBlockWorth;
    }


    protected override void RandomSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int chooseEffect = Random.Range(0, 2);
        switch (chooseEffect)
        {
            case 0:
                spriteRenderer.sprite = FreezerBlockSprite;
                effect = EffectName.Freezer;
                EventManager.AddFreezerBlockDestroyedInvoker(this);
                effectDuration = ConfigurationUtils.FreezerDuration;
                break;
            case 1:
                spriteRenderer.sprite = SpeedupBlockSprite;
                effect = EffectName.Speedup;
                EventManager.AddSpeedupBlockDestroyedInvoker(this);
                effectDuration = ConfigurationUtils.SpeedupDuration;
                break;
        }
    }

    public void AddFreezerBlockEventListener(UnityAction<float> script)
    {
        freezerEvent.AddListener(script);
    }

    public void AddSpeedupBlockEventListener(UnityAction<float> script)
    {
        speedupEvent.AddListener(script);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (effect == EffectName.Freezer)
        {
            freezerEvent.Invoke(effectDuration);
        }
        else
        {
            speedupEvent.Invoke(effectDuration);
        }
    }
}
