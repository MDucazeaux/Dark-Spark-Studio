using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundsManager : MonoBehaviour
{
    #region Variables
    public static SoundsManager Instance;

    // References
    [Header("References")]
    [SerializeField] AudioSource _musicsPlayerAudioSource;
    [SerializeField] AudioSource _SFXPlayerAudioSource;

    public AudioSource MusicsPlayerAudioSource { get { return _musicsPlayerAudioSource; } }
    public AudioSource SFXPlayerAudioSource { get { return _SFXPlayerAudioSource; } }

    [Header("Sounds")]
    // Musics
    [SerializeField] AllMusics _allMusics; 
    // SFX
    [SerializeField] AllSFX _allSFX;

    #region Enum
    public enum TypesOfMusics
    {
        MainMenu,
        StartCinematic,
        VictoryCinematic,
        DonjonThemes,
        EvilWizardTheme,
    }

    public enum TypesOfSFX
    {
        #region Player's actions
        CharactersMoves,
        CharactersRotate,
        PickupItem,
        OpeningDoor,
        OpeningGate,
        SlammingDoor,
        #endregion

        #region Character's moves
        // Brut
        NormalSwordAttack,
        HeavySwordAttack,

        // Witch
        FireBallSpell, 
        FireBallFire,
        FireBallExplosion,
        InvincibilitySpell,

        // Thief
        KnifeThrowing,
        PickingLock,
        KnifeHitWall,
        KnifeStab,

        // Alchemist
        PotionThrowing,
        TransmutationSpell,
        PotionBreaking,
        #endregion

        #region Character Damaged
        CharacterHitten,
        CharacterKilled,
        #endregion

        #region Enemies
        // Rat
        RatIdle,
        RatMoving,
        RatAttaking,
        RatHitten,
        RatKilled,

        // Skeleton
        SkeletonIdle,
        SkeletonMoving,
        SkeletonAttaking,
        SkeletonHitten,
        SkeletonKilled,

        // Dullahan
        DullahanIdle,
        DullahanMoving,
        DullahanAttaking,
        DullahanHitten,
        DullahanKilled,

        // Minotaur
        MinotaurIdle,
        MinotaurMoving,
        MinotaurAttaking,
        MinotaurHitten,
        MinotaurKilled,

        // EvilWizard
        EvilWizardIdle,
        EvilWizardMoving,
        EvilWizardAttaking,
        EvilWizardHitten,
        EvilWizardKilled,
        #endregion

        #region Environment
        WaterDrop,
        Whispers,
        ButtonHover,
        ButtonClick,
        #endregion
    }
    #endregion

    #region Structs
    [Serializable]
    struct AllMusics
    {
        [Header("Menus :")]
        public List<AudioClip> _mainMenu;

        [Header("Cinematics :")]
        public List<AudioClip> _startCinematic;
        public List<AudioClip> _victoryCinematic;

        [Header("In-game")]
        public List<AudioClip> _donjonThemes;
        public List<AudioClip> _evilWizardTheme;
    }

    [Serializable]
    struct AllSFX
    {
        #region Player's actions
        [Header("Player action :")]
        public AudioClip[] _charactersMoves;
        public AudioClip[] _charactersRotate;
        public AudioClip[] _pickupItem;
        public AudioClip[] _openingDoor;
        public AudioClip[] _openingGate;
        public AudioClip[] _slamingDoor;
        #endregion

        #region Character's moves
        [Header("Brute moves :")]
        public AudioClip[] _normalSwordAttack;
        public AudioClip[] _heavySwordAttack;

        [Header("Witch moves :")]
        public AudioClip[] _fireBallSpell;
        public AudioClip[] _fireBallFire;
        public AudioClip[] _fireBallExplosion;
        public AudioClip[] _invincibilitySpell;

        [Header("Thief moves :")]
        public AudioClip[] _knifeThrowing;
        public AudioClip[] _pickingLock;
        public AudioClip[] _knifeStab;
        public AudioClip[] _knifeHitWall;

        [Header("Alchemist moves :")]
        public AudioClip[] _potionThrowing;
        public AudioClip[] _potionBreaking;
        public AudioClip[] _transmutationSpell;
        #endregion

        #region Character damaged
        [Header("Character damaged :")]
        public AudioClip[] _characterHitten;
        public AudioClip[] _characterKilled;
        #endregion

        #region Enemies
        [Header("Rat :")]
        public AudioClip[] _ratIdle;
        public AudioClip[] _ratMoving;
        public AudioClip[] _ratAttaking;
        public AudioClip[] _ratHitten;
        public AudioClip[] _ratKilled;

        [Header("Skeleton :")]
        public AudioClip[] _skeletonIdle;
        public AudioClip[] _skeletonMoving;
        public AudioClip[] _skeletonAttaking;
        public AudioClip[] _skeletonHitten;
        public AudioClip[] _skeletonKilled;

        [Header("Dullahan :")]
        public AudioClip[] _dullahanIdle;
        public AudioClip[] _dullahanMoving;
        public AudioClip[] _dullahanAttaking;
        public AudioClip[] _dullahanHitten;
        public AudioClip[] _dullahanKilled;

        [Header("Minotaur :")]
        public AudioClip[] _minotaurIdle;
        public AudioClip[] _minotaurMoving;
        public AudioClip[] _minotaurAttaking;
        public AudioClip[] _minotaurHitten;
        public AudioClip[] _minotaurKilled;

        [Header("Evil Wizard :")]
        public AudioClip[] _evilWizardIdle;
        public AudioClip[] _evilWizardMoving;
        public AudioClip[] _evilWizardAttaking;
        public AudioClip[] _evilWizardHitten;
        public AudioClip[] _evilWizardKilled;
        #endregion

        #region Environment
        [Header("Environment :")]
        public AudioClip[] _waterDrop;
        public AudioClip[] _whispers;
        public AudioClip[] _buttonHover;
        public AudioClip[] _buttonPressed;
        #endregion
    }
    #endregion

    #endregion

    #region Methods
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #region Music
    /// <summary> Return a random AudioClip of the type of Music wanted </summary>
    public List<AudioClip> ReturnMusic(TypesOfMusics typesOfMusics)
    {
        // NOTE : If you are here because of a Unity error (not in default) that's surely because :
        // The music is not define. Go in SoundManager GameObject to define it in the Inspector. 

        switch (typesOfMusics)
        {
            #region Menus
            case TypesOfMusics.MainMenu:
                return _allMusics._mainMenu;
            #endregion

            #region Cinematics
            case TypesOfMusics.StartCinematic:
                return _allMusics._startCinematic;

            case TypesOfMusics.VictoryCinematic:
                return _allMusics._victoryCinematic;
            #endregion

            #region In-game
            case TypesOfMusics.DonjonThemes:
                return _allMusics._donjonThemes;

            case TypesOfMusics.EvilWizardTheme:
                return _allMusics._evilWizardTheme;
            #endregion

            default:
                Debug.LogError($"The type of SFX {typesOfMusics} is not planned in the switch statement.");
                return null;
        }
    }

    /// <summary> Randomize the music list given and play it endlessly /!\ It's a Coroutine /!\ </summary>
    public IEnumerator PlayMusicEndlessly(TypesOfMusics typesOfMusics)
    {
        List<AudioClip> musicList = ReturnMusic(typesOfMusics);

        while (true)
        {
            // Generation of a random number
            System.Random _randomNumber = new();

            // Shuffling the musicList
            for (int i = musicList.Count - 1; i > 0; i--)
            {
                // Get a random emplacement in the list
                int randomIndex = _randomNumber.Next(0, i + 1);

                // Change the position of the music into a random one in the list without making a temporary variable
                (musicList[randomIndex], musicList[i]) = (musicList[i], musicList[randomIndex]);
            }

            // Playing the music list entierely
            for (int i = 0; i < musicList.Count; i++)
            {
                _musicsPlayerAudioSource.clip = musicList[i];

                _musicsPlayerAudioSource.Play();

                yield return new WaitForSecondsRealtime(musicList[i].length);
            }
        }
    }
    #endregion

    #region SFX
    /// <summary> Return a random AudioClip of the type of SFX wanted </summary>
    public AudioClip ReturnSFX(TypesOfSFX typeOfSFX)
    {
        // NOTE : If you are here because of a Unity error (not in default) that's surely because :
        // The SFX is not define. Go in SoundManager GameObject to define it in the Inspector. 

        switch (typeOfSFX)
        {
            #region Player's actions
            case TypesOfSFX.CharactersMoves:
                return _allSFX._charactersMoves[Random.Range(0, _allSFX._charactersMoves.Length)];

            case TypesOfSFX.CharactersRotate:
                return _allSFX._charactersRotate[Random.Range(0, _allSFX._charactersRotate.Length)];

            case TypesOfSFX.PickupItem:
                return _allSFX._pickupItem[Random.Range(0, _allSFX._pickupItem.Length)];

            case TypesOfSFX.OpeningDoor:
                return _allSFX._openingDoor[Random.Range(0, _allSFX._openingDoor.Length)];
            #endregion

            #region Character's moves
            // Brut
            case TypesOfSFX.NormalSwordAttack:
                return _allSFX._normalSwordAttack[Random.Range(0, _allSFX._normalSwordAttack.Length)];

            case TypesOfSFX.HeavySwordAttack:
                return _allSFX._heavySwordAttack[Random.Range(0, _allSFX._heavySwordAttack.Length)];

            // Witch
            case TypesOfSFX.FireBallSpell:
                return _allSFX._fireBallSpell[Random.Range(0, _allSFX._fireBallSpell.Length)];

            case TypesOfSFX.FireBallFire:
                return _allSFX._fireBallFire[Random.Range(0, _allSFX._fireBallFire.Length)];

            case TypesOfSFX.FireBallExplosion:
                return _allSFX._fireBallExplosion[Random.Range(0, _allSFX._fireBallExplosion.Length)];

            case TypesOfSFX.InvincibilitySpell:
                return _allSFX._invincibilitySpell[Random.Range(0, _allSFX._invincibilitySpell.Length)];

            // Thief
            case TypesOfSFX.KnifeThrowing:
                return _allSFX._knifeThrowing[Random.Range(0, _allSFX._knifeThrowing.Length)];

            case TypesOfSFX.PickingLock:
                return _allSFX._pickingLock[Random.Range(0, _allSFX._pickingLock.Length)];

            // Alchimist
            case TypesOfSFX.PotionThrowing:
                return _allSFX._potionThrowing[Random.Range(0, _allSFX._potionThrowing.Length)];

            case TypesOfSFX.TransmutationSpell:
                return _allSFX._transmutationSpell[Random.Range(0, _allSFX._transmutationSpell.Length)];
            #endregion

            #region Character damaged
            case TypesOfSFX.CharacterHitten:
                return _allSFX._characterHitten[Random.Range(0, _allSFX._characterHitten.Length)];

            case TypesOfSFX.CharacterKilled:
                return _allSFX._characterKilled[Random.Range(0, _allSFX._characterKilled.Length)];
            case TypesOfSFX.OpeningGate:
                return _allSFX._openingGate[0];
            case TypesOfSFX.SlammingDoor:
                return _allSFX._slamingDoor[0];
            case TypesOfSFX.KnifeHitWall:
                return _allSFX._knifeHitWall[0];
            case TypesOfSFX.KnifeStab:
                return _allSFX._knifeStab[0];
            case TypesOfSFX.PotionBreaking:
                return _allSFX._potionBreaking[Random.Range(0, _allSFX._potionBreaking.Length)];
            #endregion
            
            #region Enemies
            // Rat
            case TypesOfSFX.RatIdle:
                return _allSFX._ratIdle[Random.Range(0, _allSFX._ratIdle.Length)];

            case TypesOfSFX.RatMoving:
                return _allSFX._ratMoving[Random.Range(0, _allSFX._ratMoving.Length)];

            case TypesOfSFX.RatAttaking:
                return _allSFX._ratAttaking[Random.Range(0, _allSFX._ratAttaking.Length)];

            case TypesOfSFX.RatHitten:
                return _allSFX._ratHitten[Random.Range(0, _allSFX._ratHitten.Length)];

            case TypesOfSFX.RatKilled:
                return _allSFX._ratKilled[Random.Range(0, _allSFX._ratKilled.Length)];

            // Skeleton
            case TypesOfSFX.SkeletonIdle:
                return _allSFX._skeletonIdle[Random.Range(0, _allSFX._skeletonIdle.Length)];

            case TypesOfSFX.SkeletonMoving:
                return _allSFX._skeletonMoving[Random.Range(0, _allSFX._skeletonMoving.Length)];

            case TypesOfSFX.SkeletonAttaking:
                return _allSFX._skeletonAttaking[Random.Range(0, _allSFX._skeletonAttaking.Length)];

            case TypesOfSFX.SkeletonHitten:
                return _allSFX._skeletonHitten[Random.Range(0, _allSFX._skeletonHitten.Length)];

            case TypesOfSFX.SkeletonKilled:
                return _allSFX._skeletonKilled[Random.Range(0, _allSFX._skeletonKilled.Length)];

            // Dullahan
            case TypesOfSFX.DullahanIdle:
                return _allSFX._skeletonIdle[Random.Range(0, _allSFX._skeletonIdle.Length)];

            case TypesOfSFX.DullahanMoving:
                return _allSFX._dullahanMoving[Random.Range(0, _allSFX._dullahanMoving.Length)];

            case TypesOfSFX.DullahanAttaking:
                return _allSFX._dullahanAttaking[Random.Range(0, _allSFX._dullahanAttaking.Length)];

            case TypesOfSFX.DullahanHitten:
                return _allSFX._dullahanHitten[Random.Range(0, _allSFX._dullahanHitten.Length)];

            case TypesOfSFX.DullahanKilled:
                return _allSFX._dullahanKilled[Random.Range(0, _allSFX._dullahanKilled.Length)];

            // Minotaur
            case TypesOfSFX.MinotaurIdle:
                return _allSFX._minotaurIdle[Random.Range(0, _allSFX._minotaurIdle.Length)];

            case TypesOfSFX.MinotaurMoving:
                return _allSFX._minotaurMoving[Random.Range(0, _allSFX._minotaurMoving.Length)];

            case TypesOfSFX.MinotaurAttaking:
                return _allSFX._minotaurAttaking[Random.Range(0, _allSFX._minotaurAttaking.Length)];

            case TypesOfSFX.MinotaurHitten:
                return _allSFX._minotaurHitten[Random.Range(0, _allSFX._minotaurHitten.Length)];

            case TypesOfSFX.MinotaurKilled:
                return _allSFX._minotaurKilled[Random.Range(0, _allSFX._minotaurKilled.Length)];

            // Evil Wizard
            case TypesOfSFX.EvilWizardIdle:
                return _allSFX._evilWizardIdle[Random.Range(0, _allSFX._evilWizardIdle.Length)];

            case TypesOfSFX.EvilWizardMoving:
                return _allSFX._evilWizardMoving[Random.Range(0, _allSFX._evilWizardMoving.Length)];

            case TypesOfSFX.EvilWizardAttaking:
                return _allSFX._evilWizardAttaking[Random.Range(0, _allSFX._evilWizardAttaking.Length)];

            case TypesOfSFX.EvilWizardHitten:
                return _allSFX._evilWizardHitten[Random.Range(0, _allSFX._evilWizardHitten.Length)];

            case TypesOfSFX.EvilWizardKilled:
                return _allSFX._evilWizardKilled[Random.Range(0, _allSFX._evilWizardKilled.Length)];
            #endregion

            case TypesOfSFX.ButtonHover:
                return _allSFX._buttonHover[0];
            case TypesOfSFX.ButtonClick:
                return _allSFX._buttonPressed[0];

            #region Environment
            case TypesOfSFX.WaterDrop:
                return _allSFX._waterDrop[Random.Range(0, _allSFX._waterDrop.Length)];

            case TypesOfSFX.Whispers:
                return _allSFX._whispers[Random.Range(0, _allSFX._whispers.Length)];
            #endregion

            default:
                Debug.LogError($"The type of SFX {typeOfSFX} is not planned in the switch statement.");
                return null;
        }
    }

    /// <summary> Play a random SFX of the type of SFX you wanted </summary>
    public void PlaySFX(TypesOfSFX typesOfSFX, float volume = 1)
    {
        _SFXPlayerAudioSource.PlayOneShot(ReturnSFX(typesOfSFX), volume * Settings.Instance.MainVolume * Settings.Instance.SfxVolume);
    }

    
    #endregion

    #endregion
}