using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

public abstract class Block : MonoBehaviour
{
    [SerializeField]
    protected SpriteAtlas blockSpriteAtlas;

    private int blockWorth;

    BlockDestroyedEvent blockDestroyedEvent;

    protected int BlockWorth
    {
        set
        {
            blockWorth = value;
        }
    }


    protected virtual void Start()
    {
        blockDestroyedEvent = new BlockDestroyedEvent();

        EventManager.AddBlockDestroyedInvoker(this);
        RandomSprite();
    }

    public void AddBlockDestroyedEventListener(UnityAction<int> listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }

    public void RemoveBlockDestroyedEventListener(UnityAction<int> listener)
    {
        blockDestroyedEvent.RemoveListener(listener);
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            blockDestroyedEvent.Invoke(blockWorth);
            EventManager.RemoveBlockDestroyedInvoker(this);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Get selected type of block with random sprite
    /// </summary>
    /// <param name="blockType">Type of block to spawn</param>
    /// <returns>Standart/Long block of random color</returns>
    protected abstract void RandomSprite();
}
