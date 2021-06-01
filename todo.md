




# TODO




## About
- Track work to do





## `2021-02-05`
1. [x] General Cleanup
    1. [x] `main`     Move Greg's Changes off `main` to `Greg-branch`
    2. [x] `cleanup`  Create temporary branch `cleanup` to merge all changes
    3. [x] `~`        Alert Greg and Scott to Folder Changes
    4. [x] Resolve Latest Differences
        1. [x] `cleanup`  Integrate Changes on `scott-branch-2`
        2. [x] `scott`    Remove `scott-branch`
        3. [x] `scott-2`  Rename `scott-branch-2` to `scott-branch`
        4. [x] `cleanup`  Integrate Changes on `peter-branch-2`
        5. [x] `cleanup`  Integrate Changes on `peter-branch`
        6. [x] `peter`    Remove `peter-branch`
        7. [x] `peter-2`  Rename `peter-branch-2` to `peter-branch`
        8. [x] `all`      Push Updates from `main`
    5. [x] `cleanup`  Move Content to New Folders ([See Below](#new-folder-layout))
    6. [x] `cleanup`  Rename Files for Consistency
    7. [ ] ~~`cleanup`  Comment Out `Debug.Log()`s from Code~~
    8. [x] `all`      Update All Branches
3. [x] Fix Video
    1. [x] `main`     Add `.mp4` to `.gitattributes`
    2. [x] `main`     Move and rename trailer to `misc/`
    3. [x] `all`      Push Updates from `main`
5. [ ] ~~Fix bad variable names~~
    1. [ ] ~~`main`     `BackgroundScroller.cs` line `8`~~
    2. [ ] ~~`main`     `PlayerColor`           line `10`~~
    3. [ ] ~~`main`     `PlatformColor`         line `8`~~
    4. [ ] ~~`main`     `PlatformMovement`      line `9`~~
6. [ ] Pull out scenes from Scott's branch and make levels of each
    1. [ ] `peter`    Define "Intro Sequence" of Platforms
    2. [ ] `peter`    Always play "Intro Sequence" first (`LevelJoiner`)
    3. [ ] `peter`    Define "Challenge Sequence" of Platforms
7. [ ] Finish LevelJoiner
    1. [ ] `peter`    Load Level Segments by Leading Edge (not Center)
    2. [ ] `scott`    Merge LevelJoiner with Current Platform Code
8. [ ] Space Effects
    1. [ ] `peter`    Add Screen Wipe (Color)
    2. [ ] `peter`    Add Sound Effect
9. [ ] Death Effects
    1. [ ] `peter`    Add Screen Wipe (Black)
    2. [ ] `peter`    Add Sound Effect
10. [ ] Segment Movement
    1. [ ] `scott`    Examine platform movement method
    2. [ ] `scott`    (If Required) Set platform movement to `prefab`/`group` method
    3. [ ] `peter`    Define Timer for Platform Movement
    4. [ ] `peter`    Sync Background with Platform Movement


### New Folder Layout
```yaml
Assets:
  Colors:
    Colors.cs
  Level:
    BackgroundScroller.cs
    bgAnimation1.anm # Greg
    CanvasColorSwitcher.cs
    LevelData.cs
    LevelJoiner.cs
    LevelManager.cs
    SkyBackground.png
  Levels:
    00.Template.prefab
    01.Example.prefab
    02.Example.prefab
    03.TestAll.prefab
    04.Basic.prefab
    05.Intro.prefab
  Menu:
    EndGame.cs
    HighScoreController.cs
    MenuUI.cs
    ResetGame.cs
  Platform:
    BluePlatform.png
    plat1.png # Greg
    Platform.png
    PlatformColor.cs
    PlatformMovement.cs
  Player:
    blueGuy.png # Greg
    blueGuy_0.controller # Greg
    PaletteColor.cs
    Player.png
    PlayerColor.cs
    PlayerController.controller
    PlayerController.cs
    PlayerJump.anim
    PlayerJump.png
    PlayerRun.anim
    PlayerRun.png
    SelectorOutline.png
  Scenes:
    MainScene.unity
    MainSceneGreg.unity
    MainScenePeter.unity
    StartMenu.unity
    Workshop.unity
  Sounds:
    BassyGroove.wav
    ColorRunnerLOOP.wav
Misc:
  trailer-1.mp4
```

### Conflicts (Greg-Scott)
- `Assets/Scenes/MainSceneGreg.unity`
- `Assets/Scenes/LICENSE.meta`
- `Assets/PaletteColor.cs`
- `Assets/Images/LICENSE.meta`

### Resolution (Greg-Scott)
- [x] Delete all `LICENSE` files
- [x] Duplicate `MainScene` to `MainSceneGreg` (*not* rename)
- [x] Choose `Find` over `FindChild`







