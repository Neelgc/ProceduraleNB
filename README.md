
**BESSON NEEL**
Gaming Campus <br>
GTech3 2025
Groupe GameBoy <br>
Semaine `JEU PROCEDURAL UNITY` <br>


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

 Installer `UniTask`: <br>
Guide d'installation d'UniTask ([**Lien UniTask OpenUPM**](https://openupm.com/packages/com.cysharp.unitask/#modal-manualinstallation)) <br>
<br>
Apres avoir installé UniTask, récup le package donné en cours : [**LienDriveCampus**](https://drive.google.com/drive/folders/1QxmWzBSGsTq-miRODwUX_zA8UEcFaUDW) <br>
Nom du package: `ArchitectureProceduralGeneration.unitypackage` <br>

- - - - -
## SimpleRoomPlacement
<br>

Sur Unity, utilise la scène `GridGenerator`. vérifie que GenerationMethod utilise le scriptableObject `SimpleRoomPlacement` sur le GameObject `ProceduralGridGenerator`

Explication du script `Simple Room Placement.cs` <br>

Le scrip `SimplRoomPlacement place aléatoirement` place des room aléatoirement <br>
Essaie de placer le nombre max de salles selon la valeur de _maxRooms (changable dans l'inspector) <br>
Chaque room a une taille random comprise entre minimum 3x3 et maximum 7x7 (changable dans l'inspector) <br>
Place la room avce une taille aléatoire <br>
Verifie qu'il n'y a pas de collision avec lse autres room (ce qui force un ecart d'au moins 1) <br>
Si la room ne peux pas etre placer, l'algo ressaye avec une autre room <br>
Cette methode a pour avantage d'etre simple prévisible et rapide mais a pour incoveniant de laisser bcp d'espace vide ( et pas de connection entre les room) <br>
- - - - -
## BSP
<br>

Sur Unity, utilise la scène `GridGenerator`. vérifie que GenerationMethod utilise le scriptableObject `BSP` sur le GameObject `ProceduralGridGenerator`

Explication du script `BSP.cs` <br>

Le `BSP`(BinarySpacePartitioning) effectue des divisions recursives pour tranformé une zone en zones de + en + petites <br>
La zone de départ esr l'entierté de la grid <br>
Divise la zone en 2 avec un ratio random <br>
Répete cet operation pour chaque sous zone cree etc ( bien mettree une condition d'arret sinn ca s'arrete jamais) <br>
Arrete de diviser quand une zone est trop petite pour etre diviser, ca deviens une Leaf <br>
Place ensuite les room dans chaque Leaf (room de taille random toujours) <br>
Relie ensuite les room avec les Corridor (censé partir du centre des room et ne pas se 'croisé') <br>
Cette methode a pour avantage d'etre plus utilisable (le fait de relié les room peux deja cree des sortes de donjon), ca rend aussi le placement aleatoire moins chaotique je trouve, ce qui est aussi l'incoveniant, ca devien facilement trop regulier selon les parametres ce qui donne un aspect non naturel <br>

- - - - -
## CellularAutomata
<br>

Sur Unity, utilise la scène `GridGenerator`. vérifie que GenerationMethod utilise le scriptableObject `CellularAutomata` sur le GameObject `ProceduralGridGenerator`

Le `CellularAutomata` est une simulation de vie organiuqe , comme le "jeu de la vie" (cf video ego) <br>
Place de facon random les tiles (Grass et Water dans mon cas) selon la _noiseDensity (modifiable dans l'inspector) <br>
Compte ensuite les 8 voisin de chaque tiles : <br>
Pour une tiles Grass : reste grass si au moins 4 voisin sont grass <br>
pour une tiles Water : devien grass si au moins 5 voisin sont grass <br>
puis rebelote pendant X steps (la valeur de _maxSteps) <br>
avantgae : donne des maps naturel et organique <br>
incoveniants : compliquer a faire et compliquer a bien regler <br>

- - - - -
## Noise
<br>

Sur Unity, utilise la scène `GridGenerator`. vérifie que GenerationMethod utilise le scriptableObject `Noises` sur le GameObject `ProceduralGridGenerator`

Utilisation de bruit pour gerer les variation d'altitude <br>
Genere un NoiseMap 2d avec qur des valeurs entre -1 et 1 <br>
Passe par des parametre modifiable : <br>
1. La frequency : est globalement un "Zoom" sur le bruit, plus la valeur est basse, plus il y aura de vatiations (car + zoomer en gros)<br>
2. Les octaves : c'est des couche de bruit superposé , plus on met d'octaves ( donc de couches) plus c'est detailé, alors que 1 seul octave sera un terrain vague avcec des grandes collines douce<br>
3. Lacunarity/Persistance : la lacunarité c'est un peu la difference de "taille" entres les details, en gros c'est la difference de taille entre les couches (si on prend des pinceaux en expemple 3 octaves = trois pinceau de plus en plus gros, la lacunarity sera la difference de taille entre ces pinceaux) <br>
La persistance est l'"impact" qu'aura chaque couche (sera il tres visible ou moins visible )<br>
