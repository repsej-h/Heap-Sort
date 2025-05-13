# Heap Sort

Welkom bij het hoofdstuk over het `heap sort` sorteeralgoritme. Hier zullen we de werking van het algoritme, een codevoorbeeld en enkele voor en nadelen toelichten.

## 1. werking

Laat ons beginnen bij het begin: de werking van het algoritme. Deze kan worden samenvat in drie stappen.

### stap 1: Vorm de array om naar een complete binary tree

Eerst en vooral moeten we onze input array visualiseren als een complete binary tree.

> Ho! wacht eens even, een binary tree wat is dat voor een beest?? Hoewel deze term op het eerste zicht misschien wel complex en intimitered klink, is hij dit helemaal niet. Een binary tree is een graaf, waarbij elke bovenstaande knoop *(parent)* exact twee onderstaande knopen heeft *(childeren)*. De term complete verwijst simpelweg naar het feit dat er voor elke waarde in onze array een knoop is. Onderstaand figuur zal veel verduidelijken, soms zegt een beeld meer dan duizend woorden ;) 

Dit voor een array met grootte n, krijgt de bovenste knoop steeds waarde nul. De linker onderstaande knoop *(child)* zal dan steeds de waarde $2i+1$ krijgen, en de rechter $2i+2$ met $i$ de waarde van de bovenstaande **(parent)* knoop

![Visualize-the-array-as-a-complete-binary-tree.webp](/Users/jesper/Downloads/Visualize-the-array-as-a-complete-binary-tree.webp)

### stap 2: bouw een maximale heap

Vervolgens zullen we ons zo pas gevormde tree gaan aanpassen. Concreet willen we ervoor zorgen dat het grootste element in onze tree helemaal bovenaan komt de staan. Dit kunnen we doen door per niveau te gaan vergelijken. We zullen steeds de waarden van de parent en childeren knopen gaan vergelijken. Indien de een child groter zou zijn dan zijn parent, worden beiden van plaats gewisseld. Wanneer we op het onderste niveau beginnen toepassen en we zo ons weg naar boven werken, eindingen we met een gesorteerde tree. 

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-25-31-image.png)

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-25-54-image.png)



### stap 3: sorteer de array

Nu we onze heapified binary tree hebben, kunnen we beginnen met het sorteren van onze array. Dit doen we door het grootste element, dat nu op plaats 0 in onze array staat, te verwisselen met het laatste element uit de array. Nu weten we dat dit element op zijn correcte plaats staat. 

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-28-59-image.png)

### stap 4: repeat, repeat, repeat

Nu we weten dat het laatste element al op zijn correcte plaats staat, kunnen we deze in gedachten even gaan negeren. Hierdoor onstaat een nieuwe tree, die we opnieuw kunnen gaan sorteren - of liever: *heapify' en*. Om de volledige array dus te sorteren, moeten we nu stappen 2 & 3 blijven herhalen.



![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-33-08-image.png)

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-33-30-image.png)



## 2. implementatie van het Heap Sort algoritme

Goed allemaal heel leuk zo'n theoritisch voorbeeld, maar wat ben je er mee als je het niet kan omzetten naar code en dus in de praktische wereld kan toepassen? Inderdaad, niets... 




