
**BESSON NEEL**
> Gaming Campus <br>
> GTech3 2025
> Groupe GameBoy <br>
> Semaine `JEU PROCEDURAL UNITY` <br>


### Sommaires
<br>

- [Initialisation](#Initialisation)
- [SimpleRoomPlacement](#SimpleRoomPlacement)
- [BSP](#BSP)
- [CellularAutomata](#CellularAutomata)
- [Noise](#Noise)


- - - - -
### Initialisation
<br>

Comment initialiser ce genre de projet ? <br>
Utilisation de **`UniTask`**: <br>
--> Guide d'installation ([**Lien UniTask OpenUPM**](https://openupm.com/packages/com.cysharp.unitask/#modal-manualinstallation)) <br>
<br>
**1ère Etape** <br>
Sur Unity, dans un projet 3D: <br>
--> Onglet >Edit <br>
--> Project Setting <br>
--> Package Manager <br>
<br>
|---- Name  : `package.openupm.com` <br>
|---- URL   : `https://package/openupm.com` <br>
|---- Scope : `com.cysharp.unitask` <br>
<br>
<img width="50%" src="Prj4_Jours1/Documentation/SetupUniTask_Unity_FullOnglet.png"></img> <br>
<br>
 **2ème Etapes** <br>
 Une fois validé, on peut fermer la fenêtre puis: <br>
 --> Onglet: Window  <br>
 --> Package Manager <br>
 --> [+] <br>
 --> Name: `com.cysharp.unitask` | version: `2.5.10` <br>
<br>
 <img width="25%" src="Prj4_Jours1/Documentation/Unity_Package_Plus_Name.png"></img> <br>
<img width="25%" src="Prj4_Jours1/Documentation/Unity_Package_Plus_Name_InputField.png"></img> <br>
<br>
**3ème Etapes:** (Facultatif, seulement si tu souhaite recommencer avec une base basique) <br>
Une fois UniTask correctement installé, on peut télécharger le package découverte de l'intervenant. <br>  
[**LienDriveCampus**](https://drive.google.com/drive/folders/1QxmWzBSGsTq-miRODwUX_zA8UEcFaUDW) <br>
Nom du package: `ArchitectureProceduralGeneration.unitypackage` <br>
Une fois téléchargé, simplement glisser le package dans la Hierarchy Unity, puis import le tout. <br>
<br>

- - - - -

**FIN INITIALISATION**
<br>
Ici, le projet contient plus d'élément que le simple package de l'étape 3. <br>
On retrouve les exemples de: <br>
- SimpleRoomPlacement <br>
- BSP <br>
- Cellular Automata <br>
- Noise <br>

<br>

- - - - -
## SimpleRoomPlacement
<br>

Sur Unity, utilise la scène `GridGenerator`. vérifie que GenerationMethod utilise le scriptableObject `SimpleRoomPlacement` sur le GameObject `ProceduralGridGenerator`

Explication du script `Simple Room Placement.cs` <br>

Le scrip `SimplRoomPlacement place aléatoirement` place des room aléatoirement
Essaie de placer le nombre max de salles selon la valeur de _maxRooms (changable dans l'inspector)
Chaque room a une taille random comprise entre minimum 3x3 et maximum 7x7 (changable dans l'inspector)
Place la room avce une taille aléatoire
Verifie qu'il n'y a pas de collision avec lse autres room (ce qui force un ecart d'au moins 1)
Si la room ne peux pas etre placer, l'algo ressaye avec une autre room
Cette methode a pour avantage d'etre simple prévisible et rapide mais a pour incoveniant de laisser bcp d'espace vide ( et pas de connection entre les room)

- - - - -
## BSP
<br>

Partie explication BSP


1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.

- - -
## CellularAutomata
<br>

Partie explication Cellular Automata

1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.

- - -
## Noise
<br>

Partie explication Noise

1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
1.
