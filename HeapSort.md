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

Goed allemaal heel leuk zo'n theoritische uitwerking, maar wat ben je er mee als je het niet kan omzetten naar code en dus in de praktische wereld kan toepassen? Inderdaad, niets... 

De code voor de implementatie van dit algoritme bestaat uit enkele functies, ofja methoden, gezien we in C# bezig zijn.

> functies in programmeren zijn herbruikbare blokken code die een specifieke taak uitvoeren, waardoor je code overzichtelijker wordt en je dezelfde code niet steeds opnieuw hoeft te schrijven. Je kunt een functie zien als een klein programmaatje binnen je grotere programma dat je kunt aanroepen wanneer je de bijbehorende taak wilt uitvoeren.

### 2.1 heapify

De belangerijkste functie binnen onze code is de functie `static void Heapify()`. De code hiervoor ziet er als volgt uit: 

```C#
 static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // left = 2*i + 1
        int right = 2 * i + 2; // right = 2*i + 2

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != i)
        {
            // Swap arr[i] and arr[largest]
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree.  This is important
            // to ensure the max-heap property is maintained after the swap.
            Heapify(arr, n, largest);
        }
    }
```

Gezien we met deze functie onze input array kunnen omvormen tot de max heap binary tree, is het relatieve belangrijk dat we goed begrijpen hoe deze functie werkt.

We kunnen zien dat deze functie enkele parameters verwacht. 

> Parameters van functies zijn als de ingrediënten die je aan een functie meegeeft, zodat de functie weet met welke gegevens hij zijn taak moet uitvoeren. Ze zijn als invoerwaarden die je tussen de haakjes plaatst bij de definitie van de functie en die de functie gebruikt om zijn werk te doen.

Ten eerste verwacht de functie een array, dit is vanzelfsspreken onze niet gesorteerde input. Ten tweede moeten we de grootte van onze tree meegeven. Waarom leidden we deze niet gewoon af uit de lengte van de input array? Zoals je je hopelijk nog herinnert wordt doorheen het uitvoeren van het programma waarden die op de correcte plaats staan 'genegeerd'. Dit kunnen we doen aan de hand van deze parameter. Ten slotte geven we mee welke index uit de tree we willen heapify'en. 

Het eerste wat binnen de functie gebeurt is het initialiseren van enkele variablen. We gaan er even van uit dat onze parent knoop, ookwel *root* genoemt, de grootste waarde heeft. Of dit effectief zo is controleren we op een later punt in de functie. Vervolgens gaan we bepalen welke indexen de childeren knopen van de parent knoopt hebben. Wie goed heeft opgelet weet nog dat we deze kunnen bepalen aan de hand van $2i ± 1$.

Ziezo, het moelijkste binnen deze functie zit er op. Wat ons nu rest is controleren of de childeren knopen groter zijn dan hun parent, en deze van plaats wisselen als dit het geval is. Het enig wat nog rest is om de functie recursief aan te roepen, wat wil zeggen dat we de functie zichzelf aanroept binnen de code van de functie. Dit doen we om ervoor te zorgen dat alle elementen binnen de sub tree, het gedeelde onder de gewijzigde vertakking, ook nog steeds correct gesorteerd blijft.

### 2.2


