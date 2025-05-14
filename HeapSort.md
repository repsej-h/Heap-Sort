# Heap Sort

Welkom bij het hoofdstuk over het `heap sort` sorteeralgoritme. Hier zullen we de werking van het algoritme, een codevoorbeeld en enkele voor en nadelen toelichten.

## 1. werking

Laat ons beginnen bij het begin: de werking van het algoritme. Deze kan worden samengevat in drie stappen.

### stap 1: Vorm de array om naar een complete binary tree

Eerst en vooral moeten we onze input array visualiseren als een complete binary tree.

> Ho! wacht eens even, een binary tree wat is dat voor een beest?? Hoewel deze term op het eerste zicht misschien wel complex en intimiderend klinkt, is hij dit helemaal niet. Een binary tree is een graaf, waarbij elke bovenstaande knoop *(parent)* exact twee onderstaande knopen heeft *(children)*. De term complete verwijst simpelweg naar het feit dat er voor elke waarde in onze array een knoop is. Onderstaand figuur zal veel verduidelijken, soms zegt een beeld meer dan duizend woorden ;) 

Dit voor een array met grootte n, krijgt de bovenste knoop steeds waarde nul. De linker onderstaande knoop *(child)* zal dan steeds de waarde $2i+1$ krijgen, en de rechter $2i+2$ met $i$ de waarde van de bovenstaande **(parent)* knoop

![Visualize-the-array-as-a-complete-binary-tree.webp](/Users/jesper/Downloads/Visualize-the-array-as-a-complete-binary-tree.webp)

### stap 2: bouw een maximale heap

Vervolgens zullen we ons zo pas gevormde tree gaan aanpassen. Concreet willen we ervoor zorgen dat het grootste element in onze tree helemaal bovenaan komt de staan. Dit kunnen we doen door per niveau te gaan vergelijken. We zullen steeds de waarden van de parent en children knopen gaan vergelijken. Indien de een child groter zou zijn dan zijn parent, worden beiden van plaats gewisseld. Wanneer we op het onderste niveau beginnen toepassen en we zo ons weg naar boven werken, eindigen we met een gesorteerde tree. 

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-25-31-image.png)

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-25-54-image.png)



### stap 3: sorteer de array

Nu we onze heapified binary tree hebben, kunnen we beginnen met het sorteren van onze array. Dit doen we door het grootste element, dat nu op plaats 0 in onze array staat, te verwisselen met het laatste element uit de array. Nu weten we dat dit element op zijn correcte plaats staat. 

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-28-59-image.png)

### stap 4: repeat, repeat, repeat

Nu we weten dat het laatste element al op zijn correcte plaats staat, kunnen we deze in gedachten even gaan negeren. Hierdoor ontstaat een nieuwe tree, die we opnieuw kunnen gaan sorteren - of liever: *heapify' en*. Om de volledige array dus te sorteren, moeten we nu stappen 2 & 3 blijven herhalen.



![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-33-08-image.png)

![](/Users/jesper/Library/Application%20Support/marktext/images/2025-05-13-22-33-30-image.png)



## 2. implementatie van het Heap Sort algoritme

Goed allemaal heel leuk zo'n theoretische uitwerking, maar wat ben je er mee als je het niet kan omzetten naar code en dus in de praktische wereld kan toepassen? Inderdaad, niets... 

De code voor de implementatie van dit algoritme bestaat uit enkele functies, ofja methoden, gezien we in C# bezig zijn.

> functies in programmeren zijn herbruikbare blokken code die een specifieke taak uitvoeren, waardoor je code overzichtelijker wordt en je dezelfde code niet steeds opnieuw hoeft te schrijven. Je kunt een functie zien als een klein programmaatje binnen je grotere programma dat je kunt aanroepen wanneer je de bijbehorende taak wilt uitvoeren.

### 2.1 heapify

De belangrijkste functie binnen onze code is de functie `static void Heapify()`. De code hiervoor ziet er als volgt uit: 

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

Gezien we met deze functie onze input array kunnen omvormen tot de max heap binary tree, is het relatief belangrijk dat we goed begrijpen hoe deze functie werkt.

We kunnen zien dat deze functie enkele parameters verwacht. 

> Parameters van functies zijn als de ingrediënten die je aan een functie meegeeft, zodat de functie weet met welke gegevens hij zijn taak moet uitvoeren. Ze zijn als invoerwaarden die je tussen de haakjes plaatst bij de definitie van de functie en die de functie gebruikt om zijn werk te doen.

Ten eerste verwacht de functie een array, dit is vanzelfspreken onze niet gesorteerde input. Ten tweede moeten we de grootte van onze tree meegeven. Waarom leidden we deze niet gewoon af uit de lengte van de input array? Zoals je je hopelijk nog herinnert, wordt doorheen het uitvoeren van het programma waarden die op de correcte plaats staan 'genegeerd'. Dit kunnen we doen aan de hand van deze parameter. Ten slotte geven we mee welke index uit de tree we willen heapify'en. 

Het eerste wat binnen de functie gebeurt is het initialiseren van enkele variabelen. We gaan er even van uit dat onze parent knoop, ook wel *root* genoemd, de grootste waarde heeft. Of dit effectief zo is, controleren we op een later punt in de functie. Vervolgens gaan we bepalen welke indexen de childeren knopen van de parent knoopt hebben. Wie goed heeft opgelet weet nog dat we deze kunnen bepalen aan de hand van $2i ± 1$.

Ziezo, het moeilijkste binnen deze functie zit er op. Wat ons nu rest is controleren of de childeren knopen groter zijn dan hun parent, en deze van plaats wisselen als dit het geval is. Het enige wat nog rest is om de functie recursief aan te roepen, wat wil zeggen dat de functie zichzelf aanroept binnen de code van de functie. Dit doen we om ervoor te zorgen dat alle elementen binnen de sub tree, het gedeelte onder de gewijzigde vertakking, ook nog steeds correct gesorteerd blijft.

Dit recursief aanroepen demonstreert trouwens heel mooi het nut van functies, zonder  de functie zouden we de code van heapify oneindig in zichzelf moeten plakken. 

### 2.2 Sort

Een tweede functie is de `public static void Sort()`. Deze code zorgt voor het effectief sorteren van de array, dus het op de juiste plaats plaatsen van de elementen eenmaal de max heap gebouwd is. Code ziet er als volgt uit:

```C#
public static void Sort(int[] arr)
    {
        int n = arr.Length;

        // Build max heap.  This is a crucial step in heap sort.
        // We start from the last non-leaf node and heapify all preceding nodes.
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // One by one extract an element from the heap, and then
        //  re-heapify the remaining elements.
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (maximum element) with the last element.
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Reduce the heap size by 1 and heapify the root (index 0)
            //  to maintain the max heap property.
            Heapify(arr, i, 0);
        }
    }
```

Zoals je kan zien verwacht deze code een parameter, de niet gesorteerde input array. Hiervan zal hij meteen de lengte gelijk stellen aan n, omdat we in het begin van de code  rekening moeten houden met de volledige array. Vervolgens starten we met een eerste keer de functie heapify toe te passen op de array. Zoals eerder vermeldt starten we onderaan en werken we daarna onze weg naar boven. De onderste index wordt gegeven door $\frac{n}{2} -1$. 

Vervolgens wisselen we het hoogste element, dat zich nu op index 0 bevindt, van plaats met het laatste element en verkleinen we de grootte van onze tree met 1. Dit doen we voor elk element van de array.

### 2.3 print array

Nu we onze array gesorteerd hebben, kunnen we deze vol trots presenteren aan de gebruiker. Ook hiervoor is het handig om een kleine functie te schrijven: 

```C#
    static void PrintArray(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
```

Hoewel het in Dodona strikt genomen niet noodzakelijk is om dit te doen, vermeld ik deze toch snel even voor de enthousiastelingen die graag eigen code schrijven ;)

### 2.4 main functie

Nu rest ons enkel nog de `public static void Main()`:

```C#
    public static void Main(string[] args)
    {
        // Example array to be sorted
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        int n = arr.Length;

        // Print the original array
        Console.WriteLine("Original array:");
        PrintArray(arr);

        // Call the HeapSort.Sort function to sort the array
        Sort(arr);

        // Print the sorted array
        Console.WriteLine("\nSorted array:");
        PrintArray(arr);
    }
```

Dit stukje code bevat simpelweg de array die moet worden gesorteerd en roept de sorteer en print functies aan.

## 3. Nuttige info

Nu we weten hoe we een array kunnen sorteren aan de hand van het heap sort algoritme, vraag je je misschien af waarom we juist heap sort *willen* gebruiken. 

### voordelen

Om te beginnen heeft heap sort een uiterst minimaal geheugen gebruik. Wanneer we de variabelen om data tijdelijk in te stockeren buiten beschouwing laten, is geen extra geheugen vereist. Note: dit is het geval wanneer we een interatieve in de plaats van een recursieve `heapify()` functie gebruiken.

Bovendien heeft het heap sort algoritme een zeer voorspelbare tijd nodig om een array te sorteren. Deze is namelijk altijd $n\log{n}$ met $n$ de hoogte, aantal niveaus, van de binary tree. Dit wil dus zeggen dat de tijd die nodig is om de array in het beste geval te sorteren gelijk is aan de tijd die nodig is voor het slechtste geval. Dit terwijl dit voor andere sorteeralgoritmes veel uiteen kan lopen.

Hieruit volgt dat heap sort goed kan worden ingezet wanneer men met grote datasets werkt.

### nadelen

Tegenover deze voordelen staan natuurlijk ook enkele nadelen. 

Zo zorgt het minimale geheugengebruik ervoor dat heap sort een *unstable* sorteeralgoritme is, en dus de respectievelijk volgorde van identieke elementen onderling mogelijks niet wordt bewaard.

Ten slotte zorgt de zeer voorspelbare tijd er wel voor dat het algoritme relatief inefficiënt is en kostelijk naar energieverbruik toe, aangezien elk element van de binary tree moet worden vergeleken.
