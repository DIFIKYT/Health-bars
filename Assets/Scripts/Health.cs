using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;
    [SerializeField] private Button _reduceHealthButton;
    [SerializeField] private Button _restoreHealthButton;

    private int _ņurrentHealth;
    private bool IsAlive => _ņurrentHealth > 0;

    private void OnEnable()
    {
        _reduceHealthButton.onClick.AddListener(Reduce);
        _restoreHealthButton.onClick.AddListener(Restore);
    }

    private void OnDisable()
    {
        _reduceHealthButton.onClick.RemoveAllListeners();
        _restoreHealthButton.onClick.RemoveAllListeners();
    }

    private void Awake()
    {
        _ņurrentHealth = _maxHealth;
    }

    private void Reduce()
    {
        int Amount = 20;

        if (Amount <= 0)
            return;

        _ņurrentHealth -= Amount;

        if (IsAlive == false)
            _ņurrentHealth = 0;
    }

    private void Restore()
    {
        int Amount = 20;

        if (Amount <= 0)
            return;

        _ņurrentHealth = Mathf.Clamp(_ņurrentHealth + Amount, 0, _maxHealth);
    }
}