# AppQuest_Schrittzaehler [![Build status](https://ci.appveyor.com/api/projects/status/fjwwcht4utkih37r?svg=true)](https://ci.appveyor.com/project/zperee/appquest-schrittzaehler)

##Technologie
XAMARIN Forms 2.0

##Aufgabe
Ein QR Code wird auf dem Campus eingelesen, dieser enthält die Wegbeschreibung zum nächsten QR Code. Der QR Code enthält folgende Informationen. 
```json
{"input":["10", "links", "15", "rechts", "20", "links", "25"], "startStation" :1}
```
Nachdem die Informationen eingelesen wurden, muss man mit hilfe des Smartphones den Weg ablaufen, bis man den nächsten QR Code erreicht. Dort wird dann die endStation eingescant und die Lösung bestehend aus startStation und endStation an den Server übermittelt. 
```json
{
  "task": "Schrittzaehler",
  "startStation": 1,
  "endStation": 4
}
```
## Version
0.1

## Authors 
[Luca Marti](https://github.com/zmartl)  
[Homepage](https://www.luca-marti.ch)  
Software Developer
 
[Elia Perenzin](https://github.com/zperee)  
[Homepage](http://eliaperenzin.ch/)  
Software Developer

# Documentation
## Planning
### UML
https://www.gliffy.com/go/share/s5foum20act24fdt9167
### MockUps
![MockUps](https://raw.githubusercontent.com/zperee/AppQuest_Schrittzaehler/master/Documentation/Planning/MockUp/MockUp_AppQuest_Schrittzaehler.jpg)
