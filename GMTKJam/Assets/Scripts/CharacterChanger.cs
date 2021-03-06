﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
  private EvolutionManager _evolutionManager;

  public GameObject particle;
  public AudioClip poofSound;
  private EvolutionManager EvolutionManager
  {
    get
    {
      if (_evolutionManager == null)
      {
        _evolutionManager = FindObjectOfType<EvolutionManager>();
      }
      return _evolutionManager;
    }
  }

  private PlayerController _playerController;
  private PlayerController playerController
  {
    get
    {
      if (_playerController == null)
      {
        _playerController = GetComponent<PlayerController>();
      }
      return _playerController;
    }
  }

  public PlayerAvatar Crianca;
  public PlayerAvatar AdultoEmpresario;
  public PlayerAvatar AdultoHippie;
  public PlayerAvatar AdultoPunk;
  public PlayerAvatar AdultoNormal;
  public PlayerAvatar VelhoAtleta;
  public PlayerAvatar VelhoCadeirante;
  public PlayerAvatar VelhoZen;
  public PlayerAvatar VelhoNormal;

  public EvolutionType evolutionType;


  // Use this for initialization
  void Start()
  {
    evolutionType = EvolutionType.Crianca;
    SetEvolution(Crianca);
  }

  bool started = false;
  void SetEvolution(PlayerAvatar avatar)
  {
    if (playerController.currentAvatar != null)
    {
      Destroy(playerController.currentAvatar.gameObject);
    }
    Vector3 particlePos = this.gameObject.transform.position + Vector3.up * 2f + Vector3.right * 3f;
    var particleInstance = Instantiate(particle, particlePos, Quaternion.identity);
    print("Changing to " + evolutionType);
    var newAvatar = Instantiate(avatar, Vector3.zero, Quaternion.identity, playerController.transform);
    newAvatar.transform.localRotation = Quaternion.identity;
    newAvatar.transform.localPosition = Vector3.zero;
    playerController.currentAvatar = newAvatar;
    if (started)
    {
      var audio = GetComponent<AudioSource>();
      audio.clip = poofSound;
      audio.Play();
      started = true;
    }
  }

  // Update is called once per frame
  void Update()
  {
    var evolution = EvolutionManager.VerifyEvolution();
    if (evolutionType != evolution)
    {
      evolutionType = evolution;

      switch (evolutionType)
      {
        case EvolutionType.Crianca:
          SetEvolution(Crianca);
          break;
        case EvolutionType.AdultoEmpresario:
          SetEvolution(AdultoEmpresario);
          break;
        case EvolutionType.AdultoHippie:
          SetEvolution(AdultoHippie);
          break;
        case EvolutionType.AdultoPunk:
          SetEvolution(AdultoPunk);
          break;
        case EvolutionType.AdultoNormal:
          SetEvolution(AdultoNormal);
          break;
        case EvolutionType.VelhoAtleta:
          SetEvolution(VelhoAtleta);
          break;
        case EvolutionType.VelhoCadeirante:
          SetEvolution(VelhoCadeirante);
          break;
        case EvolutionType.VelhoZen:
          SetEvolution(VelhoZen);
          break;
        case EvolutionType.VelhoNormal:
          SetEvolution(VelhoNormal);
          break;
        default:
          print("ERRO BIZARRO");
          break;
      }
    }
  }
}
