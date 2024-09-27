using UnityEngine;
using UnityEngine.UI;

public class ZombUIController : ObjectsDisposer
{
    private readonly Image _hpBarImage;
    private float _maxHP;

    public ZombUIController(Image hpBarImage) =>
        _hpBarImage = hpBarImage;
    public void Initialize(ZombManager manager)
    {
        _maxHP = manager.HP;
        SetHPBar(_maxHP);
    }
    public void SetHPBar(float currentHP)
    {
        float scaleX = (currentHP * 100 / _maxHP) / 100;
        _hpBarImage.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}