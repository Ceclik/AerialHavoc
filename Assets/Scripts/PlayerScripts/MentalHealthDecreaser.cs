using UnityEngine;

[RequireComponent(typeof(Player))]
public class MentalHealthDecreaser : MonoBehaviour
{
    private GameObject _mentalHealthBar;
    private Player _player;

    private void Awake()
    {
        _mentalHealthBar = GameObject.Find("MentalHealthBar");
        _player = GetComponent<Player>();
    }

    public void DecreaseValue(int subtrahend)
    {
        _player.MentalHealth -= subtrahend;
        if (_player.MentalHealth >= 0)
        {
            _mentalHealthBar.transform.position = new Vector3
            (
                _mentalHealthBar.transform.position.x - (float)subtrahend * 0.027f,
                _mentalHealthBar.transform.position.y,
                _mentalHealthBar.transform.position.z
            );
            _mentalHealthBar.transform.localScale = new Vector3
            (
                _mentalHealthBar.transform.localScale.x - subtrahend * 0.055f,
                _mentalHealthBar.transform.localScale.y,
                _mentalHealthBar.transform.localScale.z
            );
        }
        else _mentalHealthBar.SetActive(false);
    }
}