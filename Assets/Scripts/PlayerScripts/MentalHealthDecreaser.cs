using UnityEngine;

[RequireComponent(typeof(Player))]
public  class MentalHealthDecreaser : MonoBehaviour
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
            _mentalHealthBar.GetComponent<Transform>().position = new Vector3
            (
                _mentalHealthBar.GetComponent<Transform>().position.x - (float)subtrahend * 0.027f,
                _mentalHealthBar.GetComponent<Transform>().position.y,
                _mentalHealthBar.GetComponent<Transform>().position.z
            );
            _mentalHealthBar.GetComponent<Transform>().localScale = new Vector3
            (
                _mentalHealthBar.GetComponent<Transform>().localScale.x - subtrahend * 0.055f,
                _mentalHealthBar.GetComponent<Transform>().localScale.y,
                _mentalHealthBar.GetComponent<Transform>().localScale.z
            );
        }
        else _mentalHealthBar.SetActive(false);
    }
}