﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemScript : MonoBehaviour
{

  // Use this for initialization
  public Item itemSO;
  private bool death = false;

  void Start()
  {
    EventManager.OnEndGameEvent += () => { death = true; };
    GetComponentInChildren<SpriteRenderer>().sortingOrder = -2;
  }

  // Update is called once per frame
  void Update()
  {
    if (death)
      Destroy(this.gameObject);
  }

  /// <summary>
  /// OnTriggerEnter is called when the Collider other enters the trigger.
  /// </summary>
  /// <param name="other">The other Collider involved in this collision.</param>
  void OnTriggerEnter(Collider other)
  {
    ItemSpawner.AddItem(itemSO, other.GetComponentInParent<CharacterStats>());
    if (itemSO.itemType == ItemType.Addictive)
    {
      FindObjectOfType<ItemSpawner>().RepeatableItems.Add(itemSO);
    }
    else if (itemSO.itemType == ItemType.Death)
    {
      EventManager.OnEndGameEvent();
    }
    Destroy(this.gameObject);
    FindObjectOfType<BarulhoItem>().GetComponent<AudioSource>().Play();
  }
}
