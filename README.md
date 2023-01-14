
Scripts pour [Nephilim Légende](https://www.legrog.org/jeux/nephilim)
=================================

Fonctions supportées
-------------------------------------------

### Prise de notes et calendrier

Prise de notes perso : j'utilise un document commonmark. Pour générer les titres avec les dates, le script suivant :

```bash
./Nephilim.Utils 2019-01-22 10
```

Génère ceci : 

```md
Session XXX - 2022-10-02 - CAMPAGNE XXX
==========================

## Le mardi    2019-01-22, jour Feu,          mois Orichalque

## Le mercredi 2019-01-23, jour Eau,          mois Orichalque

## Le jeudi    2019-01-24, jour Air,          mois Orichalque

## Le vendredi 2019-01-25, jour Terre,        mois Orichalque

## Le samedi   2019-01-26, jour Orichalque,   mois Orichalque, conjonction

## Le dimanche 2019-01-27, jour Soleil,       mois Orichalque

## Le lundi    2019-01-28, jour Lune,         mois Orichalque

## Le mardi    2019-01-29, jour Feu,          mois Orichalque

## Le mercredi 2019-01-30, jour Eau,          mois Orichalque

## Le jeudi    2019-01-31, jour Air,          mois Orichalque
```

Je n'ai plus qu'à indiquer le numéro de session, remplacer le nom de la campagne et à prendre des notes.

Merci [DuaelFr](https://github.com/DuaelFr/nephilim-almanac-bot/blob/master/config.json)



Fonctions souhaitées
-------------------------------------------

### Campaign helper (base)

Game has many editions: each may have different elements and rules  
Campaigns: may also have specific rules and specifics  
App will use one database for one campaign. This allows to handle many characters in a single set of rules and world data.  
If a user is on multiple campaigns, he will have many campaing files, the app will open the local folder database. User must create one folder for each campaign. 

Base operations

- init: create a campaign (database) into the current directory
    - `init <path>` will create a `<path>/.nephilim-cpg-db/`

Base operations

- see "Campaign helper (base)"


### Character sheet helper (base)

Desired operations

- update the char sheet (hard)
- help define degree of a test (is it useful?)
    - given an element
    - given a main      experience
    - given a secondary experience
    - given a bonus/malus

Base operations

- see "Campaign helper (base)"
- nephilim init: create a character


### Alchemy helper (base)

Desired operations

- create simple  alchemy calendar
    - given a formulae (as argument)
    - given a construct enhancement quantity (as argument)
    - given workload (as argument) (every day, every two days...)
    - given a strategy (as argument): fast (low chance of success), success (lower quantities)
- create complex alchemy calendars
    - given a duration (in days) (as argument)
    - given workload (every day, every two days...) (as argument)
    - given a strategy (as argument): quantity (low chance of success), success (lower quantities)
    - given preferences for formulae and possessed       substances
    - given a character sheet 
    - given known formulae
    - given possessed materia 
    - given constructs configuration


Data structures

- class element
    - name, alias
- collection of elements
    - default values (en): Air, Earth, Fire, Water, Moon
    - default values (fr): Air, Terre, Feu,  Eau,   Lune
    - name, alias
- class "alchemy level"
    - name, alias
    - integer value
- class nephilim
    - name
    - collection of "element ability" 
    - collection of "alchemy level"
- class construct
    - name, alias
    - level: interger value
    - collection of "element ability"
- collection of construct
    - default values (fr): Athanor, Creuset, Cornue, Alambic, Aludel
- class "element ability"
    - element
    - integer value 
- collection of formulae
    - linked to one construct
    - collection of "element ability"
    - various properties: id, common name, 

Behaviors

- collection of characters
    - when one  character  defined: no need to specify it
    - when many characters defined: uses the last one

Base operations

- see "Campaign helper (base)"
- see "Character sheet helper (base)"
- construct: displays constructs
- construct <alias>: displays construct
- construct init:  sets a level of a construct
- construct elem+: inccrement value of one element ability
- construct elem-:  decrement value of one element ability
- formulae  <alias>: defines a formulae
- substance <alias> quantity: sets the quantity of a given substance








