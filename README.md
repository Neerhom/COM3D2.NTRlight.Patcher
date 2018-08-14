# COM3D2.NTRlight.Patcher
Sybaris patcher that makes NTR lock less restrictive

This patcher enables (yotogi and free mode) skills and facilities that are locked by NTRlock while keeping NTR events hidden.

Since version 1.1, the patcher also able to permanently toggle NTR lock on and off. 
The functionality is realized by renameing patcher .dll file to contain specific keywords: **lock_on** will turn the lock on, and **lock_off** will turn it off.
For instance: renaming **COM3D2.NTRlight.Patcher.dll** to **COM3D2.NTRlight_lock_on.Patcher.dll** will make it to toggle lock on,
and renaming it to **COM3D2.NTRlight_lock_off.Patcher.dll** will make it to toggle the lock off.

The change occurns on initiation of club management screen( the screen you see after loading a save file) and the lock status gets written into save file, so once you loaded your save file with lock toggling enabled and saved your game this functionality becomes redundant, so you can rename the patcher to it's default name or remove it completely, if core functionality is of no interest.

# Download
https://github.com/Neerhom/COM3D2.NTRlight.Patcher/releases

# Pre-requisites
[Mono.Cecil.Inject](https://github.com/denikson/Mono.Cecil.Inject) (included in release)

The patcher requires any plugin/patcher loader that is capable of loading Sybaris patchers. 
For COM3D2 following are known:

[Sybaris 2.1](https://ux.getuploader.com/cm3d2_j/download/68)

[BepinEX 4.0 or newer](https://github.com/BepInEx/BepInEx) (personal recommendation, yes I'm biased towards it)

[Sybaris 2.2](https://ux.getuploader.com/cm3d2_j/download/154) is also a possible option, the functionality is not confirmed nor it will be as I'm not fan of it.

# Installaiton
Put archive contents into Sybaris folder.
Optionally change filename as described above, to enable NTR lock toggling.
